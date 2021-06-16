using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {


        private readonly ILogger<ValuesController> _logger;
        private readonly ApplicationContext _context;
        public ValuesController(ILogger<ValuesController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }

        [HttpGet]
        public IActionResult Get()
        {

            //var students = _context.Students
            //    .AsNoTracking()
            //    .Where(s => s.Age > 25)
            //    .ToList();

            #region Eager Loading

            //var student = _context.Students
            //                .Include(e => e.Evaluations)
            //                .FirstOrDefault();

            //var student = _context.Students
            //                .Include(e => e.Evaluations)
            //                .Include(ss => ss.StudentSubjects)
            //                .ThenInclude(s => s.Subject)
            //                .FirstOrDefault();

            #endregion

            #region Explicit Loading

            //So, the student object contains ICollection<Evaluation> and ICollection<StudentSubject> properties and both are populated by using the Collection method. On the other hand, the StudentSubject entity contains a single reference towards the Subject entity and therefore we are populating the Subject property with the Reference method.

            //var student = _context.Students.FirstOrDefault();

            //_context.Entry(student)
            //    .Collection(e => e.Evaluations)
            //    .Load();

            //_context.Entry(student)
            //    .Collection(ss => ss.StudentSubjects)
            //    .Load();

            //foreach(var studentSubject in student.StudentSubjects)
            //{
            //    _context.Entry(studentSubject)
            //        .Reference(s => s.Subject)
            //        .Load();
            //}

            //var evaluationsCount = _context.Entry(student)
            //        .Collection(e => e.Evaluations)
            //        .Query()
            //        .Count();

            //var gradesPerStudent = _context.Entry(student)
            //        .Collection(e => e.Evaluations)
            //        .Query()
            //        .Select(e => e.Grade)
            //        .ToList();


            #endregion

            #region Select (Projection) Loading

            //var student = _context.Students
            //    .Select(s => new
            //    {
            //        s.Name,
            //        s.Age,
            //        NumberOfEvaluations = s.Evaluations.Count
            //    })
            //    .ToList();

            #endregion

            #region Client vs Server Evaluation

            //var student = _context.Students
            //    .Where(s => s.Name.Equals("John Doe"))
            //    .Select(s => new
            //    {
            //        s.Name,
            //        s.Age,
            //        Explanations = string.Join(",", s.Evaluations.Select(e => e.AdditionalExplanation))
            //    })
            //    .FirstOrDefault();

            #endregion

            #region Raw SQL Commands

            //var student = _context.Students
            //    .FromSqlRaw(@"SELECT * FROM Student WHERE Name = {0}", "John Doe")
            //    .FirstOrDefault();


            //var student = _context.Students
            //    .FromSqlRaw("EXECUTE dbo.MyCustomProcedure")
            //    .ToList();

            //var student = _context.Students
            //    .FromSqlRaw("SELECT * FROM Student WHERE Name = {0}", "John Doe")
            //    .Include(e => e.Evaluations)
            //    .FirstOrDefault();

            //var rowsAffected = _context.Database
            //.ExecuteSqlRaw(
            //    @"UPDATE Student
            //      SET Age = {0} 
            //      WHERE Name = {1}", 29, "Mike Miles");
            //        return Ok(new { RowsAffected = rowsAffected });


            //Reload
            var studentForUpdate = _context.Students
                .FirstOrDefault(s => s.Name.Equals("Mike Miles"));

            var age = 28;
            var rowsAffected = _context.Database
                .ExecuteSqlRaw(@"UPDATE Student 
                                 SET Age = {0} 
                                WHERE Name = {1}", age, studentForUpdate.Name);

            _context.Entry(studentForUpdate).Reload();

            return Ok(new { RowsAffected = rowsAffected });


            #endregion

            // return Ok(student);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var stateBeforeAdd = _context.Entry(student).State; // Detached

            student.StudentDetails = new StudentDetails
            {
                Address = "Added Address",
                AdditionalInformation = "Additional information added"
            };

            _context.Add(student);

            var stateAfterAdd = _context.Entry(student).State;// Added

            _context.SaveChanges();

            var stateAfterSaveChanges = _context.Entry(student).State;// Unchanged

            return Created("URI of the created entity", student);
        }

        [HttpPost("postrange")]
        public IActionResult PostRange([FromBody] IEnumerable<Student> students)
        {
            _context.AddRange(students);
            _context.SaveChanges();
            return Created("URI is going here", students);
        }

        [HttpPut("{id}")]
        public IActionResult PUT(Guid id, [FromBody] Student student)
        {
            //Connected Update
            var dbStudent = _context.Students
                .FirstOrDefault(s => s.Id.Equals(id));

            dbStudent.Age = student.Age;
            dbStudent.Name = student.Name;
            dbStudent.IsRegularStudent = student.IsRegularStudent;


            //To check what was actually modified
            var isAgeModified = _context.Entry(dbStudent).Property("Age").IsModified; //false
            var isNameModified = _context.Entry(dbStudent).Property("Name").IsModified; //true as only name was uodated from client
            var isIsRegularStudentModified = _context.Entry(dbStudent).Property("IsRegularStudent").IsModified; //false

            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/relationship")]
        public IActionResult UpdateRelationship(Guid id,[FromBody] Student student)
        {
            var dbStudent = _context.Students
                .Include(s=>s.StudentDetails)
                .FirstOrDefault(s => s.Id.Equals(id));

            dbStudent.Age = student.Age;
            dbStudent.Name = student.Name;
            dbStudent.IsRegularStudent = student.IsRegularStudent;
            dbStudent.StudentDetails.AdditionalInformation = "Additional information updated";
            _context.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("disconnected")]
        public IActionResult UpdateDisconnected([FromBody]Student student)
        {
            //Disconnected Update

            //The student object sent from the client has a Detached state at a beginning. After we use the Attach method the object is going to change state to Unchanged.
           //This also means that as of this moment, EF Core starts tracking the entity. Now, we are going to change the state to Modified and save it to the database.
 
            _context.Students.Attach(student);
            _context.Entry(student).State = EntityState.Modified;


            //We can see the difference.The Update method will set the entity to tracked and also modify its state from Detached to Modified.So, we don’t have to attach the entity and to modify its state explicitly because the Update method does that for us.
          
            // _context.Update(student);

          _context.SaveChanges();

            return NoContent();
        }
    }
}

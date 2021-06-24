using System;
using System.Collections.Generic;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILoggerManager _logger;
        public ValuesController(ILoggerManager logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            #region Code with Try-Catch
            //try
            //{
            //    _logger.LogInfo("Fetching all the students from the storage");



            //    var students = DataManager.GetAllStudents();

            //    throw new Exception("Exception while fetching all the students from the storage.");

            //    _logger.LogInfo($"Returning {students.Count} students");

            //    return Ok(students);
            //}
            //catch(Exception ex)
            //{
            //    _logger.LogError($"Something went wrong: {ex}");
            //    return StatusCode(500, "Internal server error");
            //}
            #endregion


            _logger.LogInfo("Fetching all the students from the storage");

            var students = DataManager.GetAllStudents();

            //throw new Exception("Exception while fetching all the students from the storage.");
            throw new AccessViolationException("Violation Exception while accessing the resource.");


            _logger.LogInfo($"Returning {students.Count} students");

            return Ok(students);

        }
    }
}
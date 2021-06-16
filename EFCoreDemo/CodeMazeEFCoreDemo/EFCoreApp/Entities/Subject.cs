using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
   public class Subject
    {
        [Column("SubjectId")]
        public Guid Id { get; set; }
        public string SubjectName { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }

        //.Net 5 approach--> No StudentSubject class or StudentSubjectConfiguration is needed. Only the below navigation property. Does not work if Seeded data is needed for Student, Subject and the StudentSubject table

        //public ICollection<Student> Students { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Column("StudentId")]
        public Guid Id { get; set; }

        
        //public Guid AnotherKeyProperty { get; set; }


        //We have an index on this property
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string Name { get; set; }
        public int? Age { get; set; }

        [NotMapped]
        public int LocalCalculation { get; set; }

        public bool IsRegularStudent { get; set; }

        public bool Deleted { get; set; }

        //public string IndexableUniqueProperty { get; set; }
        
        //Navigational Properties
        public StudentDetails StudentDetails { get; set; } 
        public ICollection<Evaluation> Evaluations { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }

        //.Net 5 approach--> No StudentSubject class or StudentSubjectConfiguration is needed. Only the below navigatio property. Does not work if Seeded data is needed for Student, Subject and the StudentSubject table

        //public ICollection<Subject> Subjects { get; set; }
    }
}

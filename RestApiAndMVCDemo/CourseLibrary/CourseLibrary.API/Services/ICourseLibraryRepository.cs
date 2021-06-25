using CourseLibrary.API.Entities;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Services
{
   public interface ICourseLibraryRepository
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthor(Guid authorId);
        bool AuthorExists(Guid authorId);
        IEnumerable<Course> GetCourses(Guid authorId);

        Course GetCourse(Guid authorId, Guid courseId);
        PagedList<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters);

        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        void AddAuthor(Author author);

        public void AddCourse(Guid authorId, Course course);

        public void UpdateCourse(Course course);

        void DeleteCourse(Course course);

        void DeleteAuthor(Author author);
        public bool Save();

    }
}

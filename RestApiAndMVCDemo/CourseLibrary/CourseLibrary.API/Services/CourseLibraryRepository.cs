using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.DbContexts;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.ResourceParameters;

namespace CourseLibrary.API.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository
    {
        private readonly CourseLibraryContext _context;
        private readonly IPropertyMappingService _propertyMappingService;
        public CourseLibraryRepository(CourseLibraryContext context,IPropertyMappingService propertyMappingService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService));
        }
        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList<Author>();
        }


        public PagedList<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters)
        {

            if (authorsResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(authorsResourceParameters));
            }

            //Commenting since paging is needed when there are no filter applied as well
            
            //if (string.IsNullOrEmpty(authorsResourceParameters.MainCategory) && string.IsNullOrEmpty(authorsResourceParameters.SearchQuery))
            //    return GetAuthors();


            var collection = _context.Authors as IQueryable<Author>;
            if(!string.IsNullOrEmpty(authorsResourceParameters.MainCategory))
            {
                authorsResourceParameters.MainCategory = authorsResourceParameters.MainCategory.Trim();
                collection = collection.Where(a => a.MainCategory == authorsResourceParameters.MainCategory);
            }

            if(!string.IsNullOrEmpty(authorsResourceParameters.SearchQuery))
            {
                authorsResourceParameters.SearchQuery = authorsResourceParameters.SearchQuery.Trim();
                collection = collection.Where(a => a.MainCategory.Contains(authorsResourceParameters.SearchQuery) || a.FirstName.Contains(authorsResourceParameters.SearchQuery) || a.LastName.Contains(authorsResourceParameters.SearchQuery));
            }



            //return collection
            //     .Skip(authorsResourceParameters.PageSize * (authorsResourceParameters.PageNumber - 1))
            //     .Take(authorsResourceParameters.PageSize)
            //     .ToList();

            if(!string.IsNullOrEmpty(authorsResourceParameters.OrderBy))
            {
                //if (authorsResourceParameters.OrderBy.ToLowerInvariant() == "name")
                //{
                //    collection = collection.OrderBy(a => a.FirstName).ThenBy(a => a.LastName);
                //}

                //Get property mapping dictionary
               var authorPropertyMappingDictionary = _propertyMappingService.GetPropertyMapping<Models.AuthorDto, Author>();

               collection= collection.ApplySort(authorsResourceParameters.OrderBy, authorPropertyMappingDictionary);

            }

            return PagedList<Author>.Create(collection, authorsResourceParameters.PageNumber, authorsResourceParameters.PageSize);
            
        }

        public Author GetAuthor(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return _context.Authors.FirstOrDefault(a => a.Id == authorId);
        }

        public bool AuthorExists(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return _context.Authors.Any(a => a.Id == authorId);
        }

        public IEnumerable<Course> GetCourses(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return _context.Courses
                        .Where(c => c.AuthorId == authorId)
                        .OrderBy(c => c.Title).ToList();
        }

        public Course GetCourse(Guid authorId, Guid courseId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }
            if(courseId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            return _context.Courses.Where(c => c.AuthorId == authorId && c.Id == courseId).FirstOrDefault();
        }

        public IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds)
        {
            if (authorIds == null)
            {
                throw new ArgumentNullException(nameof(authorIds));
            }

            return _context.Authors.Where(a => authorIds.Contains(a.Id))
                .OrderBy(a => a.FirstName)
                .OrderBy(a => a.LastName)
                .ToList();
        }

        public void AddAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));
            author.Id = Guid.NewGuid();
            foreach(var course in author.Courses)
            {
                course.Id = Guid.NewGuid();
            }

            _context.Authors.Add(author);
        }

        public void AddCourse(Guid authorId, Course course)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            // always set the AuthorId to the passed-in authorId
            course.AuthorId = authorId;
            _context.Courses.Add(course);
        }

        public void UpdateCourse(Course course)
        {

        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
        }

        public void DeleteAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            _context.Authors.Remove(author);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

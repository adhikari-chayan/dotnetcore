﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.DbContexts;
using CourseLibrary.API.Entities;
using CourseLibrary.API.ResourceParameters;

namespace CourseLibrary.API.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository
    {
        private readonly CourseLibraryContext _context;
        public CourseLibraryRepository(CourseLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList<Author>();
        }


        public IEnumerable<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters)
        {

            if (authorsResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(authorsResourceParameters));
            }

            if (string.IsNullOrEmpty(authorsResourceParameters.MainCategory) && string.IsNullOrEmpty(authorsResourceParameters.SearchQuery))
                return GetAuthors();


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

            return collection.ToList();

            
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


        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class AuthorDataManager : IDataRepository<Author, AuthorDto>
    {
        readonly BookStoreContext _bookStoreContext;

        public AuthorDataManager(BookStoreContext storeContext)
        {
            _bookStoreContext = storeContext;
        }

        public void Add(Author entity)
        {
            _bookStoreContext.Author.Add(entity);
            _bookStoreContext.SaveChanges();
        }

        public void Delete(Author entity)
        {
            throw new System.NotImplementedException();
        }

        public Author Get(long id)
        {
            var author = _bookStoreContext.Author
               .SingleOrDefault(b => b.Id == id);

            return author;
        }

        public IEnumerable<Author> GetAll()
        {
            return _bookStoreContext.Author
               .Include(author => author.AuthorContact)
               .ToList();
        }

        public AuthorDto GetDto(long id)
        {

            _bookStoreContext.ChangeTracker.LazyLoadingEnabled = true;

            //In the code above, since we are using lazy loading, only the Author entity will be loaded initially. Later the AuthorContact property will be loaded only when we reference it inside the DTO mapper. 

            //Note: The referenced property can be lazy-loaded only inside the scope of the data context class. Once the context is out of scope, we will no longer have access to those. 
            //Hence, MapToDto is called in book store context's scope here as inside that method the AuthorContact navigation property is accessed which in turn is lazy loaded from database
            using (var context = new BookStoreContext())
            {
                var author = context.Author
                    .SingleOrDefault(b => b.Id == id);

                return AuthorDtoMapper.MapToDto(author);
            }
        }

        public void Update(Author entityToUpdate, Author entity)
        {
            entityToUpdate = _bookStoreContext.Author
                .Include(a => a.BookAuthors)
                .Include(a => a.AuthorContact)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Name = entity.Name;

            entityToUpdate.AuthorContact.Address = entity.AuthorContact.Address;
            entityToUpdate.AuthorContact.ContactNumber = entity.AuthorContact.ContactNumber;

            var deletedBooks = entityToUpdate.BookAuthors.Except(entity.BookAuthors).ToList();
            var addedBooks = entity.BookAuthors.Except(entityToUpdate.BookAuthors).ToList();

            deletedBooks.ForEach(bookToDelete =>
                entityToUpdate.BookAuthors.Remove(
                    entityToUpdate.BookAuthors
                        .First(b => b.BookId == bookToDelete.BookId)));

            foreach (var addedBook in addedBooks)
            {
                _bookStoreContext.Entry(addedBook).State = EntityState.Added;
            }

            _bookStoreContext.SaveChanges();
        }
    }
}

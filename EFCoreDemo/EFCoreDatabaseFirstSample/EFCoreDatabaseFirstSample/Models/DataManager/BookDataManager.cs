using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class BookDataManager : IDataRepository<Book, BookDto>
    {
        readonly BookStoreContext _bookStoreContext;

        public BookDataManager(BookStoreContext storeContext)
        {
            _bookStoreContext = storeContext;
        }
        public void Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public Book Get(long id)
        {
            _bookStoreContext.ChangeTracker.LazyLoadingEnabled = false;
            var book = _bookStoreContext.Book
                  .SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return null;
            }
            _bookStoreContext.Entry(book)
                .Collection(b => b.BookAuthors)
                .Load();
            _bookStoreContext.Entry(book)
                .Reference(b => b.Publisher)
                .Load();

            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookDto GetDto(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book entityToUpdate, Book entity)
        {
            throw new NotImplementedException();
        }
    }
}

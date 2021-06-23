using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{

    public class PublisherDataManager : IDataRepository<Publisher, PublisherDto>
    {
        readonly BookStoreContext _bookStoreContext;

        public PublisherDataManager(BookStoreContext storeContext)
        {
            _bookStoreContext = storeContext;
        }
        public void Add(Publisher entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Publisher entity)
        {
            _bookStoreContext.Remove(entity);
            _bookStoreContext.SaveChanges();
        }

        public Publisher Get(long id)
        {
            return _bookStoreContext.Publisher
                 .Include(a => a.Books)
                 .Single(b => b.Id == id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            throw new NotImplementedException();
        }

        public PublisherDto GetDto(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Publisher entityToUpdate, Publisher entity)
        {
            throw new NotImplementedException();
        }
    }
}

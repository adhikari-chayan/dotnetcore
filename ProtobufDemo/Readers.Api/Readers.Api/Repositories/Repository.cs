using Readers.Api.Models;

namespace Readers.Api.Repositories
{
    public class Repository : IRepository
    {
        private readonly Dictionary<int, Reader> _readers = new();
        private Random _rnd = new Random();
        public Repository()
        {
            InitializeReaderStore();
        }

        public List<Reader> GetAll()
        {
            return _readers.Values.ToList();
        }

        private void InitializeReaderStore()
        {
            //Creating 5 random sample readers
            for (var i = 0; i < 5; i++)
            {
                var id = i + 1;
                _readers.Add(id, new Reader { Id = id, EmailAddress= $"test_{id}@test.com", UserName=$"Reader_{id}"});
            }
        }
       
    }
}

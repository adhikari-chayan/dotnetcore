using System;
using System.Collections.Generic;
using System.Threading;
using Monolith.Models;

namespace Monolith.Data
{
    /// <summary>
    /// 1. Polly is calling our Authors microservice
    /// 2. The Authors service is failing, because it’s the first request
    /// 3. Polly is calling the Authors microservice again(because of the “Retry” policy)
    /// 4. The Authors service is waiting for 5 seconds then failing because of a timeout
    /// </summary>
    public class Repository
    {
        private IEnumerable<Author> _authors { get; set; }
        private bool _shouldFail = true;
        private DateTime _startTime = DateTime.UtcNow;
        public Repository()
        {
            _authors = new[]
            {
                new Author
                {
                    AuthorId = 1,
                    Name = "John Doe",
                    Country = "Australia"
                },
                new Author
                {
                    AuthorId = 2,
                    Name = "Jane Smith",
                    Country = "United States"
                }
            };
        }

        public IEnumerable<Author> GetAuthors()
        {
            if (_shouldFail)
            {
                _shouldFail = false;
                throw new Exception("Oops!");
            }

            if(_startTime.AddMinutes(1) > DateTime.UtcNow)
            {
                Thread.Sleep(5000);
                throw new Exception("Timeout!");
            }
            return _authors;
        }
    }
}

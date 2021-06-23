using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreDatabaseFirstSample.Models.DTO
{
    public class BookDto
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public PublisherDto Publisher { get; set; }
        public ICollection<AuthorDto> Authors { get; set; }
    }
}

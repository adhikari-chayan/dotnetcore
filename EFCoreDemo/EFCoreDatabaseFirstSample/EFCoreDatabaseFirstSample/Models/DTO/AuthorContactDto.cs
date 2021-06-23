using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreDatabaseFirstSample.Models.DTO
{
    public class AuthorContactDto
    {
        public AuthorContactDto()
        {
        }

        public long AuthorId { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }
    }
}

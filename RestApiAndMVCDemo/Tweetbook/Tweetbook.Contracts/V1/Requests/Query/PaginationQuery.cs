using System;
using System.Collections.Generic;
using System.Text;

namespace Tweetbook.Contracts.V1.Requests.Query
{
   public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = 100;
        }

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize ;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}

using MoviePage.Models.Enums;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services
{
    public class PaginationRequest
    {
        public PaginationRequest()
        {
            PaginationQuery = new PaginationQuery();
        }
        public PaginationQuery PaginationQuery { get; set; }
        public string SortBy { get; set; }
        public OrderBy OrderBy { get; set; } = OrderBy.ASCENDING;
    }
}

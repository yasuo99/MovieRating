using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Utility.Helper
{
    public class Pagination<T> where T:class
    {
        public Pagination(int currentPage, int pageSize, int totalPages, int totalItems, HashSet<T> items)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalItems = totalItems;
            Items = items;
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public HashSet<T> Items { get; set; }
    }
}

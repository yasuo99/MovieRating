using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Utility.Helper
{
    public class PaginationHelper<T>
    {
        private int totalItems { get; set; }
        public int TotalItems
        {
            get
            {
                return totalItems;
            }
            set
            {
                totalItems = value;
            }
        }
        private int totalPages { get; set; }
        public int TotalPages
        {
            get
            {
                return totalPages;
            }
            set
            {
                totalPages = value;
            }
        }

        private int currentPage { get; set; }
        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value <= 0 ? 1 : value;
            }
        }
        private int pageSize { get; set; }

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value <= 0 ? 5 : value > 100 ? 100 : value;
            }
        }

        private IEnumerable<T> items { get; set; }
        public IEnumerable<T> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }
        public PaginationHelper(IEnumerable<T> items, int currentPage, int pageSize, int totalItems)
        { 
            PageSize = pageSize;
            Items = items;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling((TotalItems / (double)PageSize));
            CurrentPage = currentPage;
        }
        public PaginationHelper(IEnumerable<T> items, int currentPage, int pageSize)
        {
            PageSize = pageSize;
            Items = items;
            TotalItems = items.Count();
            TotalPages = (int)Math.Ceiling((TotalItems / (double)PageSize));
            CurrentPage = currentPage;
        }
        public static async Task<PaginationHelper<T>> OnCreateAsync(IQueryable<T> items, int currentPage, int pageSize)
        {
            var totalItems = items is IAsyncQueryProvider ? await items.CountAsync() : items.Count();
            var returnItems = items is IAsyncQueryProvider ? await items.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync() : items.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new PaginationHelper<T>(returnItems, currentPage, pageSize, totalItems);
        }
    }
}

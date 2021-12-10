using MediatR;
using Microsoft.AspNetCore.Http;
using MoviePage.Models.Enums;
using MoviePage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Infrastructure
{
    public class PaginationPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private readonly HttpContext _httpContext;
        public PaginationPipe(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }
        public Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            var queries = _httpContext.Request.Query;
            if (request is PaginationRequest paginationRequest)
            {
                var currentPage = queries["currentPage"];
                if (currentPage.Count > 0)
                {
                    paginationRequest.PaginationQuery.CurrentPage = Int32.Parse(currentPage);
                }
                else
                {
                    paginationRequest.PaginationQuery.CurrentPage = 1;
                }
                var pageSize = queries["pageSize"];
                if (pageSize.Count > 0)
                {
                    paginationRequest.PaginationQuery.PageSize = Int32.Parse(pageSize);
                }
                else
                {
                    paginationRequest.PaginationQuery.PageSize = 5;
                }
                var sortBy = queries["sortBy"];
                var orderBy = queries["orderBy"];
                if (sortBy.Count > 0 && !string.IsNullOrEmpty(sortBy.ToString()))
                {
                    paginationRequest.SortBy = sortBy.ToString();
                    if (orderBy.Count > 0)
                    {
                        Enum.TryParse(typeof(OrderBy), orderBy, out var enumParsed);
                        paginationRequest.OrderBy = (OrderBy)enumParsed;
                    }
                }
            }
            return next();
        }
    }
}

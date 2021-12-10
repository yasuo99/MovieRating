using MediatR;
using Microsoft.AspNetCore.Http;
using MoviePage.Models;
using MoviePage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Infrastructure
{
    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private readonly IHttpContextAccessor _httpContext;
        public UserIdPipe(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            //var userId = Guid.Parse(_httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value);
            if(request is BaseRequest br)
            {
                br.UserId = Guid.NewGuid();
            };
            var result = await next();
            //Just check if wrapper worked for TOut
            //if(result is Response<Movie> response)
            //{
            //    response.Data.Title += " CHECKED";
            //}
            return result;
        }
    }
}

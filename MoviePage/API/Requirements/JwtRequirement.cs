using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.API.Requirements
{
    public class JwtRequirement: IAuthorizationRequirement
    {
        
    }
    public class JwtRequirementHandler : AuthorizationHandler<JwtRequirement>
    {
        private readonly HttpContext _httpContext;
        public JwtRequirementHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            JwtRequirement requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}

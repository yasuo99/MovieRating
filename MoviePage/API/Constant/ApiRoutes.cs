using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.API.Constant
{
    public static class ApiRoutes
    {
        private const string BaseApi = "/api";
        public static class Movies
        {
            public const string Base = BaseApi + "/movies";
            public const string Detail = BaseApi + "/movies/{id:guid}";
        }
    }
}

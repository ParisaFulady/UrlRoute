using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlRoute.Infrastructures
{
    public class CodeMeliConstraint : IRouteConstraint
    {
        private static string[] CodeMeli = new[] { "2753647564", "2753647565" };
  
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, 
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            return CodeMeli.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
}

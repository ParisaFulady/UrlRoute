using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(string id)
        {
            var result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index),
            };
            result.Data["id"] = id;// RouteData.Values["id"];
            //result.Data["catchall"] = RouteData.Values["catchall"];// RouteData.Values["id"];
            return View("Result", result);
        }

    }
}

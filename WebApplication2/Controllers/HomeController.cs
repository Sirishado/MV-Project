using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult GetData()
        {
            List<GetData> lstfruits = new List<GetData>();
            GetData fruits = new();
            fruits.Name = "Mango";
            fruits.Colour = "Green";
            lstfruits.Add(fruits);
            GetData fruits1 =new();
            fruits1.Name = "Apple";
            fruits1.Colour = "Red";
            lstfruits.Add(fruits1);
            return View(lstfruits);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

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

        public string GetString()
        {
            return "Welcome to MVC";
        }

        public ActionResult GetlstString()
        {
           ViewBag.fruits = new List<string>()
            {
                "Mango",
                "Apple",
                "Banana",
                "Grapes"
            };
            return View();
            
        }

        public ActionResult GetViewData()
        {
            ViewData["Fruits"] = new List<string>()
            {
                "Mango",
                "Apple",
                "Banana",
                "Grapes"
            };
            return View();

        }

        public ActionResult GetData()
        {
            
            GetData fruits = new GetData();
            fruits.Name = "Mango";
            fruits.Colour = "Green";
            ViewBag.Message = fruits;
            return View();
        }


        public ActionResult GetListData()
        {
            List<GetData> lstfruits = new List<GetData>();
            GetData fruits = new GetData();
            fruits.Name = "Mango";
            fruits.Colour = "Green";
            GetData fruits1 = new GetData();
            fruits1.Name = "Apple";
            fruits1.Colour = "Red";
            lstfruits.Add(fruits);
            lstfruits.Add(fruits1);
            ViewBag.Message1 = lstfruits;
            return View();
        }


    }
}

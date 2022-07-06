using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        SqlConnection con = new SqlConnection("Data Source =tcp:smartcursors.public.3d8c9fc1c5b1.database.windows.net,3342 ;Initial Catalog =SmartcursorTST;User Id=SCMTSTUAT472DAA27;Password=ABEDDCCB75FEFB12DC6D;");

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

        //public ActionResult GetData()
        //{
            
        //    GetData fruits = new GetData();
        //    fruits.Name = "Mango";
        //    fruits.Colour = "Green";
        //    ViewBag.Message = fruits;
        //    return View();
        //}


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

        [HttpGet]
        public ActionResult Register2()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Register(Register register)
        {
            string name = string.Empty;
            con.Open();
            string Query1 = "Select firstName from dbo.Register where Email='" + register.Email + "' and PassWord='" + register.Password + "'";
            SqlCommand cmd1 = new SqlCommand(Query1, con);
            name = Convert.ToString(cmd1.ExecuteScalar());
            if(name!=string.Empty && name!=null)
            {

                throw new Exception("Already User Exist");
            }
           
            var newId = Guid.NewGuid();
                string Query = "Insert into Register Values('"+newId+"','" + register.FirstName + "','" + register.LastName + "','" + register.Email + "','" + register.UserName + "','" + register.Password + "','" + register.MobileNumber + "',1)";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            
                return RedirectToAction(nameof(Login1), "Home");
        }
        [HttpGet]
        public ActionResult Login1()
        {
            return View();
        }

        [HttpPost]
        public string Login(Login login)
        {
            string name = string.Empty;
           
                con.Open();
                string Query = "Select firstName from dbo.Register where Email='" + login.Email + "' and PassWord='" + login.Password + "'";
                SqlCommand cmd = new SqlCommand(Query, con);
                name = Convert.ToString(cmd.ExecuteScalar());

                con.Close();
            
            if (name != string.Empty)
            {
                return "Welcome to TCS";
            }
            else
            {
                return "Login Failed . Ener valid credentials";
            }


        }
    }
}

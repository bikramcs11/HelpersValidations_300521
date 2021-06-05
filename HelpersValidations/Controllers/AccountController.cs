using HelpersValidations.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelpersValidations.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Name"] = model.Username;
                TempData["Message"] = "Welcome Back!";

                string data = JsonSerializer.Serialize(model);
                HttpContext.Session.SetString("data", data);

                Response.Cookies.Append("persistent", "persistent cookie", new CookieOptions { Expires = DateTime.Now.AddDays(7) });
                Response.Cookies.Append("nonpersistent", "non-persistent cookie");

                return RedirectToAction("Message");
            }
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(string[] Username, string Password)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(LoginModel model, string Command)
        //{
        //    if (Command == "Login")
        //    {

        //    }
        //    else
        //    {

        //    }
        //    return View();
        //}

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            //if (string.IsNullOrEmpty(model.Name))
            //{
            //    ModelState.AddModelError("Name", "Please Enter Name");
            //}
            //if (string.IsNullOrEmpty(model.Password))
            //{
            //    ModelState.AddModelError("Password", "Please Enter Password");
            //}

            if (ModelState.IsValid)
            {
                // TO DO:
                return RedirectToAction("Message");
            }
            return View();
        }

        public IActionResult Message()
        {
            string Name = (string)TempData.Peek("Name");
            string Message = (string)TempData["Message"];
            TempData.Keep("Message");

            string data = HttpContext.Session.GetString("data");
            LoginModel model = JsonSerializer.Deserialize<LoginModel>(data);

            string nonpersistent = Request.Cookies["nonpersistent"].ToString();
            string persistent = Request.Cookies["persistent"].ToString();

            return View();
        }

        public IActionResult Data(int id, string name, string address)
        {
            string n = Request.Query["name"];
            string a = Request.Query["address"];

            return View();
        }
    }
}

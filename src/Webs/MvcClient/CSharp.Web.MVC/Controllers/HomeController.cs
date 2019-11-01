using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSharp.Web.MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace CSharp.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secure()
        {
            ViewData["Message"] = "Secure page.";

            return View();
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        public IActionResult Error()
        {
            return View();
        }

        //public async Task<IActionResult> CallApi()
        //{
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");

        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //    var content = await client.GetStringAsync("http://localhost:5001/identity");

        //    ViewBag.Json = JArray.Parse(content).ToString();
        //    return View("json");
        //}
    }
}

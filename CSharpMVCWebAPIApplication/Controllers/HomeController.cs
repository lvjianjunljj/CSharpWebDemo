using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpMVCWebAPIApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            Debug.WriteLine($"ViewBag.Title: {ViewBag.Title}");
            Debug.WriteLine($"Request.HttpMethod: {Request.HttpMethod}");
            Debug.WriteLine($"Request.Url: {Request.Url}");

            return View();
        }
    }
}

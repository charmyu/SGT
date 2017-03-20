using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Power.Controllers
{
    public class MVCTestController : Controller
    {
        // GET: MVCTest
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public string Index()
        {
            return "helloMVC";
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CofcoInd.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error    
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Error404()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Error500()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Error401()
        {
            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNV_Site.Controllers
{
    public class InformesController : Controller
    {
        // GET: Informes
         [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}
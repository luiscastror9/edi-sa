using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CofcoInd.Areas.BackOffice.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
         [Authorize]
        public ActionResult Index()
        {
            return View();
        }
         [Authorize]
         public ActionResult Error404()
         {
             return View();
         }
         [Authorize]
         public ActionResult Error500()
         {
             return View();
         }
         [Authorize]
         public ActionResult Error401()
         {
             return View();
         }
    }
}
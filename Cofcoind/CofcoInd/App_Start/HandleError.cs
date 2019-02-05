﻿using CofcoInd.Areas.BackOffice.Extensions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CofcoInd
{
    [AttributeUsage(
       AttributeTargets.Class | AttributeTargets.Method,
       Inherited = true,
       AllowMultiple = true)]
    internal class HandleError : FilterAttribute, IExceptionFilter
    {
       
        public void OnException(ExceptionContext filterContext)
            {
            //  if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            //    return;
           
            var statusCode = (int)HttpStatusCode.InternalServerError;
                if (filterContext.Exception is HttpException)
                {
                    statusCode = filterContext.HttpContext.Response.StatusCode;
                }
                else if (filterContext.Exception is System.UnauthorizedAccessException)
                {
                    //to prevent login prompt in IIS
                    // which will appear when returning 401.
                    statusCode = 401;
                }
            //EventLog.WriteEntry(filterContext.HttpContext.Request.Url.Host.ToString(), "Exception: " + filterContext.Exception.Message.ToString()+"<br/>"+"Desc: " + filterContext.Exception.Message.ToString() + "<br/>" + "Source: " + filterContext.Exception.Source.ToString(), EventLogEntryType.Error);

            EmailHelper Hp = new EmailHelper();
          //  Hp.SendEmailError("Exception en" + filterContext.HttpContext.Request.Url.ToString(), filterContext.HttpContext.Session["username"].ToString(), filterContext.Exception);

            var result = CreateActionResult(filterContext, statusCode);
                filterContext.Result = result;

                // Prepare the response code.
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.StatusCode = statusCode;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }

    protected virtual ActionResult CreateActionResult(ExceptionContext filterContext, int statusCode)
        {
            var ctx = new ControllerContext(filterContext.RequestContext, filterContext.Controller);
            var statusCodeName = ((HttpStatusCode)statusCode).ToString();

            var viewName = SelectFirstView(ctx,
                                           "~/Views/Error/Error" + (statusCode.ToString()) + ".cshtml", "Error" + (statusCode.ToString()),
                                           "~/Views/Error/General.cshtml",
                                           statusCodeName,
                                           "Error");

            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            var result = new ViewResult
            {
                ViewName = viewName,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                
            };
            result.ViewBag.StatusCode = statusCode;
            
            return result;
        }

        protected string SelectFirstView(ControllerContext ctx, params string[] viewNames)
        {
            return viewNames.First(view => ViewExists(ctx, view));
        }

        protected bool ViewExists(ControllerContext ctx, string name)
        {
            var result = ViewEngines.Engines.FindView(ctx, name, null);
            return result.View != null;
        }
    }
    
}
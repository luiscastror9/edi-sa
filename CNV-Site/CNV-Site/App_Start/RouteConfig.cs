using CNV_Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CNV_Site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.Add(new SeoFriendlyRoute("Prensa/Post/{id}",
            //new RouteValueDictionary(new { namespaces="CNV_Site.Controllers" ,controller = "Prensa", action = "Post", id = UrlParameter.Optional }),
            //new MvcRouteHandler()));
            //RouteBase r= routes.Where(x=>x.)
            //routes.MapRoute(
            //    name: "PrensaPost",
            //    url: "Prensa/Post/{id}",
            //    defaults: new SeoFriendlyRoute("Prensa/Post/{id}",
            //new RouteValueDictionary(new { controller = "Prensa", action = "Post" }),
            //new MvcRouteHandler()),
            //    namespaces: new[] { "CNV_Site.Controllers" }

            //);
                  routes.MapRoute(
                "PrensaPost",
                "Prensa/Post/{id}/{titleNoteGenerateSlug}",
                new { controller = "Prensa", action = "Post",
                id = UrlParameter.Optional,
                    titleNoteGenerateSlug = UrlParameter.Optional
                },
                 namespaces: new[] { "CNV_Site.Controllers" }

            );

            routes.MapRoute(
                 name: "Prensa",
                 url: "Prensa/{action}/{id}",
                 defaults: new
                 {
                     controller = "Prensa",
                     action = "Index",
                     id = UrlParameter.Optional
                 },
                 namespaces: new[] { "CNV_Site.Controllers" }

             );

           

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

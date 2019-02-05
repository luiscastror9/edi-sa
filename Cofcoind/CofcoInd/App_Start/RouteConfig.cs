using CofcoInd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CofcoInd
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

                        routes.MapRoute(
                "novedadesPost",
                "Novedades/Nota/{id}/{titleNoteGenerateSlug}",
                new { controller = "Novedades", action = "Nota",
                id = UrlParameter.Optional,
                    titleNoteGenerateSlug = UrlParameter.Optional
                },
                 namespaces: new[] { "CofcoInd.Controllers" }

            );

            routes.MapRoute(
                 name: "Novedades",
                 url: "Novedades/{action}/{id}",
                 defaults: new
                 {
                     controller = "Novedades",
                     action = "Index",
                     id = UrlParameter.Optional
                 },
                 namespaces: new[] { "CofcoInd.Controllers" }

             );

           

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

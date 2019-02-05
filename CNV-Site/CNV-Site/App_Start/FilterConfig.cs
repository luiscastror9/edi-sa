using System.Web;
using System.Web.Mvc;
using CNV_Site.Areas.BackOffice;


namespace CNV_Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        { 
            filters.Add(new SessionValidate());
            filters.Add(new HandleError());
           // filters.Add(new HandleErrorAttribute());
           
           
        }
    }
}

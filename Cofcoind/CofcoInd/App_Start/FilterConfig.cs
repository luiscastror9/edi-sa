using System.Web;
using System.Web.Mvc;
using CofcoInd.Areas.BackOffice;


namespace CofcoInd
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        { 
         //   filters.Add(new SessionValidate());
            filters.Add(new HandleError());
           // filters.Add(new HandleErrorAttribute());
           
           
        }
    }
}

using CofcoInd.Areas.BackOffice.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CofcoInd;
using System.Web.Mvc.Filters;
namespace CofcoInd.Areas.BackOffice
{
    [AttributeUsage(
      AttributeTargets.Class | AttributeTargets.Method,
      Inherited = true,
      AllowMultiple = true)]
   
    [@HandleError]
    public class SessionValidate : ActionFilterAttribute, IAuthenticationFilter
    {
        public  void OnAuthentication(AuthenticationContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            var username = filterContext.HttpContext.Request.ServerVariables["LOGON_USER"];
            if (username == "") username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var usuarioID = username.Split('\\').Last();
            // if (usuarioID == "") throw new Exception();

         //   ActiveDirectoryHelper aDh = new ActiveDirectoryHelper();
            }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (filterContext.HttpContext.Request.Url.PathAndQuery.Contains("/BackOffice"))
            { 
            if (!user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            }
            //PrincipalContext princContext = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings.Get("ActiveDirectoryDomain"), ConfigurationManager.AppSettings.Get("ActiveDirectoryUser"), ConfigurationManager.AppSettings.Get("ActiveDirectoryPwd"));
            //Ilist user = aDh.SearchADUser(usuarioID);
            //if (aDh.SearchADGroupUser(ConfigurationManager.AppSettings.Get("AppGroup"), username))
            //{
            //}
        }

        }
    }

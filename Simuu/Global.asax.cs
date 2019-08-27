using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Security.Principal;

namespace Simuu
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ApplicationConfig.RegisterAplicationVariables();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            if (ex is System.Threading.ThreadAbortException)
                return; // Redirects may cause this exception..
            LoggingLayer.Logger.Log(ex);
        }

        protected void Application_AcquireRequestState()
        {
            string sessionUser = Session["AUTHUser"] as string;
            string sessionRole = Session["AUTHRole"] as string;
            string ValidationType = Session["AUTHTYPE"] as string;
            if (string.IsNullOrEmpty(sessionUser))
            {
                return;
            }
            GenericIdentity identity = new GenericIdentity(sessionUser, ValidationType);
            if (sessionRole == null) { sessionRole = ""; }
            string[] roles = sessionRole.Split(' ');
            GenericPrincipal p = new GenericPrincipal(identity, roles);
            HttpContext.Current.User = p;
        }
    }
}

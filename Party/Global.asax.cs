using Party.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Party
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static Locator locator;      

        protected void Application_Start()
        {
            locator = new Locator();
            locator.Register();
            AutofacConfig.ConfigureContainer();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

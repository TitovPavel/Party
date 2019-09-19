using MyParty.Infrastructure;
using MyParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyParty
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //DependencyResolver.SetResolver(new Resolver(DependencyResolver.Current));
            AutofacConfig.ConfigureContainer();

            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());


            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

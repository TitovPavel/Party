using Party.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Party.Infrastructure
{
    public class Resolver : IDependencyResolver
    {
        private Locator _locator = new Locator();
        private IDependencyResolver _defoltResolver;

        public Resolver()
        {
            _locator.Register();
        }

        public Resolver(IDependencyResolver defoltResolver):this()
        {
            _defoltResolver = defoltResolver;
        }
        public object GetService(Type serviceType)
        {
            return _locator.Resolve(serviceType)??_defoltResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _defoltResolver.GetServices(serviceType);
        }
    }
}
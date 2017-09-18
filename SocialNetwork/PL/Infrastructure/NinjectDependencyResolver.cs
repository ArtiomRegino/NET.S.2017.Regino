﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DependencyResolver;
using Ninject;

namespace PL.Infrastructure
{
        public class NinjectDependencyResolver : IDependencyResolver
        {
            private readonly IKernel kernel;

            public NinjectDependencyResolver(IKernel kernel)
            {
                this.kernel = kernel;
                kernel.ConfigurateResolver();
            }

            public object GetService(Type serviceType)
            {
                return kernel.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return kernel.GetAll(serviceType);
            }
        }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace DiscountMe {
    public class SMDependencyResolver : IDependencyResolver {

        private readonly IContainer contenedor;

        public SMDependencyResolver(IContainer container) {
            contenedor = container;
        }

        public object GetService(Type serviceType) {
            return serviceType.IsClass ? GetConcreteService(serviceType) : GetInterfaceService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return contenedor.GetAllInstances(serviceType).Cast<object>();
        }

        private object GetConcreteService(Type serviceType) {
            try {
                return contenedor.GetInstance(serviceType);
            }
            catch (StructureMapException) {
                return null;
            }
        }

        private object GetInterfaceService(Type serviceType) {
            return contenedor.TryGetInstance(serviceType);
        }
    }
}
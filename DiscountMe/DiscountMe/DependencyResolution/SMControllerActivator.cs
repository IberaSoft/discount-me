using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace DiscountMe.DependencyResolution {
    public class SMControllerActivator : IControllerActivator {
        public SMControllerActivator(IContainer container) {
            this.container = container;
        }

        private readonly IContainer container;

        public IController Create(RequestContext requestContext, Type controllerType) {
            return container.GetInstance(controllerType) as IController;
        }
    }
}
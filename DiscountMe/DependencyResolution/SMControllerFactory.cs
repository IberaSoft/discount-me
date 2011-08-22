using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace DiscountMe.DependencyResolution {
    public class SMControllerFactory : DefaultControllerFactory {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
            try {
                if ((requestContext == null) || (controllerType == null))
                    return base.GetControllerInstance(requestContext, controllerType);
                return ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch(StructureMapException) {
                Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw;
            }
        }
    }
}
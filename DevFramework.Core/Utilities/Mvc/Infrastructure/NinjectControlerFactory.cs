using Ninject;
using Ninject.Modules;
using System;
using System.Web.Mvc;
using System.Web.Routing;


namespace DevFramework.Core.Utilities.Mvc.Infrastructure
{
    public class NinjectControlerFactory : DefaultControllerFactory
    {

        private IKernel _kernel;

        public NinjectControlerFactory(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }

        protected override  IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) _kernel.Get(controllerType);
        }
    }
}

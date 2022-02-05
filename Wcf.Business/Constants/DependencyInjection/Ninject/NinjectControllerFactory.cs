using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Wcf.Business.Abstract;
using Wcf.Business.Concrete;
using Wcf.DataAccess.Abstract;
using Wcf.DataAccess.Concrete.EntityFramework;

namespace Wcf.Business.Constants.DependencyInjection.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel(new NinjectBindingModule());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
        public class NinjectBindingModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<ICategoryDAL>().To<CategoryDAL>();
                Kernel.Bind<ICategoryService>().To<CategoryManager>();
                Kernel.Bind<IProductDAL>().To<ProductDAL>();
                Kernel.Bind<IProductService>().To<ProductManager>();
            }
        }
    }
}

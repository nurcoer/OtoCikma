using DevFramework.Core.Utilities.Commen;
using DevFramework.Northwind.Business.Abstract;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.DependecyResolvers.Ninject3
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //WcfProxy kullanarak Iproduct service için bana bir tane channel üret
            Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
        }
    }
}

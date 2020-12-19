using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.DependecyResolvers.Ninject3
{
    public class InstanceFactory 
    {

        public static T GetInstance<T>()
        {
            
                var kernel = new StandardKernel(new BusinessModule(), new AutoMapperModule());
                return kernel.Get<T>();
            
        }
    }
}

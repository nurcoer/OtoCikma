using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.NHihabernate;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Manager;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.NHibernet.Helpers;
using Ninject.Modules;
using System.Data.Entity;

namespace DevFramework.Northwind.Business.DependecyResolvers.Ninject3
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            //biri senden ıproductservis isterse Product servisi ver ve bu nu bir kere new() lemek için Insingeltonscope kodu kullanıldı.
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();





            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}

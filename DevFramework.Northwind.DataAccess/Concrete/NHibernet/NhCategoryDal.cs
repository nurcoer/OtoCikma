using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Core.DataAccess.NHihabernate;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernet
{
    public class NhCategoryDal:NhEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }
    }
}

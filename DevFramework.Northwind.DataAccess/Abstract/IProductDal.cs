using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Nortwind.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //ürüne özgü methodlar yazılır.

        List<ProductDetail> GetProductDetails();
    }
}

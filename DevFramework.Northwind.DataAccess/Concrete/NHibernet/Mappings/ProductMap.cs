using DevFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernet.Mappings
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");//map yapılcak tablo

            LazyLoad();//?

            Id(x => x.ProductId).Column("ProductID");// ıd kısmı burda karşılaştır.


            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.CategoryId).Column("CategoryID");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.UnitPrice).Column("UnitPrice");

        }
    }
}

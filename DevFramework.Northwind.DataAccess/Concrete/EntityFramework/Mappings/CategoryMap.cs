using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categorys", @"dbo");
            HasKey(x => x.CategoryId);



            Property(x => x.CategoryName).HasColumnName("CategoryName");
            Property(x => x.CategoryId).HasColumnName("CategoryId");
        }
    }
}

using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependecyResolvers.Ninject3;
using DevFramework.Northwind.Business.ServiceContracts;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductDetailService
/// </summary>
///  
//Projenin belli bir kısmını dış dünyaya açamak istenirse kullanılacak yöntem.
public class ProductDetailService:IProductDetailService
{
    
    IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }
}
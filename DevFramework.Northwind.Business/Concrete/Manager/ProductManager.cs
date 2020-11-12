
using DevFramework.Core.Ascpects.Postsharp;
using DevFramework.Core.Ascpects.Postsharp.CacheAspects;
using DevFramework.Core.Ascpects.Postsharp.LogAspects;
using DevFramework.Core.Ascpects.Postsharp.TransactionAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.loggers;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace DevFramework.Northwind.Business.Concrete.Manager
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal procudtDal)
        {
            _productDal = procudtDal;
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManger))]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        //birinci hesabımdan ikinci hesabıma para yatırma
        [TransactionScopeAspects]
        public void TransactionalOperation(Product product1, Product product2)
        {
                    _productDal.Add(product1);
                    //Bussieness Codes
                    _productDal.Update(product2);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}

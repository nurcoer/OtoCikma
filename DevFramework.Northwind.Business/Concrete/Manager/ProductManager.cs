using AutoMapper;
using DevFramework.Core.Ascpects.Postsharp;
using DevFramework.Core.Ascpects.Postsharp.AuthorizationAspects;
using DevFramework.Core.Ascpects.Postsharp.CacheAspects;
using DevFramework.Core.Ascpects.Postsharp.PerformanceAspects;
using DevFramework.Core.Ascpects.Postsharp.TransactionAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.Utilities.Mappings;
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

        public readonly IMapper _mapper ;

        public ProductManager(IProductDal procudtDal,IMapper mapper)
        {
            _productDal = procudtDal;
            _mapper = mapper;
        }


        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManger))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManger))]
        [PerformanceCounterAspect(2)]
        [SecuredOperation(Roles="Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            // Thread.Sleep(3000); --- aspect sorununu çözünce performance counterı denicez

            var products = _mapper.Map<List<Product>>(_productDal.GetList());
            return products;
        }

       

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        //birinci işlemin doğru şekilde gerçekleşmesi ama ikinci işlemin gerçekleşmemesi sonucu birinci işlemide iptal eden method
        [TransactionScopeAspects]
        [FluentValidationAspect(typeof(ProductValidatior))]
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

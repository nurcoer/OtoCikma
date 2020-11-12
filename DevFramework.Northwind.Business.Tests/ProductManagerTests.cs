using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Business.Concrete.Manager;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;

namespace DevFramework.Northwind.Business.Tests
{
    /// <summary>
    /// ProductManagerTests için kısa açıklama
    /// </summary>
  
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            //
            // TODO: Buraya test mantığını ekleyin
            //

            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());
        }
    }
}

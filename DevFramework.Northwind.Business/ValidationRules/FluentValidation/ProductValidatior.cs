using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidatior:AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz.");//Boş Bırakılamaz
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Bırakılamaz.");
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Lütfen 0'dan büyük bir değer giriniz.");//Parası 0'dan büyük olmalı
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("Stok adedi Boş Bırakılamaz.");
            RuleFor(p => p.ProductName).Length(2, 20).WithMessage("ürün adı en az iki en fazla 20 karakterden olmalıdır.");
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryId == 1);//categoryıd'si 1 olan ürünlerin ürün fiyatı 20'den büyük olması gerekir.
           // RuleFor(p => p.ProductName).Must(StartWithA);  //Ürün adı 'A' ile başlamalıdır.

            
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }

  

   
}

using Application.Interface;
using Domain.Interface;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class ProductApplication : IProductApplication
    {

        private readonly IProduct _product;

        public ProductApplication(IProduct product)
        {
            _product = product;
        }

        public Product ProductById(int productId)
        {
            return _product.ProductById(productId);
        }
    }
}

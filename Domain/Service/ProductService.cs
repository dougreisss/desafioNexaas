using Domain.Interface;
using Domain.Interface.Service;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class ProductService : IProductService
    {
        private readonly IProduct _product;

        public ProductService(IProduct product)
        {
            _product = product;
        }

        public bool DeleteProduct(int productId)
        {
            return _product.DeleteProduct(productId);
        }

        public bool InsertProduct(Product product)
        {
            return _product.InsertProduct(product);
        }

        public Product ProductById(int productId)
        {
            return _product.ProductById(productId);
        }

        public bool UpdateProduct(Product product)
        {
            return _product.UpdateProduct(product);
        }
    }
}

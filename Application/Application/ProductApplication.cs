using Application.Interface;
using Domain.Interface;
using Domain.Interface.Service;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class ProductApplication : IProductApplication
    {

        private readonly IProductService _productService;

        public ProductApplication(IProductService productService)
        {
            _productService = productService;
        }

        public bool DeleteProduct(int productId)
        {
            return _productService.DeleteProduct(productId);
        }

        public bool InsertProduct(Product product)
        {
            return _productService.InsertProduct(product);
        }

        public Product ProductById(int productId)
        {
            return _productService.ProductById(productId);
        }

        public bool UpdateProduct(Product product)
        {
            return _productService.UpdateProduct(product);
        }
    }
}

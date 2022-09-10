﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Service
{
    public interface IProductService
    {
        public Product ProductById(int productId);
        public bool InsertProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(int productId);

    }
}

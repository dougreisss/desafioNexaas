using Domain.Interface;
using Entity;
using Infrastructure.Config.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly IDbConfig _dbConfig;

        public ProductRepository(IDbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("ProductId", productId);

                _dbConfig.ExecuteNonQuery("[dbo].[DeleteProduct]", parameters);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertProduct(Product product)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("ProductName", product.ProductName);
                parameters.Add("ProductPrice", product.ProductPrice);

                _dbConfig.ExecuteNonQuery("[dbo].[InsertProduct]", parameters);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public Product ProductById(int productId)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("ProductId", productId);

                var reader = _dbConfig.ExecuteReader("[dbo].[ProductById]", parameters);

                List<Product> products = new List<Product>();

                if (reader.Rows.Count <= 0)
                {
                    return null;
                }

                var serializedMyObjects = JsonConvert.SerializeObject(reader);
                products = (List<Product>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<Product>));

                return products[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("ProductId", product.ProductId);
                parameters.Add("ProductName", product.ProductName);
                parameters.Add("ProductPrice", product.ProductPrice);

                var reader = _dbConfig.ExecuteReader("[dbo].[UpdateProduct]", parameters);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

using Domain.Interface;
using Entity.Enums;
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

        public Product ProductById(int productId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("ProductId", productId);

            var reader = _dbConfig.ExecuteStoredProcedureWithParameters("[dbo].[ProductById]", parameters);

            var dataTable = new DataTable();
            dataTable.Load(reader);

            Product myObjects = new Product();

            if (dataTable.Rows.Count > 0)
            {
                var serializedMyObjects = JsonConvert.SerializeObject(dataTable);
                // Here you get the object
                myObjects = (Product)JsonConvert.DeserializeObject(serializedMyObjects, typeof(Product));
            }

            return myObjects;
        }
    }
}

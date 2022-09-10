using Domain.Interface;
using Entity.Model;
using Infrastructure.Config.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class StockItemRepository : IStockItem
    {
        private readonly IDbConfig _dbConfig;
        public StockItemRepository(IDbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public bool AddStockItem(StockItem stockItem)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("StoreId", stockItem.StoreId);
                parameters.Add("ProductId", stockItem.ProductId);
                parameters.Add("ProductQuantity", stockItem.ProductQuantity);

                _dbConfig.ExecuteNonQuery("[dbo].[UpdateStockItem]", parameters);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetQuantityProductStockItem(StockItem stockItem)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("StoreId", stockItem.StoreId);
                parameters.Add("ProductId", stockItem.ProductId);

                var reader = _dbConfig.ExecuteReader("[dbo].[GetQuantityProductStockItem]", parameters);

                List<StockItem> products = new List<StockItem>();

                if (reader.Rows.Count <= 0)
                {
                    return 0;
                }

                var serializedMyObjects = JsonConvert.SerializeObject(reader);
                products = (List<StockItem>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<StockItem>));

                return products[0].ProductQuantity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertStockItem(StockItem stockItem)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("StoreId", stockItem.StoreId);
                parameters.Add("ProductId", stockItem.ProductId);
                parameters.Add("ProductQuantity", stockItem.ProductQuantity);

                _dbConfig.ExecuteNonQuery("[dbo].[InsertStockItem]", parameters);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveStockItem(StockItem stockItem)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("StoreId", stockItem.StoreId);
                parameters.Add("ProductId", stockItem.ProductId);
                parameters.Add("ProductQuantity", stockItem.ProductQuantity);

                _dbConfig.ExecuteNonQuery("[dbo].[UpdateStockItem]", parameters);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

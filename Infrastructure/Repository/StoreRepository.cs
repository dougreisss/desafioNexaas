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
    public class StoreRepository : IStore
    {
        private readonly IDbConfig _dbConfig;

        public StoreRepository(IDbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public bool InsertStore(Store store)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("StoreName", store.StoreName);
                parameters.Add("StoreAdress", store.StoreAdress);

                _dbConfig.ExecuteNonQuery("[dbo].[InsertStore]", parameters);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public Store StoreById(int storeId)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("StoreId", storeId);

                var reader = _dbConfig.ExecuteReader("[dbo].[StoreById]", parameters);

                List<Store> stores = new List<Store>();

                if (reader.Rows.Count <= 0)
                {
                    return null;
                }

                var serializedMyObjects = JsonConvert.SerializeObject(reader);
                stores = (List<Store>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<Store>));

                return stores[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateStore(Store store)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("StoreId", store.StoreId);
                parameters.Add("StoreName", store.StoreName);
                parameters.Add("StoreAdress", store.StoreAdress);

                _dbConfig.ExecuteNonQuery("[dbo].[UpdateStore]", parameters);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStore(int storeId)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("StoreId", storeId);

                _dbConfig.ExecuteNonQuery("[dbo].[DeleteStore]", parameters);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

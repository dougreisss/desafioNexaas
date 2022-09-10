using Domain.Interface;
using Domain.Interface.Service;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class StoreService : IStoreService
    {
        private readonly IStore _store;

        public StoreService(IStore store)
        {
            _store = store;
        }

        public bool DeleteStore(int storeId)
        {
            return _store.DeleteStore(storeId);
        }

        public bool InsertStore(Store store)
        {
            return _store.InsertStore(store);
        }

        public Store StoreById(int storeId)
        {
            return _store.StoreById(storeId);
        }

        public bool UpdateStore(Store store)
        {
            return _store.UpdateStore(store);
        }
    }
}

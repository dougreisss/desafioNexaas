using Application.Interface;
using Domain.Interface.Service;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class StoreApplication : IStoreApplication
    {
        private readonly IStoreService _storeService;

        public StoreApplication(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public bool DeleteStore(int storeId)
        {
            return _storeService.DeleteStore(storeId);
        }

        public bool InsertStore(Store store)
        {
            return _storeService.InsertStore(store);
        }

        public Store StoreById(int storeId)
        {
            return _storeService.StoreById(storeId);
        }

        public bool UpdateStore(Store store)
        {
            return _storeService.UpdateStore(store);
        }
    }
}

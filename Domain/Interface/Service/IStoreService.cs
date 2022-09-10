using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Service
{
    public interface IStoreService
    {
        public Store StoreById(int storeId);
        public bool InsertStore(Store store);
        public bool UpdateStore(Store store);
        public bool DeleteStore(int storeId);

    }
}

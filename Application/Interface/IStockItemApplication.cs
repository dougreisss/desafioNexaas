using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IStockItemApplication
    {
        public bool InsertStockItem(StockItem stockItem);
        public bool AddStockItem(StockItem stockItem);
        public bool RemoveStockItem(StockItem stockItem);

    }
}

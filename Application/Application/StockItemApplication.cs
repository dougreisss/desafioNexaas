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
    public class StockItemApplication : IStockItemApplication
    {
        private readonly IStockItemService _stockItemService;
        public StockItemApplication(IStockItemService stockItemService)
        {
            _stockItemService = stockItemService;
        }

        public bool AddStockItem(StockItem stockItem)
        {
            return _stockItemService.AddStockItem(stockItem);
        }

        public bool InsertStockItem(StockItem stockItem)
        {
            return _stockItemService.InsertStockItem(stockItem);
        }

        public bool RemoveStockItem(StockItem stockItem)
        {
            return _stockItemService.RemoveStockItem(stockItem);
        }
    }
}

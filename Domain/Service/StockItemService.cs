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
    public class StockItemService : IStockItemService
    {
        private readonly IStockItem _stockItem;
        public StockItemService(IStockItem stockItem)
        {
            _stockItem = stockItem;
        }

        public bool AddStockItem(StockItem stockItem)
        {
            int newQuantity = _stockItem.GetQuantityProductStockItem(stockItem) + stockItem.ProductQuantity;

            stockItem.ProductQuantity = newQuantity;

            return _stockItem.AddStockItem(stockItem); 
        }

        public bool RemoveStockItem(StockItem stockItem)
        {
            int newQuantity = _stockItem.GetQuantityProductStockItem(stockItem) - stockItem.ProductQuantity;

            stockItem.ProductQuantity = newQuantity;

            return _stockItem.RemoveStockItem(stockItem);
        }

        public bool InsertStockItem(StockItem stockItem)
        {
            return _stockItem.InsertStockItem(stockItem);
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class StockItem
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int ProductQuantity { get; set; }
    }
}

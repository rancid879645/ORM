using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryORM.Model
{
    public class FilterOrder
    {
        public int? Month { get; set; }
        public int? StatusId { get; set; }
        public int? Year { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
    }
}

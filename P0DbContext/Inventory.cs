using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class Inventory
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? QuanStore { get; set; }

        public virtual Product Product { get; set; }
        public virtual Location Store { get; set; }
    }
}

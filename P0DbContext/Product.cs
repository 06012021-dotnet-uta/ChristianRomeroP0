using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public string Make { get; set; }
        public string Text { get; set; }
        public string Size { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

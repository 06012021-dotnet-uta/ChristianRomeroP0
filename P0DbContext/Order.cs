using System;
using System.Collections.Generic;

#nullable disable

namespace context
{
    public partial class Order
    {
        public int? ProductId { get; set; }
        public int? StoreId { get; set; }
        public int CustomerId { get; set; }
        public int? QuanOrder { get; set; }
        public DateTime DateOrder { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Location Store { get; set; }

        public static implicit operator List<object>(Order v)
        {
            throw new NotImplementedException();
        }
    }//class
}//ns

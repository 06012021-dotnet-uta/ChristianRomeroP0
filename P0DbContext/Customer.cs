using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? Member { get; set; }
        public string Email { get; set; }
        public string Mailing { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

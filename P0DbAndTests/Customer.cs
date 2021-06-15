using System;

namespace P0DbAndTests
{
	public class Customer : ICustomer
	{
		public string FName { get; set; }
		public string LName { get; set; }
		public int Age { get; set; }
		public string Username { get; set; }
		public string Password { get; }
        public int Member { get; set; }
		public string Mailing{ get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
	
	}
}


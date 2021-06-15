using System;

namespace FinalProject0
{
	//all interface here
	public interface IProduct
	{
		public string Make { get; set; }
		public string Text { get; set; }
		public string Size { get; set; }
		public decimal Price { get; set; }
	}

	public interface ICustomer
	{
		public string FName { get; set; }
		public string LName { get; set; }
		public int Age { get; set; }
		public string Username { get; set; }
		public string Password { get; }
		public int Member { get; set}
		public string Mailing{ get; set; }
		public string City { get; set}
		public string State { get; set; }
		public string Zip { get; set}
	}

	public interface ILocation
	{
		public string City { get; set}
		public string State { get; set; }
		public string Address { get; set; }
		public string Zip { get; set}
	}

	public interface IInventory
	{
		public string StoreId { get; set}
		public string ProductId { get; set; }
		public int QuanStore { get; set; }
	}

}


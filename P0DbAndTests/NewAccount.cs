using System;

namespace FinalProject0
{
	public class NewAccount
	{
		string usermsg;
		string pwdmsg;
		string username;
		string password;

		//method to be invoked when prompting a customer to create an account
		public Registration()
		{
			usermsg = "Please enter your desired username.";
			username = Console.ReadLine();
			pwdmsg = "Please enter your desired password.";
			password = Console.ReadLine();
		}

	}
}


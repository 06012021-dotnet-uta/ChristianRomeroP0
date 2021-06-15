using System;
using P0DbContext;

namespace P0BusLogc
{
	public class BusinessLogic
	{
        //instantiate a "context" -an "object" of the database
		//had to specify because it was giving me an compiler error 
        P0DbContext.P0DbContext context = new P0DbContext.P0DbContext();

		//method to make a new acccount
		public void Registration()
        {

        }
	}
}

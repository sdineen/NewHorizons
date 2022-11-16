using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Hotel
    {
		public int Id { get; set; }
		public ICollection<Guest> Guests { get; set; }

		//instance variable
		//private int id;

		//property
		//public int Id
		//{
		//	get { return id; }
		//	set { id = value; }
		//}

	}
}

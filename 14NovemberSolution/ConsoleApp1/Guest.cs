namespace ConsoleApp1
{
    public class Guest
    {

        private int id;
		private string name;
		private DateTime checkInDate;

		public DateTime CheckInDate
		{
			get { return checkInDate; }
			set { checkInDate = value; }
		}



		public string Name
		{
			get { return name; }
			set { name = value; }
		}


		public int Id
		{
			get { return id; }
			set { id = value; }
		}


    }
}
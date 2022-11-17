using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chess
{	
    public class Square
    {
		private int x;
		private int y;

		public Square(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"{(char)(x + 97)}{8 - y}";
		}

		public int Y
		{
			get { return y; }
			private set
			{
				if (y < 0 || y > 7)
				{
					throw new ArgumentOutOfRangeException("y must be between 0 an 7");
				}
				y = value;
			}
		}

		public int X
		{
			get { return x; }
			private set
			{
				if(x<0 || x > 7)
				{
					throw new ArgumentOutOfRangeException("x must be between 0 an 7");
				}
				x = value;
			}
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Common
{
	public class RandomNumberGenerator
	{
		private static readonly Random random = new Random();

		public static int Next()
		{
			return random.Next();
		}

		public static int Next(int min, int max)
		{
			return random.Next(min, max);
		}

		public static double NextDouble()
		{
			return random.NextDouble();
		}
	}
}

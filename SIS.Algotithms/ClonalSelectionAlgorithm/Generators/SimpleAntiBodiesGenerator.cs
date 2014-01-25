using SIS.Algotithms.ClonalSelectionAlgorithm.Population;
using SIS.Algotithms.ClonalSelectionAlgorithm.Antibodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Algotithms.ClonalSelectionAlgorithm.Generators
{
	public class SimpleAntiBodiesGenerator
	{
		private static Random random = new Random();

		public static Antibody GetAntiBody()
		{
			throw new NotImplementedException();
		}

		public static List<Antibody> GetAntiBodies()
		{


			return null;
		}

		/// <summary>
		/// Pobiera ilość losowych osobników zależnie od parametru n
		/// </summary>
		/// <param name="n">Ilość osobników do wygenerowania</param>
		/// <returns></returns>
		public static Populacja GetAntiBodies(int n)
		{
			var population = new Populacja();

			for (int i = 0; i < n; i++)
			{
				var antibody = new Antibody
				{
					AdaptationValue = random.NextDouble()
				};
			}


			return null;
		}
	}
}

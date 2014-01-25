using SIS.Algotithms.ClonalSelectionAlgorithm.Population;
using SIS.Algotithms.ClonalSelectionAlgorithm.Gens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Common;

namespace SIS.Algotithms.ClonalSelectionAlgorithm.Generators
{
	public class SimpleGensGenerator
	{
		private static Random random = new Random();

		public static Gen GetSingleGen(AlgorithmOptions options, Func<double, double> funkcja)
		{
			return GetRandomGen(options, funkcja);
		}


		public static List<Gen> GetGensAsList(AlgorithmOptions options, Func<double, double> funkcja)
		{
			var list = new List<Gen>();

			for (int i = 0; i < options.MaxGens; i++)
			{
				list.Add(GetRandomGen(options, funkcja));
			}

			return list;
		}

		private static Gen GetRandomGen(AlgorithmOptions options, Func<double, double> funkcja)
		{
			var minValue = (int)options.SectionX_0 * 100;
			var maxValue = (int)options.SectionX_1 * 100;
			var number = (double)(random.Next(minValue, maxValue)) / 100;
			return new Gen
			{
				Value = number,
				FunctionValue = funkcja.Invoke(number)
			};
		}

		public static Populacja GetGensAsPopulation(AlgorithmOptions options, Func<double, double> funkcja)
		{
			var population = new Populacja();

			for (int i = 0; i < options.MaxGens; i++)
			{
				population.Add(GetRandomGen(options, funkcja));
			}

			return population;
		}
	}
}

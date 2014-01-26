using SIS.Algotithms.ClonalSelectionAlgorithm.Populations;
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
		/// <summary>
		/// Funkcja zwraca pojedyńczy gen
		/// </summary>
		/// <param name="options">Obiekt AlgorytmOptions sluzuący do sterowania parametrami algorytmu</param>
		/// <param name="funkcja">Funkcja do obliczania wartości</param>
		/// <returns></returns>
		public static Gen GetSingleGen(AlgorithmOptions options, Func<double, double> funkcja)
		{
			return GetRandomGen(options, funkcja);
		}

		/// <summary>
		/// Funkcja zwraca populację jako listę
		/// </summary>
		/// <param name="options">Obiekt AlgorytmOptions sluzuący do sterowania parametrami algorytmu</param>
		/// <param name="funkcja">Funkcja do obliczania wartości</param>
		/// <returns></returns>
		public static List<Gen> GetGensAsList(AlgorithmOptions options, Func<double, double> funkcja)
		{
			var list = new List<Gen>();

			for (int i = 0; i < options.MaxGens; i++)
			{
				list.Add(GetRandomGen(options, funkcja));
			}

			return list;
		}

		/// <summary>
		/// Funkcja generuje pojedyńczy gen
		/// </summary>
		/// <param name="options">Obiekt AlgorytmOptions sluzuący do sterowania parametrami algorytmu</param>
		/// <param name="funkcja">Funkcja do obliczania wartości</param>
		/// <returns></returns>
		private static Gen GetRandomGen(AlgorithmOptions options, Func<double, double> funkcja)
		{
			var minValue = (int)options.SectionX_0 * 100;
			var maxValue = (int)options.SectionX_1 * 100;
			var number = (double)(RandomNumberGenerator.Next(minValue, maxValue)) / 100;
			return new Gen
			{
				Value = number,
				FunctionValue = funkcja.Invoke(number)
			};
		}

		/// <summary>
		/// Funkcja zwraca populację jako obiekt klasy Populacja
		/// </summary>
		/// <param name="options"></param>
		/// <param name="funkcja"></param>
		/// <returns></returns>
		public static Population GetGensAsPopulation(AlgorithmOptions options, Func<double, double> funkcja)
		{
			var population = new Population();

			for (int i = 0; i < options.MaxGens; i++)
			{
				population.Add(GetRandomGen(options, funkcja));
			}

			return population;
		}
	}
}

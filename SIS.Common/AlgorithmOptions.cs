using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Common
{
	public class AlgorithmOptions
	{
		/// <summary>
		/// Maksymalna ilosc genow to wytworzenia dla populacji P
		/// </summary>
		public int MaxGens { get; set; }
		/// <summary>
		/// Maksymalna ilość klonów dla osobnika o maksymalnym współczynniku prawdopodobieństwa
		/// </summary>
		public int MaxCloneCountForMaxProbability { get; set; }
		/// <summary>
		/// Ilosc o jaka zmiejsza sie ilosc wytwarzanych klonów
		/// </summary>
		public int MaxDiscountOfClones { get; set; }

		#region StopITERValues

		/// <summary>
		/// Ilość epok gdy warunekiem stopu jest ilosc epok
		/// </summary>
		public int MaxEpochsNumer { get; set; }

		#endregion

		#region StopPROBValues

		/// <summary>
		/// Ilosc genów jaka musi wystapic z danym prawdopodobienstwem gdy warunkiem stopu jest pewna ilosc dobrych osobnikow
		/// </summary>
		public int MaxGoodGens { get; set; }
		/// <summary>
		///	Minimalne prawdopodobienstwo, jakie ma miec gen aby zostal zakwalifikowany do MaxGoodGens
		/// </summary>
		public int MinProbability { get; set; }

		#endregion

		/// <summary>
		/// Przedzial dla ktorego maja byc pobierane wartosc funkcji oceny
		/// </summary>
		public double[] Section { get; set; }
		/// <summary>
		/// Lewy koniec przedzialu dla funkcji oceny
		/// </summary>
		public double SectionX_0 { get; set; }
		/// <summary>
		/// Prawym koniec przedzialu dla funkcji oceny
		/// </summary>
		public double SectionX_1 { get; set; }
		/// <summary>
		/// Wartosc n1
		/// </summary>
		public int nBestGensToTake { get; set; }
		/// <summary>
		/// Wartosc n2
		/// </summary>
		public int nWorstGenToThrow { get; set; }
		/// <summary>
		/// Warunek stopu -
		/// Jeżeli jest ustwiony na ITER to warunkiem stopu jest ilosc iteracji,
		/// Jeżeli jest ustawiony na PROB to warunkiem stopu jest prawdopodobienstwo
		/// </summary>
		public StopContition StopCondition { get; set; }

		public AlgorithmOptions()
		{

		}

		

	}

	public enum StopContition
	{
		ITER = 1,
		PROB = 2
	}
}

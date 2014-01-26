using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Algotithms.ClonalSelectionAlgorithm.Gens
{
	public class Gen
	{
		/// <summary>
		/// Wartość Genu
		/// </summary>
		public double Value { get; set; }
		/// <summary>
		/// Wartość Funkcji oceny
		/// </summary>
		public double FunctionValue { get; set; }
		/// <summary>
		/// Podobieńśtwo do antygenu
		/// </summary>
		public int Similarity { get; set; }


		/// <summary>
		/// Funkcja tworzy nowy obiekt genu na postawie siebie.
		/// </summary>
		/// <returns></returns>
		public Gen Copy()
		{
			return new Gen
			{
				Value = this.Value,
				FunctionValue = this.FunctionValue,
				Similarity = this.Similarity
			};
		}
	}
}

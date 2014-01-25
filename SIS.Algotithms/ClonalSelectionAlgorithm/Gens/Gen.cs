using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Algotithms.ClonalSelectionAlgorithm.Gens
{
	public class Gen
	{
		public double Value { get; set; }
		public double FunctionValue { get; set; }
		public int Probability { get; set; }

		public Gen Copy()
		{
			return new Gen
			{
				Value = this.Value
			};
		}
	}
}

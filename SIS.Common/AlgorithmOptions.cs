using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Common
{
	public class AlgorithmOptions
	{
		public int MaxGens { get; set; }
		/// <summary>
		/// Maksymalna ilość klonów dla osobnika o maksymalnym współczynniku prawdopodobieństwa
		/// </summary>
		public int MaxCloneCountForMaxProbability { get; set; }
		public double[] Section { get; set; }
		public double SectionX_0 { get; set; }
		public double SectionX_1 { get; set; }
		public int nBestGensToTake { get; set; }
		public int nWorstGenToThrow { get; set; }

		public AlgorithmOptions()
		{
		}
	}
}

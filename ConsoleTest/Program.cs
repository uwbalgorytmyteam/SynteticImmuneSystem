using SIS.Algotithms.ClonalSelectionAlgorithm.Algorithm;
using SIS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var algorithm = ClonalSelectionAlgorithm.Instance;
			algorithm.Function = x => x * x + 2 * x + 10;
			algorithm.Options = new AlgorithmOptions
			{
				MaxGens = 30,
				Section = new double[] { -1, 1 },
				SectionX_0 = -1,
				SectionX_1 = 1,
				nBestGensToTake = 10,
				MaxCloneCountForMaxProbability = 20,
			};
			algorithm.PrepareInitialPopulation();
			algorithm.MakeAntyGen();
			algorithm.DoClonalSelection();
		}
	}
}

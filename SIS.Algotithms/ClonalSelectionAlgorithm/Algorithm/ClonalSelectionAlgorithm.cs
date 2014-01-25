using SIS.Algotithms.ClonalSelectionAlgorithm.Generators;
using SIS.Algotithms.ClonalSelectionAlgorithm.Population;
using SIS.Algotithms.ClonalSelectionAlgorithm.Gens;
using SIS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Algotithms.ClonalSelectionAlgorithm.Algorithm
{
	public class ClonalSelectionAlgorithm
	{
		private readonly static Lazy<ClonalSelectionAlgorithm> clonalAlgorithm = new Lazy<ClonalSelectionAlgorithm>(() => new ClonalSelectionAlgorithm());

		private AlgorithmOptions options;

		public AlgorithmOptions Options
		{
			get { return options; }
			set { options = value; }
		}

		private Func<double, double> function;

		public Func<double, double> Function
		{
			get { return function; }
			set { function = value; }
		}

		public static ClonalSelectionAlgorithm Instance
		{
			get
			{
				return clonalAlgorithm.Value;
			}
		}

		public ClonalSelectionAlgorithm() 
		{
		}

		private Populacja _populacja;

		public Populacja Population
		{
			get { return _populacja; }
			set { _populacja = value; }
		}

		public Gen AntyGen { get; set; }

		public void PrepareInitialPopulation()
		{
			Population = SimpleGensGenerator.GetGensAsPopulation(options, Function);
		}

		public void MakeAntyGen()
		{
			AntyGen = SimpleGensGenerator.GetSingleGen(options, Function);
			AntyGen.Probability = 100;
		}

		public void CalculateProbabilityForPopulation()
		{
			Population.CalculateProbability(AntyGen);
			Population.SortDescByProbability();
		}

		public void DoClonalSelection()
		{
			var gensForCloning = Population.Gens.Take(Options.nBestGensToTake).ToList();

			var workerList = new List<Gen>();

			foreach (var gen in gensForCloning)
			{
				//TODO: Zaimpelemtować klonowanie
			}
		}

	}
}

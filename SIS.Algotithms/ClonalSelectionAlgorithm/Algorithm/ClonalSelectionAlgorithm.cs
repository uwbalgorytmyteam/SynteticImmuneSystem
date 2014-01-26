using SIS.Algotithms.ClonalSelectionAlgorithm.Generators;
using SIS.Algotithms.ClonalSelectionAlgorithm.Populations;
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
		// Inicjalizuje Singleton as
		private readonly static Lazy<ClonalSelectionAlgorithm> clonalAlgorithm = new Lazy<ClonalSelectionAlgorithm>(() => new ClonalSelectionAlgorithm());


		private AlgorithmOptions options;

		/// <summary>
		/// Opcje algorytmu
		/// </summary>
		public AlgorithmOptions Options
		{
			get { return options; }
			set { options = value; }
		}

		private Func<double, double> function;

		/// <summary>
		/// Funckja Obliczajaca wartosci
		/// </summary>
		public Func<double, double> Function
		{
			get { return function; }
			set 
			{
				if (function != null)
				{
					function = null;
				}
				function = value; 
			}
		}

		/// <summary>
		/// Instancja Algorytmu
		/// </summary>
		public static ClonalSelectionAlgorithm Instance
		{
			get
			{
				return clonalAlgorithm.Value;
			}
		}

		public ClonalSelectionAlgorithm()
		{ }

		private Population _populacja;

		/// <summary>
		/// Populacja
		/// </summary>
		public Population Populationn
		{
			get { return _populacja; }
			set { _populacja = value; }
		}

		/// <summary>
		/// AntyGen
		/// </summary>
		public Gen AntiGen { get; set; }
		private Population workingPopulation;

		/// <summary>
		/// Liczba epok
		/// </summary>
		public int EpochCount { get; private set; }


		/// <summary>
		/// Funkcja uruchamia algorytm i wykonuje czynnosci zgodnie z podanymi opcjami przez Parametr Options
		/// </summary>
		/// <returns>Zwraca ilość epok, które algorytm wykonał</returns>
		public int StartAlgorithm()
		{
			Init();
			PrepareInitialPopulation();
			MakeAntyGen();
			switch (Options.StopCondition)
			{
				case StopContition.ITER:
				{
					CalculateProbabilityForPopulation();
					for (int i = 0; i < Options.MaxEpochsNumer; i++)
					{
						DoClonalSelection();
						DoHiperMutation();
						DoMetaDynamic();
					}
					EpochCount = Options.MaxEpochsNumer;
					break;
				}
				case StopContition.PROB:
				{
					CalculateProbabilityForPopulation();
					var goodGens = 0;
					do
					{
						EpochCount++;
						DoClonalSelection();
						DoHiperMutation();
						DoMetaDynamic();
						goodGens = Populationn.Gens.Count(g => g.Similarity > Options.MinProbability);
						
					} while (goodGens < Options.MaxGoodGens);
	
					break;
				}
				default:
					break;
			}

			return EpochCount;
		}

		/// <summary>
		/// Funkcja czysci zmienne
		/// </summary>
		private void Init()
		{
			Populationn = null;
			workingPopulation = null;
			AntiGen = null;
			EpochCount = 0;
		}

		/// <summary>
		/// Funkcja Przepisuje początkową populację
		/// </summary>
		public void PrepareInitialPopulation()
		{
			Populationn = SimpleGensGenerator.GetGensAsPopulation(options, Function);
		}

		/// <summary>
		/// Funkcja tworzy antygen
		/// </summary>
		public void MakeAntyGen()
		{
			AntiGen = SimpleGensGenerator.GetSingleGen(options, Function);
			AntiGen.Similarity = 100;
		}

		/// <summary>
		/// Funkcja oblicza podobienstwo do antygenu
		/// </summary>
		public void CalculateProbabilityForPopulation()
		{
			Populationn.CalculateSimilarity(AntiGen);
			Populationn.SortDescByProbability();
		}


		/// <summary>
		/// Funkcje wykonuje selekcję klonalną
		/// </summary>
		public void DoClonalSelection()
		{
			var gensForCloning = Populationn.Gens.Take(Options.nBestGensToTake).ToList();

			workingPopulation = new Population();
			var maxClones = options.MaxCloneCountForMaxProbability;

			foreach (var gen in gensForCloning)
			{
				for (int i = 0; i < maxClones; i++)
				{
					workingPopulation.Add(gen.Copy());
				}

				maxClones -= options.MaxDiscountOfClones;
				if (maxClones <= 0)
				{
					maxClones = 1;
				}

			}

			workingPopulation.SortDescByProbability();
		}


		/// <summary>
		/// Funkcja wykonuje hipermutację oraz zajmuje się dojrzewaniem
		/// </summary>
		public void DoHiperMutation()
		{
			// mutacja polegająca na tym ze jezeli wylosuje 0 to od roznicy wartosci funkcji antygenu i genu
			// odejmuje polowe tej wartosci a w.p.p dodaje polowe tej wartosci
			workingPopulation.Gens.ForEach(g =>
			{
				var operation = RandomNumberGenerator.Next(0, 1);
				var value = Math.Abs(AntiGen.FunctionValue - g.FunctionValue);
				if (operation == 0)
				{
					g.FunctionValue -= (value / 2);
				}
				else
				{
					g.FunctionValue += (value / 2);
				}
			});

			Populationn.CalculateSimilarity(AntiGen);

			// posortowanie i wybranie n1 najlepszych
			workingPopulation.SortDescByProbability();
			var bestGens = workingPopulation.Take(Options.nBestGensToTake);
			
			// dodanie i zastapienie n1 nalepszych
			var pCount = Populationn.Gens.Count;
			Populationn.Gens = Populationn.Gens.Concat(bestGens).ToList();
			Populationn.SortDescByProbability();
			Populationn.Gens = Populationn.Take(pCount).ToList();

		}

		/// <summary>
		/// Funkcja wykonuje Metadynamikę
		/// </summary>
		public void DoMetaDynamic()
		{
			Populationn.SortAscByProbability();
			Populationn.Gens.RemoveRange(0, Options.nWorstGenToThrow);
			for (int i = 0; i < Options.nWorstGenToThrow; i++)
			{
				Populationn.Add(SimpleGensGenerator.GetSingleGen(Options, Function));
			}
			Populationn.CalculateSimilarity(AntiGen);
			Populationn.SortDescByProbability();
			
		}


	}
}

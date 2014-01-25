using SIS.Algotithms.ClonalSelectionAlgorithm.Gens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Algotithms.ClonalSelectionAlgorithm.Population
{
	public class Populacja
	{
		public List<Gen> Gens { get; set; }

		public Populacja()
		{
			Gens = new List<Gen>();
		}

		public Populacja(Populacja population)
		{
			this.Gens = new List<Gen>();
			foreach (var antibody in population.Gens)
			{
				Gens.Add(antibody.Copy());
			}
		}

		public Populacja(List<Gen> antibodies)
		{
			this.Gens = new List<Gen>();
			foreach (var antibody in antibodies)
			{
				Gens.Add(antibody.Copy());
			}
		}

		public Populacja Copy(Populacja populacja)
		{
			var copyPopulation = new Populacja();

			foreach (var antibody in populacja.Gens)
			{
				copyPopulation.Add(antibody.Copy());
			}

			return copyPopulation;
		}

		public void Add(Gen antibody) 
		{
			Gens.Add(antibody);
		}
		public void Remove(int n) 
		{
			Gens.RemoveAt(n);
		}
		public void Remove(Gen antibody) 
		{
			Gens.Remove(antibody);
		}
		public Gen Get(int n) 
		{
			return Gens.ElementAt(n);
		}

		public void SortDescByProbability()
		{
			Gens = Gens.OrderByDescending(key => key.Value).ToList();
		}

		public void SortAscByProbability()
		{
			Gens = Gens.OrderBy(key => key.Value).ToList();
		}

		public void CalculateProbability(Gen AntyGen)
		{
			Gens.ForEach(g =>
			{
				var value = Math.Abs(AntyGen.FunctionValue - g.FunctionValue);
				var procent = (value / AntyGen.FunctionValue);
				var realProcent = 100 - (procent * 100);
				g.Probability = (int)realProcent;
			});
		}
	}
}

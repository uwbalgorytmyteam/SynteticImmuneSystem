using SIS.Algotithms.ClonalSelectionAlgorithm.Gens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Algotithms.ClonalSelectionAlgorithm.Populations
{
	public class Population
	{
		/// <summary>
		/// List genów
		/// </summary>
		public List<Gen> Gens { get; set; }

		public Population()
		{
			Gens = new List<Gen>();
		}

		public Population(Population population)
		{
			this.Gens = new List<Gen>();
			foreach (var antibody in population.Gens)
			{
				Gens.Add(antibody.Copy());
			}
		}

		public Population(List<Gen> antibodies)
		{
			this.Gens = new List<Gen>();
			foreach (var antibody in antibodies)
			{
				Gens.Add(antibody.Copy());
			}
		}

		public Population Copy(Population populacja)
		{
			var copyPopulation = new Population();

			foreach (var antibody in populacja.Gens)
			{
				copyPopulation.Add(antibody.Copy());
			}

			return copyPopulation;
		}

		/// <summary>
		/// Dodaje gen do listy
		/// </summary>
		/// <param name="antibody"></param>

		public void Add(Gen antibody) 
		{
			Gens.Add(antibody);
		}

		/// <summary>
		/// Usuwa gen z listy o indeksie n
		/// </summary>
		/// <param name="n"></param>
		public void Remove(int n) 
		{
			Gens.RemoveAt(n);
		}

		/// <summary>
		/// Usuwa konkretny gen z listy
		/// </summary>
		/// <param name="gen"></param>
		public void Remove(Gen gen) 
		{
			Gens.Remove(gen);
		}

		/// <summary>
		/// Zwraca gen o indeksie n
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public Gen Get(int n) 
		{
			return Gens.ElementAt(n);
		}

		/// <summary>
		/// Zwraca listę genów o długości n
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public List<Gen> Take(int n)
		{
			return Gens.Take(n).ToList();
		}

		/// <summary>
		/// Sortuje populacje rosnąco
		/// </summary>
		public void SortDescByProbability()
		{
			Gens = Gens.OrderByDescending(key => key.Value).ToList();
		}
		
		/// <summary>
		/// Sortuje populację malejąco
		/// </summary>
		public void SortAscByProbability()
		{
			Gens = Gens.OrderBy(key => key.Value).ToList();
		}

		// Oblicza podobieństwo genom
		public void CalculateSimilarity(Gen AntyGen)
		{
			Gens.ForEach(g =>
			{
				var value = Math.Abs(AntyGen.FunctionValue - g.FunctionValue);
				var procent = (value / AntyGen.FunctionValue);
				var realProcent = 100 - (procent * 100);
				g.Similarity = (int)realProcent;
			});
		}
	}
}

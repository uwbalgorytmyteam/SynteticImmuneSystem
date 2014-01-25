using SIS.Algotithms.ClonalSelectionAlgorithm.Antibodies;
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
		public List<Antibody> AntiBodies { get; set; }


		public void Add() { }
		public void Remove(int n) { }
		public void Remove(Antibody antibody) { }
		public void Get(int n) { }
	}
}

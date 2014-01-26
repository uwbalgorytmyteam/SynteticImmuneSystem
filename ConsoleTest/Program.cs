using SIS.Algotithms.ClonalSelectionAlgorithm.Algorithm;
using SIS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.Algotithms.NegativeSelectionAlgorithm.Algorithm;
using SIS.Algotithms.NegativeSelectionAlgorithm.Population;

namespace ConsoleTest
{
	class Program
	{
		static void Main(string[] args)
		{

                  //dane do pobrania z GUI
                  int a = 10;          //początek przedziału do losowania wartości komórek
                  int b = 100;          //koniec przedziału do losowania wartości komórek
                  int ammount = 10;    //ile chcemy pasujących antygenów na wyjściu
                  double tollerance = 0.30;  // tolerancja odchylenia od wzorca zakres od 0 do 1 najlepiej z listy rozwijanej



                  //przemielenie algorytmu 
                  NegativeSelectionAlgorithmClass algorithm = new NegativeSelectionAlgorithmClass(a, b, ammount, tollerance);
                  //dane do wyprowadzenia na GUI


                  System.Console.WriteLine("Wylosowana komórka macierzysta i jej wartość funkcji przystosowania");
                  System.Console.WriteLine(algorithm.stemCell.getCellValue() + " i " + algorithm.stemCell.getCellValueOfFunction());

                  System.Console.WriteLine("Populacja wyjściowa przeciwciał");
                  for (int i = 0; i < algorithm.antibodies.Count; i++)
                  {
                      System.Console.WriteLine(algorithm.antibodies[i].getCellValue() + " i " + algorithm.antibodies[i].getCellValueOfFunction());
                  }

                  System.Console.WriteLine("Liczba epok potrzebna do osiągnięcia wyniku: "+ algorithm.getAmmountOfEpochs());



                  System.Console.WriteLine("Taka sytuacja");
                  System.Console.ReadKey();

                  // Klonalny

                  var algorithm2 = ClonalSelectionAlgorithm.Instance;
                  algorithm2.Function = x => x * x + 2 * x + 10;
                  algorithm2.Options = new AlgorithmOptions
                  {
                     MaxGens = 30,
                     Section = new double[] { 10, 100 },
                     SectionX_0 = 10,
                     SectionX_1 = 100,
                     nBestGensToTake = 10,
                     nWorstGenToThrow = 4,
                     MaxCloneCountForMaxProbability = 20,
                     MinProbability = 95,
                     MaxGoodGens = 20,
                     StopCondition = StopContition.PROB,
                     MaxEpochsNumer = 10
                  };

                  algorithm2.StartAlgorithm();

		}
	}
}

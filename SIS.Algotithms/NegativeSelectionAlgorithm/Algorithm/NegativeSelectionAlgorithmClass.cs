using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Algotithms.NegativeSelectionAlgorithm.Population;
using System.IO;


namespace SIS.Algotithms.NegativeSelectionAlgorithm.Algorithm
{
    public class NegativeSelectionAlgorithmClass
    {
        #region variables

        public Cell stemCell;          //komórka macierzysta (wzorcowa, antygen)
        public List<Cell> antibodies = new List<Cell>();  //komórki przeciwciał
        private double tollerance;      //tolerancja odchylenia wyrażona w liczbie od 0 do 1 (procenty) 
        private int ammountOfEpochs = 0;    //liczba epok jakie były potrzebne do znalezienia rozwiązania

        #endregion

        #region constructors

        public NegativeSelectionAlgorithmClass(int min, int max, int amountOfAntibodies, double tollerance)
        {
            try
            {
                if (tollerance > 0 && tollerance < 1)
                {
                    this.tollerance = tollerance;
                }
                else
                {
                    throw new Exception("Nie prawidłowa wartość tolerancji");
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            this.stemCell = new Cell(min, max);
            runAlgorithm(amountOfAntibodies, min, max);

        }

        #endregion

        #region methods

        private void runAlgorithm(int amountOfAntibodies, int a, int b)
        {
            while (antibodies.Count() <= amountOfAntibodies)
            {
                System.Threading.Thread.Sleep(30);
                Cell tempCell = new Cell(a,b);
                if (tempCell.getCellValueOfFunction() > stemCell.getCellValueOfFunction() - stemCell.getCellValueOfFunction()
                    * tollerance && tempCell.getCellValueOfFunction() < stemCell.getCellValueOfFunction() +
                    stemCell.getCellValueOfFunction() * tollerance)
                {
                    antibodies.Add(tempCell);
                    ammountOfEpochs++;
                }
                else
                {
                    ammountOfEpochs++;
                }
            }
        }

        public Cell getStemCell()
        {
            return stemCell;
        }

        public int getAmmountOfEpochs()
        {
            return ammountOfEpochs;
        }

        public List<Cell> getAntibodies()
        {
            return antibodies;
        }
        #endregion
    }
}

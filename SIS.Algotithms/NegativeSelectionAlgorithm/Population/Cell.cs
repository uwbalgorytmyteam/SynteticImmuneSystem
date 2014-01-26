using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Algotithms.NegativeSelectionAlgorithm.Population
{
    public class Cell
    {
        #region variables

        private int cellValue;      //wartość komórki 
        private double cellValueOfFunction; //wartość funkcji przystosowania komórki
        private int a;      //początek przedziału wartości komórki
        private int b;      //koniec przedziału wartości komórki

        #endregion

        #region constructors

        public Cell(int start, int end)
        {
            Random randNum = new Random();
            cellValue = randNum.Next(start, end);
            cellValueOfFunction = calculateValueOfCell();
        }

 
        #endregion


        #region methods

        private double calculateValueOfCell()
        {
            return cellValue * cellValue + 2 * cellValue + 10;
        }

        public double getCellValueOfFunction()
        {
            return cellValueOfFunction;
        }

        public int getCellValue()
        {
            return cellValue;
        }

        #endregion
    }
}

using SIS.Algotithms.NegativeSelectionAlgorithm.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace SIS.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

        public void recordToFileNegativeSelectionAlgorithm(NegativeSelectionAlgorithmClass negativeSelectionAlgorithmClass)
        {
            System.IO.File.Delete(@"C:\Users\Rafal\Desktop\Wyniki programu.csv");
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Rafal\Desktop\Tekscik.csv", true))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat("Wylosowana komorka macierzysta: {0} i jej wartosc funkcji przystosowania: {1}{2}", negativeSelectionAlgorithmClass.stemCell.getCellValue().ToString(), negativeSelectionAlgorithmClass.stemCell.getCellValueOfFunction().ToString(),Environment.NewLine);
                sw.WriteLine(stringBuilder.ToString());

                sw.WriteLine("Populacja wyjsciowa przeciwcial:");
                for (int i = 0; i < negativeSelectionAlgorithmClass.antibodies.Count; i++)
                {
                    sw.WriteLine("{0} i {1}",negativeSelectionAlgorithmClass.antibodies[i].getCellValue().ToString(), negativeSelectionAlgorithmClass.antibodies[i].getCellValueOfFunction().ToString());
                }

                stringBuilder.AppendFormat("{0}Liczba epok potrzebna do osiagniecia wyniku: {1}",Environment.NewLine, negativeSelectionAlgorithmClass.getAmmountOfEpochs().ToString());
                sw.WriteLine(stringBuilder.ToString());
            }
        }

        private void negativeSelection_Click(object sender, RoutedEventArgs e)
        {
            int min = Convert.ToInt32(startTbx.Text);
            int max = Convert.ToInt32(koniecTbx.Text);
            int amountOfAntibodies = Convert.ToInt32(antygenyTbx.Text);
            double tollerance = odchylenieCbx.SelectedValue.GetType(double); //Convert.ToDouble(odchylenieCbx.SelectedItem as string);

            NegativeSelectionAlgorithmClass negativeSelectionAlgorithmClass = new NegativeSelectionAlgorithmClass(min, max, amountOfAntibodies, tollerance);
            
            recordToFileNegativeSelectionAlgorithm(negativeSelectionAlgorithmClass);
        }
	}
}

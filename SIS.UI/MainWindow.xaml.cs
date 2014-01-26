using SIS.Algotithms.NegativeSelectionAlgorithm.Algorithm;
using SIS.Algotithms.ClonalSelectionAlgorithm.Algorithm;
using SIS.Algotithms.ClonalSelectionAlgorithm.Gens;
using SIS.Common;
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
            System.IO.File.Delete(@"D:\Wyniki programu.csv");
            using (StreamWriter sw = new StreamWriter(@"D:\Wyniki programu.csv", true))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat("Wylosowana komorka macierzysta: {0} i jej wartosc funkcji przystosowania: {1}{2}", negativeSelectionAlgorithmClass.stemCell.getCellValue().ToString(), negativeSelectionAlgorithmClass.stemCell.getCellValueOfFunction().ToString(),Environment.NewLine);

                stringBuilder.AppendFormat("Populacja wyjsciowa przeciwcial:\n");
                for (int i = 0; i < negativeSelectionAlgorithmClass.antibodies.Count; i++)
                {
                    stringBuilder.AppendFormat("{0} i {1} \n", negativeSelectionAlgorithmClass.antibodies[i].getCellValue().ToString(), negativeSelectionAlgorithmClass.antibodies[i].getCellValueOfFunction().ToString());
                }

                stringBuilder.AppendFormat("{0}Liczba epok potrzebna do osiagniecia wyniku: {1}",Environment.NewLine, negativeSelectionAlgorithmClass.getAmmountOfEpochs().ToString());
                sw.WriteLine(stringBuilder.ToString());

                wynikiTbx.Text = (stringBuilder.ToString());
            }
        }

        public void recordToFileClonalSelectionAlgorithm(ClonalSelectionAlgorithm clonalSelectionAlgorithmClass)
        {
            System.IO.File.Delete(@"D:\Wyniki programu.csv");
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("Wartości i wartości funkcji oceny:\n");
            using (StreamWriter sw = new StreamWriter(@"D:\Wyniki programu.csv", true))
            {
                var population = clonalSelectionAlgorithmClass.Populationn;
                foreach (var gen in population.Gens)
                {
                    stringBuilder.AppendFormat("{0} i {1}\n",gen.Value.ToString(),gen.FunctionValue.ToString());
                }
                stringBuilder.AppendFormat("\n Ilosc iteracji: {0}",clonalSelectionAlgorithmClass.StartAlgorithm().ToString());
                wynikiTbx.Text = (stringBuilder.ToString());
            }
        }

        private void negativeSelection_Click(object sender, RoutedEventArgs e)
        {
            int min = Convert.ToInt32(startTbx.Text);
            int max = Convert.ToInt32(koniecTbx.Text);
            int amountOfAntibodies = Convert.ToInt32(antygenyTbx.Text);
            var selectedComboBoxItem = odchylenieCbx.SelectedItem as ListBoxItem;
            var comboBoxValue = selectedComboBoxItem.Content.ToString().Replace(".", ",");
            double tollerance = Convert.ToDouble(comboBoxValue);

            NegativeSelectionAlgorithmClass negativeSelectionAlgorithmClass = new NegativeSelectionAlgorithmClass(min, max, amountOfAntibodies, tollerance);
            
            recordToFileNegativeSelectionAlgorithm(negativeSelectionAlgorithmClass);
        }

        private void clonalSelection_Click(object sender, RoutedEventArgs e)
        {
            var algorithm2 = ClonalSelectionAlgorithm.Instance;
            algorithm2.Function = x => x * x + 2 * x + 10;

            double[] sectionFromTbx = new double[2];
            sectionFromTbx[0] = Convert.ToDouble(OdTbx.Text);
            sectionFromTbx[1] = Convert.ToDouble(DoTbx.Text);

            StopContition typ = StopContition.ITER; 
            
            if(warunekIloscIteracji.IsChecked.Value == true)
               typ = StopContition.ITER;
            if(warunekPrawdopodobienstwo.IsChecked.Value == true)
               typ = StopContition.PROB;
            

            algorithm2.Options = new AlgorithmOptions
            {
                MaxGens = Convert.ToInt32(genyTbx.Text),
                Section = sectionFromTbx,
                SectionX_0 = sectionFromTbx[0],
                SectionX_1 = sectionFromTbx[1],
                nBestGensToTake = Convert.ToInt32(wartoscN1Tbx.Text),
                nWorstGenToThrow = Convert.ToInt32(wartoscN2Tbx.Text),
                MaxCloneCountForMaxProbability = Convert.ToInt32(maxIloscKlonowTbx.Text),
                MinProbability = Convert.ToInt32(minPrawdopodobienstwoTbx.Text),
                MaxGoodGens = Convert.ToInt32(iloscGenowTbx.Text),
                StopCondition = typ,
                MaxEpochsNumer = Convert.ToInt32(maxIloscEpokTbx.Text)
            };

            algorithm2.StartAlgorithm();


            recordToFileClonalSelectionAlgorithm(algorithm2);
        }
	}
}

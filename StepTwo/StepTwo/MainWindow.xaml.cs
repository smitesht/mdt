using Microsoft.Win32;
using StepTwo.Moodels;
using StepTwo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace StepTwo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MainViewModel mainViewModel = null;
		public MainWindow()
		{
			InitializeComponent();
			mainViewModel = new MainViewModel();
			this.DataContext = mainViewModel;
		}

		private void btnFileBrose_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "JSON files (*.json)|*.json";

			if (openFileDialog.ShowDialog() == true)
			{
				try
				{
					string jsonFilePath = openFileDialog.FileName;

					string jsonString = File.ReadAllText(jsonFilePath);
					DataJson dataJson = JsonSerializer.Deserialize<DataJson>(jsonString);
					if (dataJson == null || dataJson.datasets == null || dataJson.generators == null)
					{
						MessageBox.Show("Please use correct data.json file");						
					}
					else
					{
						mainViewModel.InitData(dataJson.generators, dataJson.datasets);
						//MainViewModel mainViewModel = new MainViewModel(dataJson.generators, dataJson.datasets);
						//this.DataContext = mainViewModel;
					}

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

			}			
			
		}

		/*private void generatorGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DataGrid generatorGrid = sender as DataGrid;
			String str = generatorGrid.SelectedItem.ToString();
        }*/
    }
}

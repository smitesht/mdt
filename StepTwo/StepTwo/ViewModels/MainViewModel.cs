using StepTwo.Commands;
using StepTwo.Moodels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


/*
 * This is a ViewModel class that perform data binding for the view.
 * The class also perform Operations logic and update the view.
 * 
 */

namespace StepTwo.ViewModels
{
	public class MainViewModel: INotifyPropertyChanged
	{
		// DataSets correspondce to datasets of the JSON file.
		public ObservableCollection<Dataset> DataSets { get; set; } = new ObservableCollection<Dataset>();

		// GeneratorDSs correspondce to generators of the JSON file.
		public ObservableCollection<GeneratorDS> GeneratorDSs { get; set; } = new ObservableCollection<GeneratorDS>();

		// OutputLogger logs the final result to the view
		private ObservableCollection<OutputMessage> _outputLogger = new ObservableCollection<OutputMessage>();
		public ObservableCollection<OutputMessage> OutputLogger
		{
			get { return _outputLogger; }
			set { _outputLogger = value; OnPropertyChanged(nameof(OutputLogger)); }
		}

		// When Dataset select this property used
		private Dataset selectedDataset;

		public Dataset SelectedDataset
		{
			get { return selectedDataset; }
			set { selectedDataset = value; OnPropertyChanged(nameof(SelectedDataset)); }
		}

		// When generator select this property used

		private GeneratorDS selectedGenerator;

		public GeneratorDS SelectedGenerator
		{
			get { return selectedGenerator; }
			set
			{
				selectedGenerator = value;
				OnPropertyChanged(nameof(SelectedGenerator));
			}
		}
	
		// Start Task when user press Start button
		public ICommand StartTaskCommand { get; set; }
		
		// list all the generators tasks
		List<Task> tasks = new List<Task>();
		
		
		// Constructor
		public MainViewModel()
        {
			StartTaskCommand = new RelayCommand(TaskExecute, CanTaskExecute);			
			
		}

		
		private bool CanTaskExecute(object obj)
		{
			return true;
		}
				
		// This is the core function to perform all the generator operations.
		private void TaskExecute(object obj)
		{
			
			foreach (GeneratorDS gen in GeneratorDSs)
			{
				
				if (gen.operation == "sum")
				{
										
					Task task = Task.Run(() =>
					{
						SumTask(gen, DataSets);
					});

					tasks.Add(task);

				}
				else if (gen.operation == "min")
				{
					
					Task task = Task.Run(() =>
					{
						MinTask(gen, DataSets);
					});

					tasks.Add(task);
				}
				else if (gen.operation == "max")
				{
					
					Task task = Task.Run(() =>
					{
						MaxTask(gen, DataSets);
					});

					tasks.Add(task);
				}
				else if (gen.operation == "average")
				{
					
					Task task = Task.Run(() =>
					{
						AvgTask(gen, DataSets);
					});

					tasks.Add(task);
				}
			}
			
		}

		// Perform Sum on each Datasets on Each interval defined on the Generator object
		private void SumTask(GeneratorDS gen, ObservableCollection<Dataset> ds)
		{
			while (true)
			{
				foreach (var datas in ds)
				{
					try
					{
												
						double sum = datas.dataset.Sum();
						string msg = GeneratorResponse.logString(gen.name, sum);

						if (Application.Current != null)
						{
							Application.Current.Dispatcher.Invoke(() =>
							{
								OutputLogger.Add(new OutputMessage { OutputMsg = msg });
							});
						}

						Thread.Sleep(gen.interval * 1000);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}				
					
				}			

			}
		}

		// Perform Minimum on each Datasets on Each interval defined on the Generator object
		private void MinTask(GeneratorDS gen, ObservableCollection<Dataset> ds)
		{
			while (true)
			{
				foreach (var datas in ds)
				{
					try
					{
						
						double res = datas.dataset.Min();
						string msg = GeneratorResponse.logString(gen.name, res);

						if (Application.Current != null)
						{
							Application.Current.Dispatcher.Invoke(() =>
							{
								OutputLogger.Add(new OutputMessage { OutputMsg = msg });
							});
						}

						Thread.Sleep(gen.interval * 1000);
					}
					catch(Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}			

			}
		}

		// Perform Maximum on each Datasets on Each interval defined on the Generator object
		private void MaxTask(GeneratorDS gen, ObservableCollection<Dataset> ds)
		{
			while (true)
			{
				foreach (var datas in ds)
				{
					try
					{					

						double res = datas.dataset.Max();
						string msg = GeneratorResponse.logString(gen.name, res);

						if (Application.Current != null)
						{
							Application.Current.Dispatcher.Invoke(() =>
							{
								OutputLogger.Add(new OutputMessage { OutputMsg = msg });
							});
						}

						Thread.Sleep(gen.interval * 1000);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}				
					
				}
				
			}
		}

		// Perform Average on each Datasets on Each interval defined on the Generator object
		private void AvgTask(GeneratorDS gen, ObservableCollection<Dataset> ds)
		{
			while (true)
			{
				foreach (var datas in ds)
				{
					try
					{						

						double res = datas.dataset.Average();
						string msg = GeneratorResponse.logString(gen.name, res);

						if (Application.Current != null)
						{
							Application.Current.Dispatcher.Invoke(() =>
							{
								OutputLogger.Add(new OutputMessage { OutputMsg = msg });
							});
						}

						Thread.Sleep(gen.interval * 1000);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}				
					
				}
			}
		}
				
		// This method call from the view after uploading JSON file and populate required properties and list
		public void InitData(ObservableCollection<Generator> generators, ObservableCollection<ObservableCollection<double>> ds)
        {
			
			int key = 0;
			foreach (var d in ds)
			{
				Dataset dataset = new Dataset(key, d);
				key++;
				DataSets.Add(dataset);
			}

			key = 0;
			foreach (Generator gen in generators)
			{
				GeneratorDS genDs = new GeneratorDS(key, gen.name, gen.operation, gen.interval);
				key++;
				GeneratorDSs.Add(genDs);
			}			
			
		}

		public event PropertyChangedEventHandler? PropertyChanged;
				
		private void OnPropertyChanged(string propertyName)
        {
            if(propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}
}

using StepOne.Commands;
using StepOne.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StepOne.ViewModels
{
	/*
	 * 
	 * This class can be considered as the ViewModel class that interact with Main and Models.
	 * The class first loads the JSON file data, and then based on generator execute the 
	 * required operations mentioned in the JSON file.
	 * 
	 */

	public class MainViewModel 
	{
		// Hold the JSON file datasets values
		public ObservableCollection<ObservableCollection<double>> Datasets { get; set; }

		// Holds the JSON file generators values
		public List<Generator> Generators { get; set; }

		// The StartCommand used to execute command from the Main.
		// The method first creates the List of Tasks and each Task perform certain operations defined in generator object.
		// 
		public ICommand StartCommand { get; set; }
		
		// constructor to initialize data		
		public MainViewModel(DataJson dataJson)
        {
			Datasets = dataJson.datasets;
			Generators = dataJson.generators;
			StartCommand = new RelayCommand(Start, CanStart);
		}
			

		private bool CanStart(object obj)
		{
			return true;
		}

		/*
		 * 
		 * The Start method calls when Main call Execute of StartCommand.
		 * The Start method first read Generator and for each generator 
		 * call the required operation on the Datasets, and print the
		 * required results in Console.
		 * 
		 */
		private void Start(object obj)
		{
			List<Task> tasks = new List<Task>();
			foreach(Generator gen in Generators)
			{
				if(gen.operation == "sum")
				{
				  Task task = Task.Run(() =>
					{
						SumTask(gen, Datasets);						
					});

					tasks.Add(task);

				}
				else if(gen.operation == "min")
				{
					Task task = Task.Run(() =>
					{
						MinTask(gen, Datasets);
					});

					tasks.Add(task);
				}
				else if (gen.operation == "max")
				{
					Task task = Task.Run(() =>
					{
						MaxTask(gen, Datasets);
					});

					tasks.Add(task);
				}
				else if (gen.operation == "average")
				{
					Task task = Task.Run(() =>
					{
						AvgTask(gen, Datasets);
					});

					tasks.Add(task);
				}
			}

			// Wait for all the tasks.

			foreach(Task task in tasks)
			{
				task.Wait();
			}

		}

		// Perform Sum on each Datasets on Each interval defined on the Generator object
		private void SumTask(Generator gen, ObservableCollection<ObservableCollection<double>> ds)
		{
			while(true)
			{
				foreach(var datas in ds)
				{
					double sum = datas.Sum();					
					Console.WriteLine(GeneratorResponse.logString(gen.name, sum));					
					Thread.Sleep(gen.interval * 1000);
				}
				
			}
		}

		// Perform Minimum on each Datasets on Each interval defined on the Generator object
		private void MinTask(Generator gen, ObservableCollection<ObservableCollection<double>> ds)
		{
			while (true)
			{
				foreach (var datas in ds)
				{
					double min = datas.Min();
					Console.WriteLine(GeneratorResponse.logString(gen.name, min));
					Thread.Sleep(gen.interval * 1000);				
				}

			}
		}

		// Perform Maximum on each Datasets on Each interval defined on the Generator object
		private void MaxTask(Generator gen, ObservableCollection<ObservableCollection<double>> ds)
		{
			while (true)
			{
				foreach (var datas in ds)
				{
					double max = datas.Max();
					Console.WriteLine(GeneratorResponse.logString(gen.name, max));
					Thread.Sleep(gen.interval * 1000);
				}

			}
		}

		// Perform Average on each Datasets on Each interval defined on the Generator object
		private void AvgTask(Generator gen, ObservableCollection<ObservableCollection<double>> ds)
		{
			while (true)
			{
				foreach (var datas in ds)
				{
					double avg = datas.Average();
					Console.WriteLine(GeneratorResponse.logString(gen.name, avg));
					Thread.Sleep(gen.interval * 1000);
				}
			}
		}

		
	}
}

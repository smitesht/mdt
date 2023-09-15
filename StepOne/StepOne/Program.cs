using StepOne.Commands;
using StepOne.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StepOne
{
	internal class Program
	{
		/*
		 * 
		 * The Main first read the data.json file from the current folder.
		 * If the file not exist, it display error. 
		 * If the file exist, try to read the JSON file in required format,
		 * If the JSON file in differennt format display error.
		 * 
		 * If the file format is correct, it Deserialize JSON file to DataJson object,
		 * then create MainViewModel object and pass the DataJson fields (datasets and operations) 
		 * to the MainViewModel.
		 * 
		 * After successfully pass the data, the Main method call the execute method of the StartCommand,
		 * the execute calls the Start method of the StartCommand and perform all the required operations.
		 * 
		 * Main => StartCommand => execute() => MainViewModel::Start()
		 * 
		 */

		static void Main(string[] args)
		{
			try
			{
				string filename = @"data.json";

				if(File.Exists(filename))
				{
					string jsonString = File.ReadAllText(@"data.json");
					DataJson dataJson = JsonSerializer.Deserialize<DataJson>(jsonString);
					if(dataJson == null || dataJson.datasets.Count <= 0 || dataJson.generators.Count <= 0 )
					{
						Console.WriteLine("Please use correct data.json file");
						Console.ReadLine();
					}
					MainViewModel mainViewModel = new MainViewModel(dataJson);
					mainViewModel.StartCommand.Execute(null);
				}
				else
				{
					Console.WriteLine("Not able to find data.json file, please place the data.json file at current directory");
					Console.ReadLine();
				}

				
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.ReadLine();
			}
		}
	}
}

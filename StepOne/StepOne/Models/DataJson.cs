using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepOne.Commands
{
	/*
	 * This class is used to perform Deserialization of the JSON file.
	 * The class contains datasets and generators properties for the JSON file.
	 * 
	 * 
	 */
	public class DataJson
	{
		
		public ObservableCollection<ObservableCollection<double>> datasets { get; set; }
		public List<Generator> generators { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StepTwo.Moodels
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
		public ObservableCollection<Generator> generators { get; set; }
	}
}

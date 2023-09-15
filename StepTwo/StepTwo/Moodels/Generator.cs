using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepTwo.Moodels
{
	/*
	 * 
	 * This class is used for the generator properties.
	 * While deserializing file the class can be used to hold the 
	 * correspondance data.
	 * 
	 */
	public class Generator
	{
		public Generator()
		{

		}
		public string name { get; set; }
		public int interval { get; set; }
		public string operation { get; set; }
	}
}

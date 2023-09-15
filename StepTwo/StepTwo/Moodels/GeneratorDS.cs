using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepTwo.Moodels
{
	// This class used in ViewModel for the easy representation for the view.
	public class GeneratorDS
	{
		public GeneratorDS()
		{

		}

		public GeneratorDS(int id, string name, string op, int interval)
		{
			Id = id;
			this.name = name;
			operation = op;
			this.interval = interval;
		}

		public int Id { get; set; }
		public string name { get; set; }
		public int interval { get; set; }
		public string operation { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepTwo.Moodels
{
	// This class used to display resuult in a view
	public class OutputMessage
	{
		private string _outputMessage;

        public OutputMessage()
        {
            
        }
        public string OutputMsg
		{
			get { return _outputMessage; }
			set { _outputMessage = value; }
		}
		
	}
}

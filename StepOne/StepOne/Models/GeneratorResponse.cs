using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepOne.Models
{
	/*
	 * 
	 * This is a utility class used to print the output in the required format.
	 * The class contains logString static method that takes generator name and result,
	 * and print the output in required format.
	 * 
	 * for ex, 13:53:39 Gen1 10.4
	 *         CurrentTimeStamp GenName Result
	 * 
	 */

	public class GeneratorResponse
	{
		public static string logString(string name, double result)
		{
			DateTime timestamp = DateTime.Now;
			string strTimestamp = timestamp.ToString("HH:mm:ss");
			return strTimestamp + " " + name + " " + result;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepTwo.Moodels
{
    /* 
     * 
     * This class is correspondence to dataset of the JSON and use in ViewModel as a Model for dataset
     *
     * The class also takes dataset values in double list and convert into string for easy represent in 
     * View. 
     * 
     * The dataset values convert to string with comma delimeter. 
     * for example {1,3,4,5} ==> "1,3,4,5"
     * 
     */

	public class Dataset
	{
        public int Id { get; set; }

        private string _values = "";
        public string Values 
        { 
            get { return _values; } 
            set { _values = value; convertStrintToArry(_values); }
        }

        public ObservableCollection<double> dataset { get; set; }

        public Dataset(int id, ObservableCollection<double> ds)
        {
            Id = id;
            dataset = ds;
            convertToString(ds);
		}

        // Convert to string with comma delimeter
        public void convertToString(ObservableCollection<double> ds)
        {
			Values = string.Join(",", ds);

        }

        // convert back to double list
        private void convertStrintToArry(string str)
        {
            string [] arr = str.Split(',');
			
            ObservableCollection<double> darr = new ObservableCollection<double>();

			foreach (string item in arr)
            {
                double value = Convert.ToDouble(item);
                darr.Add(value);
            }

			dataset = darr;


		}



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StepOne.Commands
{

	/*
	 * The RelayCommand class implement the ICommand interface 
	 * that can be used to execute the require command method to perform certain operation
	 * 
	 */

	public class RelayCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		// The action delegate used to execute method
		private Action<object> _execute;

		// The Predicate can be used whether we need to execute method or not based on given condition.
		// It can also be used to enable/diable button when used in UI.
		private Predicate<object> _predicate;

        public RelayCommand(Action<object> execute, Predicate<object> predicate)
        {
            _execute = execute;
			_predicate = predicate;
        }

        public bool CanExecute(object parameter)
		{
			return _predicate(parameter);
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}
	}
}

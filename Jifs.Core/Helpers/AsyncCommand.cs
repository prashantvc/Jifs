using System;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Helpers
{

	internal class AsyncCommand : ICommand
	{
		private readonly Func<Task> _execute;
		private readonly Predicate<object> _canExecute;
		private bool _isExecuting;

		public AsyncCommand(Func<Task> execute) : this(execute, p => true)
		{
		}

		public AsyncCommand(Func<Task> execute, Predicate<object> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute (parameter);
		}

		public event EventHandler CanExecuteChanged;

		public async void Execute(object parameter)
		{
			_isExecuting = true;
			OnCanExecuteChanged();
			try
			{
				await _execute();
			}
			finally
			{
				_isExecuting = false;
				OnCanExecuteChanged();
			}
		}

		public void OnCanExecuteChanged()
		{
			if (CanExecuteChanged != null) CanExecuteChanged(this, new EventArgs());
		}
	}
}

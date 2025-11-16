using System;
using System.Windows.Input;

namespace Xv2CoreLib.Resource.UndoRedo
{
	#if !SaveEditor
	public sealed class RelayCommand : ICommand
	{
		private readonly Action execute;
		private readonly Func<bool> canExecute;

		public RelayCommand(Action execute, Func<bool> canExecute = null)
		{
			this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter) => canExecute?.Invoke() ?? true;

		public void Execute(object parameter) => execute();

		public event EventHandler CanExecuteChanged;

		public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
	}
	#endif
}


using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModels
{

	class BaseViewModel : INotifyPropertyChanged
	{
		bool isBusy;

		public bool IsBusy {
			get {
				return isBusy;
			}
			set {
				isBusy = value;
				OnPropertyChanged ();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler (this, new PropertyChangedEventArgs (propertyName));
		}

	}
	
}

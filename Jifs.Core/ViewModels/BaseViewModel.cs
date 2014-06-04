using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModels
{

	class BaseViewModel : INotifyPropertyChanged
	{
		public const string TitlePropertyName = "Title";
		public const string IconPropertyName = "Icon";


		string icon;
		public string Icon {
			get { return icon; }
			set {
				icon = value;
				OnPropertyChanged ();
			}
		}

		string title;
		public string Title {
			get { return title; }
			set {
				title = value;
				OnPropertyChanged ();
			}
		}

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

using System;
using System.Windows.Input;
using Helpers;
using System.Threading.Tasks;
using Jifs;

namespace ViewModels
{
	class TranslateViewModel : BaseViewModel
	{
		public string TranslateText {
			get {
				return translateText;
			}
			set {
				translateText = value;
				Translate.OnCanExecuteChanged ();
			}
		}

		bool Method (object obj)
		{
			return !string.IsNullOrEmpty (TranslateText);
		}

		public AsyncCommand Translate {
			get {
				return translateCommand ??
				(translateCommand = new AsyncCommand (TranslateHandler, 
		                                        Method));
			}
		}

		async Task TranslateHandler ()
		{
			return;
		}

		string translateText;
		AsyncCommand translateCommand;
	}

}


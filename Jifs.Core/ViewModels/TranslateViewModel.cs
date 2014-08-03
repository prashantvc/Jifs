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

		public string ImageUrl {
			get{ return imageUrl; }
			set {
				imageUrl = value;
				OnPropertyChanged ();
			}
		}

		public string MediaUrl {
			get{ return mediaUrl; }
			set {
				mediaUrl = value;
				OnPropertyChanged ();
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
			if (string.IsNullOrEmpty (TranslateText)) {
				return;
			}

			var image = await App.Context.TranslateAsync (TranslateText);
			MediaUrl = image.data.images.fixed_width.url;

		}

		string translateText;
		string imageUrl;
		string mediaUrl;
		AsyncCommand translateCommand;
	}

}


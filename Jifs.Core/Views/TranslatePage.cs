using System;
using Xamarin.Forms;
using ViewModels;

namespace Jifs.Views
{

	class TranslatePage: ContentPage
	{
		public TranslatePage ()
		{
			Title = "Translator";
			Icon = "microphone.png";


			BindingContext = new TranslateViewModel ();

			var text = new Entry { 
				Keyboard = Keyboard.Chat,
				Placeholder = "Words and phrases to GIF"
			};
			text.SetBinding (Entry.TextProperty, "TranslateText");


			var translateButton = new Button { 
				Text = "Translate",
				BackgroundColor = Helpers.Color.Green.ToFormsColor (),
				TextColor = Color.White
			};
			translateButton.SetBinding (Button.CommandProperty, "Translate");

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = 20, 
				Children = { text, translateButton }
			};
		}
	}
}

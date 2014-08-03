using System;
using Xamarin.Forms;
using ViewModels;
using Xamarin.Forms.Labs;

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

			var animatedImage = new GifImage {
				HeightRequest = 200,
				WidthRequest = 300,
				//BackgroundColor = Color.Blue
			};
			animatedImage.SetBinding (GifImage.SourceProperty, "MediaUrl");

			var translateButton = new Button { 
				Text = "Translate"
			};
			translateButton.SetBinding (Button.CommandProperty, "Translate");

			Content = new ScrollView {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.StartAndExpand,
					Padding = 20, 
					Children = { text, translateButton, animatedImage }
				}
			};
		}
	}
}

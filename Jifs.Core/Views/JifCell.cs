using System;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Labs;
using Jifs.Model;
using Image = Xamarin.Forms.Image;

namespace Jifs.Views
{
	class JifImageCell : ViewCell{
		GifImage gifImage;

		public JifImageCell ()
		{
			gifImage = new GifImage {
				MinimumWidthRequest = 320,
				MinimumHeightRequest = 200,
			};
			gifImage.SetBinding (GifImage.SourceProperty, "images.fixed_width.url");

			View = gifImage;
		}
	}

	class JifCell : ViewCell
	{

		Image image;
		Grid grid;
		Video videoView;
		GifImage gifImage;


		public JifCell ()
		{
			image = new Image {
				Aspect = Aspect.AspectFill,
				HeightRequest = 200,
				WidthRequest = 320
			};

			videoView = new Video{ 
				WidthRequest = 320,
				HeightRequest = 200,
				ShowMediaControls = false,
				CanLoop = true,
				ShouldAutoPlay = false
			};

			videoView.IsVisible = false;

			gifImage = new GifImage {
				WidthRequest = 320,
				HeightRequest = 200,
			};
			gifImage.IsVisible = false;

			image.SetBinding (Image.SourceProperty, "images.fixed_width_still.url");

			var indicator = new ActivityIndicator { Color = new Color (.5), };
			indicator.SetBinding (ActivityIndicator.IsRunningProperty, "IsLoading");
			indicator.BindingContext = image;


			grid = new Grid ();
			grid.RowDefinitions.Add (new RowDefinition ());
			grid.Children.Add (videoView);
			//grid.Children.Add (gifImage);
			grid.Children.Add (image);
			grid.Children.Add (indicator);


			View = grid;
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			image.IsVisible = true;
			//gifImage.IsVisible = false;
			if (videoView != null) {
				videoView.Stop ();
				videoView.IsVisible = false;
			}
		}

		protected override void OnTapped ()
		{
			base.OnTapped ();
			image.IsVisible = false;
			videoView.SetValue (Video.SourceProperty, Context.images.fixed_width.mp4);
			videoView.IsVisible = true;
			videoView.Play ();

		}

		Datum Context {
			get {
				return (Datum)BindingContext; 
			}
		}

	}
}
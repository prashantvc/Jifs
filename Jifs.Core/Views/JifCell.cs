using System;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Labs;
using Jifs.Model;
using Image = Xamarin.Forms.Image;

namespace Jifs.Views
{
	class JifCell : ViewCell
	{

		Image image;
		Grid grid;
		Video videoView;

		public JifCell ()
		{
			image = new Image {
				Aspect = Aspect.AspectFill,
				HeightRequest = 200,
				WidthRequest = 320
			};

			image.SetBinding (Image.SourceProperty, "images.fixed_width_still.url");

			var indicator = new ActivityIndicator { Color = new Color (.5), };
			indicator.SetBinding (ActivityIndicator.IsRunningProperty, "IsLoading");
			indicator.BindingContext = image;


			grid = new Grid ();
			grid.RowDefinitions.Add (new RowDefinition ());
			grid.Children.Add (image);
			grid.Children.Add (indicator);

			View = grid;
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			image.IsVisible = true;
			if (videoView != null) {
				videoView.Stop ();
				videoView.IsVisible = false;
			}
		}

		protected override void OnTapped ()
		{
			base.OnTapped ();
			image.IsVisible = false;

			videoView.Play ();
		}

		Datum Context {
			get{
				return (Datum)BindingContext; 
			}
		}
	}
}
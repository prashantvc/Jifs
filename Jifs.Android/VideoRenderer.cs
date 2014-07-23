using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Uri = Android.Net.Uri;

[assembly: ExportRenderer (typeof(Video), typeof(VideoRenderer))]

namespace Xamarin.Forms.Labs
{
	public class VideoRenderer : ViewRenderer<Video, VideoView>
	{
	
		protected override void OnElementChanged (ElementChangedEventArgs<Video> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {

				var element = e.NewElement;

				var view = new VideoView (Context);

				view.SetX (0);
				view.SetY (0);
				view.SetMinimumHeight ((int)element.MinimumHeightRequest);
				view.SetMinimumWidth ((int)element.MinimumWidthRequest);

				SetNativeControl (view);
			}

			SetSource ();
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == Video.SourceProperty.PropertyName) {
				SetSource ();
			}
		}

		void SetSource ()
		{
			if (string.IsNullOrEmpty (Element.Source)) {
				return;
			}

			var uri = Uri.Parse (Element.Source);
			Control.SetVideoURI (uri);
			Control.Start ();
		}

	}
}


using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Jifs.iOS;
using Xamarin.Forms.Platform.iOS;
using FLAnimation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;


[assembly: ExportRenderer (typeof(GifImage), typeof(GifImageRenderer))]
namespace Jifs.iOS
{
	public class GifImageRenderer : ViewRenderer<GifImage, FLAnimatedImageView>
	{
		protected override void OnElementChanged (ElementChangedEventArgs<GifImage> e)
		{
			base.OnElementChanged (e);

			var imageView = new FLAnimatedImageView {
				ContentMode = UIViewContentMode.ScaleAspectFill,
				ClipsToBounds = true,
				Frame = new RectangleF (0, 0, (float)Element.WidthRequest, (float)Element.HeightRequest)
			};

			imageView.Layer.BorderColor = UIColor.Red.CGColor;
			imageView.Layer.BorderWidth = 2;

			SetNativeControl (imageView);
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == GifImage.SourceProperty.PropertyName) {
				var url = NSUrl.FromString (Element.Source);
				var data = NSData.FromUrl (url);
				var animatedImage = new FLAnimatedImage (data);
				Control.AnimatedImage = animatedImage;
			}
		}
	}
}


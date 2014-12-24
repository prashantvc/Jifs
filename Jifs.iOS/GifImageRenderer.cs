using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Jifs.iOS;
using Xamarin.Forms.Platform.iOS;
using FLAnimation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;
using SDWebImage;


[assembly: ExportRenderer (typeof(GifImage), typeof(GifImageRenderer))]
namespace Jifs.iOS
{
	public class GifImageRenderer : ViewRenderer<GifImage, FLAnimatedImageView>
	{
		protected override void OnElementChanged (ElementChangedEventArgs<GifImage> e)
		{
			base.OnElementChanged (e);
			if (Control == null) {
				var imageView = new FLAnimatedImageView {
					ContentMode = UIViewContentMode.ScaleAspectFill,
					ClipsToBounds = true,
					Frame = new RectangleF (0, 0, (float)Element.WidthRequest, (float)Element.HeightRequest)
				};

				imageView.Layer.BorderColor = UIColor.Red.CGColor;
				imageView.Layer.BorderWidth = 2;

				SetNativeControl (imageView);
			}

		}

		protected async override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == GifImage.SourceProperty.PropertyName) {

				System.Console.WriteLine (Element.Source);
				var url = NSUrl.FromString (Element.Source);

				var request = new NSMutableUrlRequest (url);
				var response = cache.CachedResponseForRequest (request);
				FLAnimatedImage animatedImage = null;

				if (response != null) {
					animatedImage = new FLAnimatedImage (response.Data);
					Control.AnimatedImage = animatedImage;
					return;
				}

				var urlResponse = await NSUrlConnection.SendRequestAsync (request, NSOperationQueue.MainQueue);
				cache.StoreCachedResponse (new NSCachedUrlResponse (urlResponse.Response, urlResponse.Data), request);

				animatedImage = new FLAnimatedImage (urlResponse.Data);
				Control.AnimatedImage = animatedImage;
			}
		}

		readonly NSUrlCache cache = NSUrlCache.SharedCache;
	}
}


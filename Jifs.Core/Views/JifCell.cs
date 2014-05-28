using System;
using Xamarin.Forms;

namespace Jifs.Views
{
	class JifCell : ViewCell
	{
		public JifCell ()
		{
			var image = new Image {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Aspect = Aspect.AspectFill
			};
			image.SetBinding (Image.SourceProperty, "images.fixed_width_still.url");
			View = image;
		}
	}
}


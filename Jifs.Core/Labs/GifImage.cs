using System;
using Xamarin.Forms;

namespace Xamarin.Forms.Labs
{
	public class GifImage : View
	{
		public static readonly BindableProperty SourceProperty =
			BindableProperty.Create ("Source", typeof(string), typeof(GifImage), string.Empty);

		public string Source {
			get{ return (string)GetValue (SourceProperty); }
			set {
				SetValue (SourceProperty, value);
			}
		}
	}
}


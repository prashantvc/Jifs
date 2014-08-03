using System;
using Xamarin.Forms;

namespace Xamarin.Forms.Labs
{
	public class Video : View
	{
		public void Stop ()
		{
			OnPropertyChanged("Stop");
		}

	
		public static readonly BindableProperty ShowControlsProperty =
			BindableProperty.Create ("ShowControls", typeof(bool), typeof(Video), true);

		public bool ShowMediaControls {
			get{ return (bool)GetValue (ShowControlsProperty); }
			set{ SetValue (ShowControlsProperty, value); }
		}

		public static readonly BindableProperty SourceProperty =
			BindableProperty.Create ("Source", typeof(string), typeof(Video), string.Empty);

		public string Source {
			get{ return (string)GetValue (SourceProperty); }
			set {
				SetValue (SourceProperty, value);
			}
		}

		public static readonly BindableProperty ShoudAutoPlayProperty = 
			BindableProperty.Create ("ShouldAutoPlay", typeof(bool), typeof(Video), true);

		public bool ShouldAutoPlay {
			get { return (bool)GetValue (ShoudAutoPlayProperty); }
			set { SetValue (ShoudAutoPlayProperty, value); }
		}

		public static readonly BindableProperty CanLoopProperty =
			BindableProperty.Create ("CanLoop", typeof(bool), typeof(Video), false);

		public bool CanLoop {
			get { return (bool)GetValue (CanLoopProperty); }
			set { SetValue (CanLoopProperty, value); }
		}

		public void Play ()
		{
			OnPropertyChanged ("Play");
		}
	}
}


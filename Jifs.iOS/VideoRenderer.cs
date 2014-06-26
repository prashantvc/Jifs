using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch;
using MonoTouch.MediaPlayer;
using Xamarin.Forms.Labs;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Xamarin.Forms;

[assembly: ExportRenderer (typeof(Video), typeof(VideoRenderer))]

namespace Xamarin.Forms.Labs
{
	public class VideoRenderer : ViewRenderer <Video, UIView>
	{
		void SetSource ()
		{
			if (string.IsNullOrEmpty (Element.Source)) {
				return;
			}

			if (moviePlayer.PlaybackState == MPMoviePlaybackState.Playing) {
				moviePlayer.Stop ();
			}

			moviePlayer.ContentUrl = NSUrl.FromString (Element.Source);
			moviePlayer.Play ();
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Video> e)
		{
			base.OnElementChanged (e);

			moviePlayer = new MPMoviePlayerController ();
			moviePlayer.ShouldAutoplay = true;
			moviePlayer.SourceType = MPMovieSourceType.Streaming; //TODO: Add file streaming too
			moviePlayer.View.Frame = new System.Drawing.RectangleF (0, 0, (float)Element.MinimumWidthRequest, (float)Element.MinimumHeightRequest);

			SetNativeControl (moviePlayer.View);

			SetMediaControls ();
			SetAutoPlayStatus ();
			SetLoopState ();
			SetSource ();
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == Video.SourceProperty.PropertyName) {
				SetSource ();
			} else if (e.PropertyName == Video.ShoudAutoPlayProperty.PropertyName) {
				SetAutoPlayStatus ();
			} else if (e.PropertyName == Video.ShoudAutoPlayProperty.PropertyName) {
				SetAutoPlayStatus ();
			}else if (e.PropertyName == Video.CanLoopProperty.PropertyName) {
				SetLoopState ();
			}
		}

		void SetMediaControls ()
		{
			moviePlayer.ControlStyle = Element.ShowMediaControls ? 
				MPMovieControlStyle.Default : MPMovieControlStyle.None;
		}

		void SetAutoPlayStatus ()
		{
			moviePlayer.ShouldAutoplay = Element.ShouldAutoPlay;
		}

		void SetLoopState ()
		{
			moviePlayer.RepeatMode = Element.CanLoop ? MPMovieRepeatMode.One : MPMovieRepeatMode.None;
		}

		MPMoviePlayerController moviePlayer;
	}
}


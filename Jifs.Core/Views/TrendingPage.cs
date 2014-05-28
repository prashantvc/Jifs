using System;
using Xamarin.Forms;

namespace Jifs.Views
{
	class TrendingPage : ContentPage
	{
		public TrendingPage ()
		{
			Title = "Trending";

			var imageList = new ListView {
				RowHeight = 40
			};

			imageList.SetBinding (ListView.ItemsSourceProperty, "TrendingItems");

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { imageList }
			};
		}
	}

}


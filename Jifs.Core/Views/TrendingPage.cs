using System;
using Xamarin.Forms;

namespace Jifs.Views
{
	class TrendingPage : ContentPage
	{
		public TrendingPage ()
		{
			Title = "Trending";
			Icon = "uptrend.png";

			var imageList = new ListView {
				RowHeight = 200
			};

			imageList.SetBinding (ListView.ItemsSourceProperty, "TrendingItems");
			imageList.ItemTemplate = new DataTemplate (typeof(JifCell));

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { imageList }
			};
		}
	}

}


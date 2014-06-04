using System;
using Xamarin.Forms;
using ViewModels;

namespace Jifs.Views
{
	class TrendingPage : ContentPage
	{
		public TrendingPage ()
		{
			Title = "Trending";

			BindingContext = new TrendingViewModel ();

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


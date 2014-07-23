using System;
using Xamarin.Forms;
using ViewModels;

namespace Jifs.Views
{
	class SearchPage : ContentPage
	{
		public SearchPage ()
		{
			Title = "Search";
			Icon = "search.png";

			BindingContext = new SearchViewModel ();

			SetupContent ();
		}

		void SetupContent ()
		{
			var search = new SearchBar ();
			search.SetBinding (SearchBar.SearchCommandProperty, "SearchCommand");
			search.SetBinding (SearchBar.TextProperty, "SearchText");


			var results = new ListView {
				RowHeight = 200
			};
			results.SetBinding (ListView.ItemsSourceProperty, "Results");
			results.ItemTemplate = new DataTemplate (typeof(JifCell));

			Content = new StackLayout { 
				Children = { search, results }
			};
		}
	}
}

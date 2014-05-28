using Jifs.Views;
using Xamarin.Forms;
using ViewModels;

namespace Jifs
{
	public static class App
	{
		public static Page GetMainPage ()
		{
			var trendingPage = new TrendingPage {
				BindingContext = new TrendingViewModel ()
			};

			var searchPage = new SearchPage ();

			return new TabbedPage { 
				Children = { trendingPage, searchPage }
			};
		}
	}
}
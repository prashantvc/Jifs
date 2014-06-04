using Jifs.Views;
using Xamarin.Forms;
using ViewModels;
using Views;

namespace Jifs
{
	public static class App
	{
		public static Page GetMainPage ()
		{
//			var trendingPage = new TrendingPage {
//				BindingContext = new TrendingViewModel ()
//			};
//
//			var searchPage = new SearchPage ();
//
//			return new TabbedPage { 
//				Children = { trendingPage, searchPage }
//			};

			return new MainPage ();
		}
	}
}
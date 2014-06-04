using Jifs.Views;
using Xamarin.Forms;
using ViewModels;
using Views;

namespace Jifs
{
	public static class App
	{
		static MainPage mainPage;

		public static Page GetMainPage ()
		{
			return mainPage ?? (mainPage = new MainPage ());
		}
	}
}
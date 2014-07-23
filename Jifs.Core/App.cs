using Jifs.Views;
using Xamarin.Forms;
using ViewModels;
using Views;

namespace Jifs
{
	public static class App
	{
		static MainPage mainPage;
		static JifContext context;

		public static Page GetMainPage ()
		{
			return mainPage ?? (mainPage = new MainPage ());
		}

		public static JifContext Context{
			get{ 
				return context ?? (context = new JifContext ());
			}
		}
	}
}
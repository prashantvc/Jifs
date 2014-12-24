using System;
using Xamarin.Forms;
using ViewModels;
using System.Collections.ObjectModel;
using Model;

namespace ViewModels
{
	class MainViewModel : BaseViewModel
	{
		public ObservableCollection<Menu> MenuItems {
			get;
			set;
		}

		public MainViewModel ()
		{
			Title = "Jifs";
			Icon = "slideout.png";
			MenuItems = new ObservableCollection<Menu> { 
				new Menu(MenuType.Trending, "Trending", "uptrend.png"),
				new Menu(MenuType.Translate, "Translator", "microphone.png"),
				new Menu(MenuType.Search, "Search", "search.png")
			};
		}
	}

}


using System;
using Xamarin.Forms;
using ViewModels;
using System.Collections.ObjectModel;
using Model;

namespace ViewModels
{
	class MainViewModel : BaseViewModel
	{
		public ObservableCollection<MenuItem> MenuItems {
			get;
			set;
		}

		public MainViewModel ()
		{
			Title = "Jifs";
			Icon = "slideout.png";
			MenuItems = new ObservableCollection<MenuItem> { 
				new MenuItem(MenuType.Trending, "Trending", "uptrend.png"),
				new MenuItem(MenuType.Translate, "Translate", "microphone.png"),
				new MenuItem(MenuType.Search, "Search", string.Empty)
			};
		}
	}

}


using System;
using Xamarin.Forms;
using ViewModels;
using System.Collections.ObjectModel;

namespace Model
{
	class MenuItem
	{
		public MenuItem (MenuType menuType, string title, string icon)
		{
			MenuType = menuType;
			Title = title;
			Icon = icon;
		}

		public string Icon {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}


		public MenuType MenuType {
			get;
			set;
		}
	}

	enum MenuType
	{
		Trending,
		Search,
		Translate
	}
}


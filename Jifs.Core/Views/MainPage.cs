using System;
using Xamarin.Forms;
using ViewModels;
using Jifs.Views;
using Model;

namespace Views
{
	class MainPage : MasterDetailPage
	{
		public MainPage ()
		{
			BindingContext = new MainViewModel ();
			Master = masterPage = new MainMasterView (BindingContext as MainViewModel);

			Detail = Trends;

			masterPage.SelectedMenuChange += (sender, e) => {
				var seletedItem = e.SelectedItem as Menu;
				if (seletedItem == null) {
					return;
				}

				switch (seletedItem.MenuType) {
				case MenuType.Search:
					Detail = Search;
					break;
				case MenuType.Trending:
					Detail = Trends;
					break;
				case MenuType.Translate:
					Detail = Translate;
					break;
				}

				IsPresented = false;
			};

		}
			

		Menu SelectedItem { get; set; }

		Page Trends {
			get {
				return trendingPage ?? (trendingPage = GetDetailPage (new TrendingPage ()));
			}
		}

		Page Search {
			get {
				return searchPage ?? (searchPage = GetDetailPage (new SearchPage ()));
			}
		}

		Page Translate {
			get {
				return translatePage ?? (translatePage = GetDetailPage (new TranslatePage ()));
			}
		}

		Page trendingPage;
		Page searchPage;
		Page translatePage;

		static Page GetDetailPage (Page page)
		{
			return new NavigationPage (page) {
				Tint = Helpers.Color.LightGray.ToFormsColor ()
			};
		}

		readonly MainMasterView masterPage;

		class MainMasterView : BaseView
		{
			public MainMasterView (MainViewModel mainViewModel)
			{
				BindingContext = mainViewModel;

				var layout = new StackLayout { Spacing = 0 };

				var label = new ContentView {
					Padding = new Thickness (10, 36, 0, 5),
					BackgroundColor = Color.Transparent,
					Content = new Label {
						Text = "JIFS",
						Font = Font.SystemFontOfSize (NamedSize.Medium)
					}
				};

				layout.Children.Add (label);

				listView = new ListView ();
				var cell = new DataTemplate (typeof(ImageCell));
				cell.SetBinding (TextCell.TextProperty, BaseViewModel.TitlePropertyName);
				cell.SetBinding (ImageCell.ImageSourceProperty, "Icon");

				listView.ItemTemplate = cell;
				listView.ItemsSource = mainViewModel.MenuItems;

				layout.Children.Add (listView);
				Content = layout;
			}

			public event EventHandler<SelectedItemChangedEventArgs> SelectedMenuChange {
				add {
					if (listView != null) {
						listView.ItemSelected += value;
					}
				}
				remove {
					if (listView != null) {
						listView.ItemSelected -= value;
					}
				}
			}

			readonly ListView listView;
		}
	}
}


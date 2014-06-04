using System;
using Xamarin.Forms;
using ViewModels;
using Jifs.Views;

namespace Views
{
	public class MainPage : MasterDetailPage
	{
		public MainPage ()
		{
			BindingContext = new MainViewModel ();
			Master = new MainMasterView (BindingContext as MainViewModel);
			var homeNav = new NavigationPage (new TrendingPage { BindingContext = new TrendingViewModel () }) {
				Tint = Helpers.Color.DarkBlue.ToFormsColor ()
			};
			Detail = homeNav;

		}

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

				var listView = new ListView ();
				var cell = new DataTemplate (typeof(ImageCell));
				cell.SetBinding (TextCell.TextProperty, BaseViewModel.TitlePropertyName);
				cell.SetBinding (ImageCell.ImageSourceProperty, "Icon");

				listView.ItemTemplate = cell;
				listView.ItemsSource = mainViewModel.MenuItems;
				layout.Children.Add (listView);

				Content = layout;
			}
		}
	}
}


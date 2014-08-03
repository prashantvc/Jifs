using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Jifs.Model;
using Jifs;
using System.Diagnostics;

namespace ViewModels
{

	class TrendingViewModel : BaseViewModel
	{
		JifContext context;

		public TrendingViewModel ()
		{
			context = App.Context;

			LoadTrendingItems ();
		}

		async void LoadTrendingItems ()
		{
			IsBusy = true;
			var items = await context.GetTrendingAsync ();

			TrendingItems = items.data;
		}

		Datum[] trendingItems;
		public Datum[] TrendingItems {
			get {
				return trendingItems;
			}
			set {
				trendingItems = value;
				OnPropertyChanged ();
			}
		}
	}
}


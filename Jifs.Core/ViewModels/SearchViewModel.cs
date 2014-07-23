using System;
using Xamarin.Forms;
using Jifs.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Helpers;
using System.Threading.Tasks;
using Jifs;

namespace ViewModels
{
	class SearchViewModel : BaseViewModel
	{

		ICommand search;
		Datum[] results;


		public string SearchText { get; set;}

		public Datum[] Results{
			get{
				return results;
			}
			set{
				results = value;
				OnPropertyChanged ();
			}
		}

		public ICommand SearchCommand {
			get {
				return search ?? (search = new AsyncCommand (SearchCommandHandler));
			}
		}

		async Task SearchCommandHandler ()
		{
			if (string.IsNullOrWhiteSpace(SearchText)) {
				return;
			}

			var root = await App.Context.SearchAsync (SearchText);
			Results = root.data;
		}

	}
}


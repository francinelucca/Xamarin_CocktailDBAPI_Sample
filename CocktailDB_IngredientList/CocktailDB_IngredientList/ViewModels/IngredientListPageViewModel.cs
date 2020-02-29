using CocktailDB_IngredientList.Models;
using CocktailDB_IngredientList.Services;
using CocktailDB_IngredientList.Utils;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CocktailDB_IngredientList.ViewModels
{
	public class IngredientListPageViewModel : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		IIngredientAPIService _apiService;
		public ObservableCollection<Ingredient> Ingredients { get; set; }

		public bool IsLoading { get; set; }

		public IngredientListPageViewModel()
		{
		// Comment and UnComment following lines to alternate between HttpClient and Refit for API Service.
		//	_apiService = new IngredientAPIService();
			_apiService = RestService.For<IIngredientAPIService>(Constants.CocktailAPIBaseUrl);
			GetIngredients();
		}

		public async void GetIngredients()
		{
			if (await CheckForInternetConnection())
			{
				try
				{
					IsLoading = true;
					var response = await _apiService.GetIngredientsAsync();

					Ingredients = response != null ? new ObservableCollection<Ingredient>(response.Ingredients.OrderBy(i => i.Name)) : new ObservableCollection<Ingredient>();
					IsLoading = false;
				}
				catch (Exception e)
				{
					IsLoading = false;
					await App.Current.MainPage.DisplayAlert("An Error Occured", e.Message, "OK");
				}
			}

		}

		public async Task<bool> CheckForInternetConnection()
		{
			bool HasInternet = true;
			if (Connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				HasInternet = false;
				await App.Current.MainPage.DisplayAlert("No Internet Connection", "Can not get RNC information because there is no internet connection available. Please connect to the internet and try again.", "OK");
			}
			return HasInternet;

		}
	}
}

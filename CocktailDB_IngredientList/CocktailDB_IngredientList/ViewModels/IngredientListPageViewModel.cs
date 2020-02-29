using CocktailDB_IngredientList.Models;
using CocktailDB_IngredientList.Services;
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

		IAPIService _apiService = new APIService();
		public ObservableCollection<Ingredient> Ingredients { get; set; }

		public IngredientListPageViewModel()
		{
			GetIngredients();
		}

		public async void GetIngredients()
		{
			if (await CheckForInternetConnection())
			{
				try
				{
					Ingredients = new ObservableCollection<Ingredient>((await _apiService.GetIngredientsAsync()).OrderBy(i => i.Name));

				}
				catch (Exception e)
				{
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

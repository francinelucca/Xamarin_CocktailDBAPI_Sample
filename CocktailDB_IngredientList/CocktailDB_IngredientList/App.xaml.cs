using CocktailDB_IngredientList.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailDB_IngredientList
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new IngredientListPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}

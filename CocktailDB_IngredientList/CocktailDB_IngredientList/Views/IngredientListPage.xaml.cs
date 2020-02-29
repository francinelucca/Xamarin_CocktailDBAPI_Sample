using CocktailDB_IngredientList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailDB_IngredientList.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IngredientListPage : ContentPage
	{
		public IngredientListPage()
		{
			InitializeComponent();
			this.BindingContext = new IngredientListPageViewModel();
		}
	}
}
using CocktailDB_IngredientList.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDB_IngredientList.Services
{
	public interface IIngredientAPIService
	{
		[Get("/api/json/v1/1/list.php?i=list")]
		Task<IngredientListAPIResponse> GetIngredientsAsync();
	}
}

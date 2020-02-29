using CocktailDB_IngredientList.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDB_IngredientList.Services
{
	public interface IAPIService
	{
		Task<List<Ingredient>> GetIngredientsAsync();
	}
}

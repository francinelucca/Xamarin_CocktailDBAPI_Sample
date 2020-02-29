using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailDB_IngredientList.Models
{
	public class Ingredient
	{
		[JsonProperty(PropertyName = "strIngredient1")]
		public string Name { get; set; }
	}
	public class IngredientListAPIResponse
	{
		[JsonProperty(PropertyName = "drinks")]
		public List<Ingredient> Ingredients { get; set; }
	}
}

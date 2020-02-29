using CocktailDB_IngredientList.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDB_IngredientList.Services
{
	public class APIService : IAPIService
	{
        private const string APIBaseUrl = "https://www.thecocktaildb.com/api/json";
        private const string CurrentAPIVersion = "v1";
        public async Task<List<Ingredient>> GetIngredientsAsync()
        {
            try
            {
                IngredientListAPIResponse ingredientListResponse = null;
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetAsync(String.Format("{0}/{1}/1/list.php?i=list", APIBaseUrl, CurrentAPIVersion));
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    ingredientListResponse = JsonConvert.DeserializeObject<IngredientListAPIResponse>(responseString);
                }
                return ingredientListResponse!=null ?  ingredientListResponse.Ingredients : new List<Ingredient>();
            }
            catch (Exception e)
            {
                throw new Exception("Could not get ingredients information.");
            }
        }
    }
}

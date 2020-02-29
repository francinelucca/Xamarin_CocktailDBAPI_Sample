using CocktailDB_IngredientList.Models;
using CocktailDB_IngredientList.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDB_IngredientList.Services
{
	public class IngredientAPIService : IIngredientAPIService
	{
        public async Task<IngredientListAPIResponse> GetIngredientsAsync()
        {
            try
            {
                IngredientListAPIResponse ingredientListResponse = null;
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetAsync(String.Format("{0}/api/json/{1}/1/list.php?i=list", Constants.CocktailAPIBaseUrl, Constants.CocktailAPICurrentVersion));
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    ingredientListResponse = JsonConvert.DeserializeObject<IngredientListAPIResponse>(responseString);
                }
                return ingredientListResponse;
            }
            catch (Exception e)
            {
                throw new Exception("Could not get ingredients information.");
            }
        }
    }
}

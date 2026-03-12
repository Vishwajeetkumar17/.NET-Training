using MVCProject.Models;
using System.Net.Http.Json;

namespace MVCProject.Services
{
    public class FoodApiService : IFoodApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FoodApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Food>> GetAllFoodsAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("FoodApi");
                return await client.GetFromJsonAsync<List<Food>>("api/Food") ?? new List<Food>();
            }
            catch
            {
                return new List<Food>();
            }
        }

        public async Task<Food?> GetFoodByIdAsync(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("FoodApi"); 
                return await client.GetFromJsonAsync<Food>($"api/Food/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AddFoodAsync(Food food)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("FoodApi");
                var response = await client.PostAsJsonAsync("api/Food", food);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateFoodAsync(int id, Food food)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("FoodApi");
                var response = await client.PutAsJsonAsync($"api/Food/{id}", food);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteFoodAsync(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("FoodApi");
                var response = await client.DeleteAsync($"api/Food/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}

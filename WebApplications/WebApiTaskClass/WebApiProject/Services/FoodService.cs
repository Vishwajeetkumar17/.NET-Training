using TaskClassLibrary.Models;
using WebApiProject.Repositories;

namespace WebApiProject.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepo _repo;

        public FoodService(IFoodRepo repo) => _repo = repo;

        public async Task<List<Food>> GetAllFoodsAsync()
        {
            return await _repo.GetAllFoodsAsync();
        }

        public async Task<Food?> GetFoodByIdAsync(int id)
        {
            return await _repo.GetFoodByIdAsync(id);
        }

        public async Task AddFoodAsync(Food food)
        {
            await _repo.AddFoodAsync(food);
        }

        public async Task UpdateFoodAsync(Food food)
        {
            await _repo.UpdateFoodAsync(food);
        }

        public async Task DeleteFoodAsync(int id)
        {
            await _repo.DeleteFoodByIdAsync(id);
        }
    }
}

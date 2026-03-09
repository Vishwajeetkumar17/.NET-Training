using MVCProject.Models;

namespace MVCProject.Services
{
    public interface IFoodApiService
    {
        Task<List<Food>> GetAllFoodsAsync();
        Task<Food?> GetFoodByIdAsync(int id);
        Task<bool> AddFoodAsync(Food food);
        Task<bool> UpdateFoodAsync(int id, Food food);
        Task<bool> DeleteFoodAsync(int id);
    }
}

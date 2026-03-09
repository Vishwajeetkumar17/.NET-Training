using TaskClassLibrary.Models;

namespace WebApiProject.Repositories
{
    public interface IFoodRepo
    {
        Task<List<Food>> GetAllFoodsAsync();
        Task<Food?> GetFoodByIdAsync(int id);
        Task AddFoodAsync(Food food);
        Task UpdateFoodAsync(Food food);
        Task DeleteFoodByIdAsync(int id);
    }
}

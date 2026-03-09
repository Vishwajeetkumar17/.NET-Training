using TaskClassLibrary.Models;
using System.Threading.Tasks;

namespace WebApiProject.Services
{
    public interface IFoodService
    {
        Task<List<Food>> GetAllFoodsAsync();
        Task<Food?> GetFoodByIdAsync(int id);
        Task AddFoodAsync(Food food);
        Task UpdateFoodAsync(Food food);
        Task DeleteFoodAsync(int id);
    }
}

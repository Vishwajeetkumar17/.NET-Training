using Microsoft.EntityFrameworkCore;
using TaskClassLibrary.Data;
using TaskClassLibrary.Models;

namespace WebApiProject.Repositories
{
    public class FoodRepo : IFoodRepo
    {
        private readonly TrainingDbContext _context;

        public FoodRepo(TrainingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Food>> GetAllFoodsAsync()
        {
            return await _context.Food.ToListAsync();
        }

        public async Task<Food?> GetFoodByIdAsync(int id)
        {
            return await _context.Food.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddFoodAsync(Food food)
        {
            _context.Food.Add(food);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFoodAsync(Food food)
        {
            var existingFood = await _context.Food.FirstOrDefaultAsync(f => f.Id == food.Id);
            if (existingFood == null)
            {
                return;
            }

            existingFood.Name = food.Name;
            existingFood.Price = food.Price;
            existingFood.Quantity = food.Quantity;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodByIdAsync(int id)
        {
            var food = await _context.Food.FirstOrDefaultAsync(f => f.Id == id);
            if (food != null)
            {
                _context.Food.Remove(food);
                await _context.SaveChangesAsync();
            }
        }
    }
}

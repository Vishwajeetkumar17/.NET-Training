using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskClassLibrary.Models;
using WebApiProject.Services;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoods()
        {
            var foods = await _foodService.GetAllFoodsAsync();
            return Ok(foods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            var food = await _foodService.GetFoodByIdAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        [HttpPost]
        public async Task<IActionResult> AddFood([FromBody] Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _foodService.AddFoodAsync(food);
            return CreatedAtAction(nameof(GetFoodById), new { id = food.Id }, food);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(int id, [FromBody] Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != food.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingFood = await _foodService.GetFoodByIdAsync(id);
            if (existingFood == null)
            {
                return NotFound();
            }

            try
            {
                await _foodService.UpdateFoodAsync(food);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }

            return Ok(new
            {
                message = "Food updated successfully",
                data = food
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await _foodService.GetFoodByIdAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            await _foodService.DeleteFoodAsync(id);
            return Ok(new
            {
                message = "Food deleted successfully",
                data = food
            });
        }
    }
}

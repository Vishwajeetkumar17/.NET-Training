using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Services;

namespace MVCProject.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodApiService _foodApiService;

        public FoodController(IFoodApiService foodApiService)
        {
            _foodApiService = foodApiService;
        }

        public async Task<IActionResult> Index()
        {
            var foods = await _foodApiService.GetAllFoodsAsync();
            return View(foods);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Food food)
        {
            if (!ModelState.IsValid)
            {
                return View(food);
            }

            var isCreated = await _foodApiService.AddFoodAsync(food);
            if (!isCreated)
            {
                ModelState.AddModelError(string.Empty, "Unable to create food item.");
                return View(food);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var food = await _foodApiService.GetFoodByIdAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(food);
            }

            var isUpdated = await _foodApiService.UpdateFoodAsync(id, food);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unable to update food item.");
                return View(food);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var food = await _foodApiService.GetFoodByIdAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isDeleted = await _foodApiService.DeleteFoodAsync(id);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

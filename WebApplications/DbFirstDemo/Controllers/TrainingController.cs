using DbFirstDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbFirstDemo.Controllers
{
    public class TrainingController : Controller
    {
        private readonly TrainingDbContext _db;
        public TrainingController(TrainingDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            // Read from DB using scaffolded DbSet
            var list = await _db.Employees
                                .AsNoTracking()
                                .OrderBy(r => r.Salary)
                                .ToListAsync();
            return View(list);
        }
    }
}

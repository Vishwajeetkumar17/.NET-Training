using Microsoft.AspNetCore.Mvc;

namespace MiddleWareProject.Middleware
{
    public class TestController : Controller
    {
        public IActionResult Echo(string q, string ans)
        {
            return Content($"You sent q = {q}");
        }
    }
}

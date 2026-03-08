using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : Controller
    {
        public static List<string> Data { get; set; } = new List<string>
        {
            "Data 1",
            "Data 2",
            "Data 3"
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Data);
        }

        [HttpPost]
        public IActionResult Add(string newItem)
        {
            Data.Add(newItem);
            return Ok(new { Message = "Added", newItem });
        }

        [HttpDelete]
        public IActionResult Delete(string item)
        {
            if (!Data.Contains(item))
            {
                return BadRequest();
            }
            Data.Remove(item);
            return Ok(new { Message = "Deleted" });
        }
    }
}

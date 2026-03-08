using Microsoft.AspNetCore.Mvc;
using PaginationConcept.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PaginationConcept.Controllers
{
    public class PersonController : Controller
    {
        private readonly IConfiguration _configuration;

        public PersonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index(int pageNumber = 1)
        {
            List<Person> persons = new List<Person>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PersonsPagination", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                cmd.Parameters.AddWithValue("@PageSize", 20);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        persons.Add(new Person
                        {
                            BusinessEntityID = Convert.ToInt32(reader["BusinessEntityID"]),
                            FirstName = reader["FirstName"]?.ToString(),
                            LastName = reader["LastName"]?.ToString()
                        });
                    }
                }
            }

            ViewBag.PageNumber = pageNumber;

            return View(persons);
        }
    }
}
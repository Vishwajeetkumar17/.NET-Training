using Microsoft.AspNetCore.Mvc;
using MultiViewExample.Models;
using System.Collections.Generic;

namespace MultiViewExample.Controllers
{
    public class HomeController : Controller
    {
        // OUTPUT: Display user data (password hidden using DTO)
        public IActionResult Dashboard()
        {
            // Simulate getting User from database (has password)
            var user = new User
            {
                Name = "Rahul Sharma",
                Email = "rahul@example.com",
                Password = "SecurePassword123" // This stays in the model but won't be passed to view
            };

            // Map to DTO - password is excluded
            var userDTO = new UserDTO
            {
                Name = user.Name,
                Email = user.Email
            };

            var model = new DashboardViewModel
            {
                User = userDTO, // Pass DTO instead of User entity
                Orders = new List<Order>
                {
                    new Order { Id = 1, OrderName = "Laptop" },
                    new Order { Id = 2, OrderName = "Mobile" },
                    new Order { Id = 3, OrderName = "Headphones" }
                }
            };

            return View(model);
        }

        // INPUT: Display form to create new user
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        // INPUT: Accept user input with password via DTO
        [HttpPost]
        public IActionResult CreateUser(CreateUserDTO createUserDTO)
        {
            if (ModelState.IsValid)
            {
                // Map DTO to Entity Model
                var user = new User
                {
                    Name = createUserDTO.Name,
                    Email = createUserDTO.Email,
                    Password = createUserDTO.Password // In real app: Hash this password!
                    // Password = HashPassword(createUserDTO.Password)
                };

                // Save to database (simulated)
                // _dbContext.Users.Add(user);
                // _dbContext.SaveChanges();

                // Redirect to dashboard
                return RedirectToAction("Dashboard");
            }

            return View(createUserDTO);
        }
    }
}
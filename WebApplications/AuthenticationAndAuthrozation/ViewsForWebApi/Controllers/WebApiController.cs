using Microsoft.AspNetCore.Mvc;
using ViewsForWebApi.Models;
using ViewsForWebApi.Services;

namespace ViewsForWebApi.Controllers
{
    public class WebApiController : Controller
    {
        private const string TokenKey = "AuthToken";
        private const string UsernameKey = "Username";
        private const string RoleKey = "Role";

        private readonly IWebApiService _webApiService;

        public WebApiController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString(UsernameKey);
            ViewBag.Role = HttpContext.Session.GetString(RoleKey);
            ViewBag.Token = HttpContext.Session.GetString(TokenKey);
            return View();
        }

        [HttpGet]
        public IActionResult Signup() => View(new SignupRequestModel());

        [HttpPost]
        public async Task<IActionResult> Signup(SignupRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _webApiService.SignupAsync(model);
            if (!result.IsSuccess || result.Data == null)
            {
                ViewBag.Error = result.ErrorMessage;
                return View(model);
            }

            SetSession(result.Data);
            TempData["Success"] = "Signup successful.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Login() => View(new LoginRequestModel());

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _webApiService.LoginAsync(model);
            if (!result.IsSuccess || result.Data == null)
            {
                ViewBag.Error = result.ErrorMessage;
                return View(model);
            }

            SetSession(result.Data);
            TempData["Success"] = "Login successful.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

        // ======= ADMIN SECTION =======
        
        [HttpGet]
        public async Task<IActionResult> AdminDashboard()
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetAdminDashboardAsync(token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> AdminUsers()
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetAllUsersAsync(token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.DeleteUserAsync(id, token);
            TempData[result.IsSuccess ? "Success" : "Error"] = result.IsSuccess
                ? result.Data?.Message ?? "User deleted."
                : result.ErrorMessage;

            return RedirectToAction(nameof(AdminUsers));
        }

        [HttpGet]
        public async Task<IActionResult> AdminStudents()
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetAllStudentsAsync(token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> StudentDetails(int id)
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetStudentByIdAsync(id, token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(AdminStudents));
            }

            return View(result.Data);
        }

        [HttpGet]
        public IActionResult CreateStudent() => View(new CreateStudentRequestModel());

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentRequestModel model)
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _webApiService.CreateStudentAsync(model, token);
            if (!result.IsSuccess || result.Data == null)
            {
                ViewBag.Error = result.ErrorMessage;
                return View(model);
            }

            TempData["Success"] = "Student created successfully.";
            return RedirectToAction(nameof(AdminStudents));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.DeleteStudentAsync(id, token);
            TempData[result.IsSuccess ? "Success" : "Error"] = result.IsSuccess
                ? result.Data?.Message ?? "Student deleted."
                : result.ErrorMessage;

            return RedirectToAction(nameof(AdminStudents));
        }

        [HttpGet]
        public async Task<IActionResult> AdminStaff()
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetAllStaffAsync(token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> StaffDetails(int id)
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetStaffByIdAsync(id, token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(AdminStaff));
            }

            return View(result.Data);
        }

        [HttpGet]
        public IActionResult CreateStaff() => View(new CreateStaffRequestModel());

        [HttpPost]
        public async Task<IActionResult> CreateStaff(CreateStaffRequestModel model)
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _webApiService.CreateStaffAsync(model, token);
            if (!result.IsSuccess)
            {
                ViewBag.Error = result.ErrorMessage;
                return View(model);
            }

            TempData["Success"] = "Staff member created successfully.";
            return RedirectToAction(nameof(AdminStaff));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.DeleteStaffAsync(id, token);
            TempData[result.IsSuccess ? "Success" : "Error"] = result.IsSuccess
                ? result.Data?.Message ?? "Staff deleted."
                : result.ErrorMessage;

            return RedirectToAction(nameof(AdminStaff));
        }

        // ======= STAFF SECTION =======

        [HttpGet]
        public async Task<IActionResult> StaffDashboard()
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetStaffDashboardAsync(token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> SelectStudentForGrade()
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetStudentsAsync(token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        [HttpGet]
        public IActionResult AddGradeForm(int studentId) => View(new AddGradeRequestModel { StudentId = studentId });

        [HttpPost]
        public async Task<IActionResult> AddGrade(AddGradeRequestModel model)
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            if (!ModelState.IsValid)
            {
                return View("AddGradeForm", model);
            }

            var result = await _webApiService.AssignGradeAsync(model, token);
            if (!result.IsSuccess || result.Data == null)
            {
                ViewBag.Error = result.ErrorMessage;
                return View("AddGradeForm", model);
            }

            ViewBag.Success = "Grade assigned successfully!";
            return View("AddGradeForm", new AddGradeRequestModel());
        }

        [HttpGet]
        public async Task<IActionResult> MyGrades()
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetMyGradesAsync(token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        // ======= STUDENT SECTION =======

        [HttpGet]
        public async Task<IActionResult> StudentDashboard()
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetStudentDashboardAsync(token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> StudentCourses()
        {
            var token = GetToken();
            if (token == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _webApiService.GetCoursesAsync(token);
            if (!result.IsSuccess || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        private string? GetToken() => HttpContext.Session.GetString(TokenKey);

        private void SetSession(AuthResponseModel auth)
        {
            HttpContext.Session.SetString(TokenKey, auth.Token);
            HttpContext.Session.SetString(UsernameKey, auth.Username);
            HttpContext.Session.SetString(RoleKey, auth.Role.ToString());
        }
    }
}

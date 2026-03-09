using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ViewsForWebApi.Models;

namespace ViewsForWebApi.Services
{
    public class WebApiService : IWebApiService
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public WebApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ApiServiceResult<AuthResponseModel>> SignupAsync(SignupRequestModel request) =>
            SendAsync<AuthResponseModel>(HttpMethod.Post, "api/Auth/signup", request);

        public Task<ApiServiceResult<AuthResponseModel>> LoginAsync(LoginRequestModel request) =>
            SendAsync<AuthResponseModel>(HttpMethod.Post, "api/Auth/login", request);

        public Task<ApiServiceResult<DashboardResponseModel>> GetAdminDashboardAsync(string token) =>
            SendAsync<DashboardResponseModel>(HttpMethod.Get, "api/Admin/dashboard", token: token);

        public Task<ApiServiceResult<List<AppUserModel>>> GetAllUsersAsync(string token) =>
            SendAsync<List<AppUserModel>>(HttpMethod.Get, "api/Admin/users", token: token);

        public Task<ApiServiceResult<MessageResponseModel>> DeleteUserAsync(int id, string token) =>
            SendAsync<MessageResponseModel>(HttpMethod.Delete, $"api/Admin/users/{id}", token: token);

        public Task<ApiServiceResult<StaffDetailDto>> CreateStaffAsync(CreateStaffRequestModel request, string token) =>
            SendAsync<StaffDetailDto>(HttpMethod.Post, "api/Admin/staff", request, token);

        public Task<ApiServiceResult<List<StaffDetailDto>>> GetAllStaffAsync(string token) =>
            SendAsync<List<StaffDetailDto>>(HttpMethod.Get, "api/Admin/staff", token: token);

        public Task<ApiServiceResult<StaffDetailDto>> GetStaffByIdAsync(int id, string token) =>
            SendAsync<StaffDetailDto>(HttpMethod.Get, $"api/Admin/staff/{id}", token: token);

        public Task<ApiServiceResult<MessageResponseModel>> DeleteStaffAsync(int id, string token) =>
            SendAsync<MessageResponseModel>(HttpMethod.Delete, $"api/Admin/staff/{id}", token: token);

        public Task<ApiServiceResult<StudentDetailDto>> CreateStudentAsync(CreateStudentRequestModel request, string token) =>
            SendAsync<StudentDetailDto>(HttpMethod.Post, "api/Admin/students", request, token);

        public Task<ApiServiceResult<List<StudentDetailDto>>> GetAllStudentsAsync(string token) =>
            SendAsync<List<StudentDetailDto>>(HttpMethod.Get, "api/Admin/students", token: token);

        public Task<ApiServiceResult<StudentDetailDto>> GetStudentByIdAsync(int id, string token) =>
            SendAsync<StudentDetailDto>(HttpMethod.Get, $"api/Admin/students/{id}", token: token);

        public Task<ApiServiceResult<MessageResponseModel>> DeleteStudentAsync(int id, string token) =>
            SendAsync<MessageResponseModel>(HttpMethod.Delete, $"api/Admin/students/{id}", token: token);

        public Task<ApiServiceResult<DashboardResponseModel>> GetStaffDashboardAsync(string token) =>
            SendAsync<DashboardResponseModel>(HttpMethod.Get, "api/Staff/dashboard", token: token);

        public Task<ApiServiceResult<List<StudentModel>>> GetStudentsAsync(string token) =>
            SendAsync<List<StudentModel>>(HttpMethod.Get, "api/Staff/students", token: token);

        public Task<ApiServiceResult<List<StudentGradeDto>>> GetMyGradesAsync(string token) =>
            SendAsync<List<StudentGradeDto>>(HttpMethod.Get, "api/Staff/grades", token: token);

        public Task<ApiServiceResult<StudentGradeDto>> AssignGradeAsync(AddGradeRequestModel request, string token) =>
            SendAsync<StudentGradeDto>(HttpMethod.Post, "api/Staff/grades", request, token);

        public Task<ApiServiceResult<List<CourseModel>>> GetCoursesAsync(string token) =>
            SendAsync<List<CourseModel>>(HttpMethod.Get, "api/Staff/courses", token: token);

        public Task<ApiServiceResult<DashboardResponseModel>> GetStudentDashboardAsync(string token) =>
            SendAsync<DashboardResponseModel>(HttpMethod.Get, "api/Student/dashboard", token: token);

        public Task<ApiServiceResult<List<StudentGradeDto>>> GetMyStudentGradesAsync(string token) =>
            SendAsync<List<StudentGradeDto>>(HttpMethod.Get, "api/Student/my-grades", token: token);

        private async Task<ApiServiceResult<T>> SendAsync<T>(HttpMethod method, string endpoint, object? payload = null, string? token = null)
        {
            try
            {
                using var request = new HttpRequestMessage(method, endpoint);

                if (!string.IsNullOrWhiteSpace(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                if (payload != null)
                {
                    var json = JsonSerializer.Serialize(payload);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                var response = await _httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiServiceResult<T>
                    {
                        IsSuccess = false,
                        ErrorMessage = ExtractErrorMessage(content, response.ReasonPhrase)
                    };
                }

                if (string.IsNullOrWhiteSpace(content))
                {
                    return new ApiServiceResult<T> { IsSuccess = true };
                }

                var data = JsonSerializer.Deserialize<T>(content, _jsonOptions);

                return new ApiServiceResult<T>
                {
                    IsSuccess = true,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new ApiServiceResult<T>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        private static string ExtractErrorMessage(string content, string? fallback)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return fallback ?? "Request failed.";
            }

            try
            {
                var error = JsonSerializer.Deserialize<MessageResponseModel>(content, _jsonOptions);
                if (!string.IsNullOrWhiteSpace(error?.Message))
                {
                    return error.Message;
                }
            }
            catch
            {
            }

            return content;
        }
    }
}

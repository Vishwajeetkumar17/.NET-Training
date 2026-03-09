using ViewsForWebApi.Models;

namespace ViewsForWebApi.Services
{
    public interface IWebApiService
    {
        // Auth
        Task<ApiServiceResult<AuthResponseModel>> SignupAsync(SignupRequestModel request);
        Task<ApiServiceResult<AuthResponseModel>> LoginAsync(LoginRequestModel request);

        // Admin Dashboard
        Task<ApiServiceResult<DashboardResponseModel>> GetAdminDashboardAsync(string token);
        Task<ApiServiceResult<List<AppUserModel>>> GetAllUsersAsync(string token);
        Task<ApiServiceResult<MessageResponseModel>> DeleteUserAsync(int id, string token);

        // Admin Staff Management
        Task<ApiServiceResult<StaffDetailDto>> CreateStaffAsync(CreateStaffRequestModel request, string token);
        Task<ApiServiceResult<List<StaffDetailDto>>> GetAllStaffAsync(string token);
        Task<ApiServiceResult<StaffDetailDto>> GetStaffByIdAsync(int id, string token);
        Task<ApiServiceResult<MessageResponseModel>> DeleteStaffAsync(int id, string token);

        // Admin Students (CRUD)
        Task<ApiServiceResult<StudentDetailDto>> CreateStudentAsync(CreateStudentRequestModel request, string token);
        Task<ApiServiceResult<List<StudentDetailDto>>> GetAllStudentsAsync(string token);
        Task<ApiServiceResult<StudentDetailDto>> GetStudentByIdAsync(int id, string token);
        Task<ApiServiceResult<MessageResponseModel>> DeleteStudentAsync(int id, string token);

        // Staff Dashboard & Grades
        Task<ApiServiceResult<DashboardResponseModel>> GetStaffDashboardAsync(string token);
        Task<ApiServiceResult<List<StudentModel>>> GetStudentsAsync(string token);
        Task<ApiServiceResult<List<StudentGradeDto>>> GetMyGradesAsync(string token);
        Task<ApiServiceResult<StudentGradeDto>> AssignGradeAsync(AddGradeRequestModel request, string token);
        Task<ApiServiceResult<List<CourseModel>>> GetCoursesAsync(string token);

        // Student Dashboard & Grades
        Task<ApiServiceResult<DashboardResponseModel>> GetStudentDashboardAsync(string token);
        Task<ApiServiceResult<List<StudentGradeDto>>> GetMyStudentGradesAsync(string token);
    }
}

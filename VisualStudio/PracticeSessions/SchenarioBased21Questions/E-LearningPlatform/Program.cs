namespace ELearningPlatform
{
    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }
        public int DurationWeeks { get; set; }
        public double Price { get; set; }
        public List<string> Modules { get; set; } = new List<string>();
    }
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string StudentId { get; set; }
        public string CourseCode { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public double ProgressPercentage { get; set; }
    }
    public class StudentProgress
    {
        public string StudentId { get; set; }
        public string CourseCode { get; set; }
        public Dictionary<string, double> ModuleScores { get; set; }
            = new Dictionary<string, double>();
        public DateTime LastAccessed { get; set; }
    }
    public class LearningManager
    {
        private readonly List<Course> courses = new List<Course>();
        private readonly List<Enrollment> enrollments = new List<Enrollment>();
        private readonly List<StudentProgress> progresses = new List<StudentProgress>();
        private int enrollmentCounter = 1;

        public void AddCourse(string code, string name, string instructor, int weeks, double price, List<string> modules)
        {
            courses.Add(new Course
            {
                CourseCode = code,
                CourseName = name,
                Instructor = instructor,
                DurationWeeks = weeks,
                Price = price,
                Modules = modules
            });
        }
        public bool EnrollStudent(string studentId, string courseCode)
        {
            Course course = null;
            foreach (var c in courses)
                if (c.CourseCode == courseCode)
                {
                    course = c;
                    break;
                }
            if (course == null)
                return false;

            enrollments.Add(new Enrollment
            {
                EnrollmentId = enrollmentCounter++,
                StudentId = studentId,
                CourseCode = courseCode,
                EnrollmentDate = DateTime.Now,
                ProgressPercentage = 0
            });

            progresses.Add(new StudentProgress
            {
                StudentId = studentId,
                CourseCode = courseCode,
                LastAccessed = DateTime.Now
            });
            return true;
        }
        public bool UpdateProgress(string studentId, string courseCode, string module, double score)
        {
            StudentProgress progress = null;
            Course course = null;
            Enrollment enrollment = null;

            foreach (var p in progresses)
                if (p.StudentId == studentId && p.CourseCode == courseCode)
                {
                    progress = p;
                    break;
                }
            foreach (var c in courses)
                if (c.CourseCode == courseCode)
                {
                    course = c;
                    break;
                }
            foreach (var e in enrollments)
                if (e.StudentId == studentId && e.CourseCode == courseCode)
                {
                    enrollment = e;
                    break;
                }
            if (progress == null || course == null || enrollment == null)
                return false;
            if (!course.Modules.Contains(module))
                return false;

            progress.ModuleScores[module] = score;
            progress.LastAccessed = DateTime.Now;

            double total = 0;
            int count = 0;
            foreach (var s in progress.ModuleScores.Values)
            {
                total += s;
                count++;
            }
            enrollment.ProgressPercentage = (double)count / course.Modules.Count * 100;
            return true;
        }
        public Dictionary<string, List<Course>> GroupCoursesByInstructor()
        {
            Dictionary<string, List<Course>> grouped = new Dictionary<string, List<Course>>();

            foreach (var c in courses)
            {
                if (!grouped.ContainsKey(c.Instructor))
                    grouped[c.Instructor] = new List<Course>();

                grouped[c.Instructor].Add(c);
            }
            return grouped;
        }
        public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
        {
            List<Enrollment> filtered = new List<Enrollment>();

            foreach (var e in enrollments)
                if (e.CourseCode == courseCode)
                    filtered.Add(e);
            filtered.Sort((a, b) =>
                b.ProgressPercentage.CompareTo(a.ProgressPercentage));

            List<Enrollment> result = new List<Enrollment>();
            for (int i = 0; i < count && i < filtered.Count; i++)
                result.Add(filtered[i]);
            return result;
        }
        public List<Course> GetCourses() => courses;
    }
    public class Program
    {
        static void Main(string[] args)
        {
            LearningManager manager = new LearningManager();

            while (true)
            {
                Console.WriteLine("1 Add Course");
                Console.WriteLine("2 Enroll Student");
                Console.WriteLine("3 Update Progress");
                Console.WriteLine("4 Group Courses By Instructor");
                Console.WriteLine("5 Top Performers");
                Console.WriteLine("6 Exit");
                Console.Write("Choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Code: ");
                    string code = Console.ReadLine();

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Instructor: ");
                    string inst = Console.ReadLine();

                    Console.Write("Weeks: ");
                    int w = int.Parse(Console.ReadLine());

                    Console.Write("Price: ");
                    double p = double.Parse(Console.ReadLine());

                    Console.Write("Modules comma separated: ");
                    List<string> mods = new List<string>(
                        Console.ReadLine().Split(','));

                    manager.AddCourse(code, name, inst, w, p, mods);
                }
                else if (choice == 2)
                {
                    Console.Write("StudentId: ");
                    string sid = Console.ReadLine();

                    Console.Write("CourseCode: ");
                    string cc = Console.ReadLine();

                    Console.WriteLine(manager.EnrollStudent(sid, cc)
                        ? "Enrolled" : "Failed");
                }
                else if (choice == 3)
                {
                    Console.Write("StudentId: ");
                    string sid = Console.ReadLine();

                    Console.Write("CourseCode: ");
                    string cc = Console.ReadLine();

                    Console.Write("Module: ");
                    string mod = Console.ReadLine();

                    Console.Write("Score: ");
                    double sc = double.Parse(Console.ReadLine());

                    Console.WriteLine(manager.UpdateProgress(sid, cc, mod, sc)
                        ? "Updated" : "Failed");
                }
                else if (choice == 4)
                {
                    var g = manager.GroupCoursesByInstructor();
                    foreach (var x in g)
                    {
                        Console.WriteLine(x.Key);
                        foreach (var c in x.Value)
                            Console.WriteLine(c.CourseCode + " " + c.CourseName);
                        Console.WriteLine();
                    }
                }
                else if (choice == 5)
                {
                    Console.Write("CourseCode: ");
                    string cc = Console.ReadLine();

                    Console.Write("Count: ");
                    int cnt = int.Parse(Console.ReadLine());

                    var list = manager.GetTopPerformingStudents(cc, cnt);
                    foreach (var e in list)
                        Console.WriteLine(e.StudentId + " " + e.ProgressPercentage);
                }
                else if (choice == 6)
                    break;

                Console.WriteLine();
            }
        }
    }
}

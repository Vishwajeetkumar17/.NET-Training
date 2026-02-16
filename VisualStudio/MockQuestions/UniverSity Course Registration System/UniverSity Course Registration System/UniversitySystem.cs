namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string>? prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            // 2. Create Course object
            // 3. Add to AvailableCourses

            if (AvailableCourses.ContainsKey(code))
                throw new ArgumentException("Course already exists");

            AvailableCourses[code] = new Course(code, name, credits, maxCapacity, prerequisites);
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string>? completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            // 2. Create Student object
            // 3. Add to Students dictionary

            if (Students.ContainsKey(id))
                throw new ArgumentException("Student already exists");

            Students[id] = new Student(id, name, major, maxCredits, completedCourses);
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            // 2. Call student.AddCourse(course)
            // 3. Display meaningful messages

            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found");
                return false;
            }

            if (!AvailableCourses.ContainsKey(courseCode))
            {
                Console.WriteLine("Course not found");
                return false;
            }

            bool result = Students[studentId].AddCourse(AvailableCourses[courseCode]);
            Console.WriteLine(result ? "Registration successful!" : "Registration failed");
            return result;
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            // 2. Call student.DropCourse(courseCode)

            if (!Students.ContainsKey(studentId))
                return false;

            return Students[studentId].DropCourse(courseCode);
        }

        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info

            foreach (var c in AvailableCourses.Values)
                Console.WriteLine($"{c.CourseCode} | {c.CourseName} | Credits:{c.Credits} | {c.GetEnrollmentInfo()}");
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            // Call student.DisplaySchedule()

            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found");
                return;
            }

            Students[studentId].DisplaySchedule();
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment

            int totalStudents = Students.Count;
            int totalCourses = AvailableCourses.Count;

            double avg = totalCourses == 0 ? 0 :
                AvailableCourses.Values.Average(c => int.Parse(c.GetEnrollmentInfo().Split('/')[0]));

            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine($"Total Courses: {totalCourses}");
            Console.WriteLine($"Average Enrollment: {avg}");
        }
    }
}

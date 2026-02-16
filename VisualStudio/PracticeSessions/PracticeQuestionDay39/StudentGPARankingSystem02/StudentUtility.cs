namespace StudentGPARankingSystem02
{
    public class StudentUtility
    {
        private SortedDictionary<double, List<Student>> students = new SortedDictionary<double, List<Student>>(Comparer<double>.Create((a, b) => b.CompareTo(a)));

        public void AddStudent(Student student)
        {
            if (student.GPA < 0 || student.GPA > 10)
                throw new InvalidGPAException("Invalid GPA");

            // Check duplicate ID
            foreach (var list in students.Values)
            {
                foreach (var s in list)
                {
                    if (s.Id.Equals(student.Id))
                        throw new DuplicateStudentException("Duplicate Student");
                }
            }

            if (!students.ContainsKey(student.GPA))
            {
                students[student.GPA] = new List<Student>();
            }

            students[student.GPA].Add(student);
        }

        public void DisplayRanking()
        {
            foreach (var entry in students)
            {
                foreach (var s in entry.Value)
                {
                    Console.WriteLine($"Details: {s.Id} {s.Name} {s.GPA}");
                }
            }
        }

        public void UpdateGPA(string id, double newGPA)
        {
            if (newGPA < 0 || newGPA > 10)
                throw new InvalidGPAException("Invalid GPA");

            foreach (var entry in students)
            {
                foreach (var s in entry.Value)
                {
                    if (s.Id.Equals(id))
                    {
                        entry.Value.Remove(s);

                        // Add to new GPA bucket
                        if (!students.ContainsKey(newGPA))
                            students[newGPA] = new List<Student>();

                        s.GPA = newGPA;
                        students[newGPA].Add(s);

                        return;
                    }
                }
            }

            throw new StudentNotFoundException("Student Not Found");
        }
    }
}


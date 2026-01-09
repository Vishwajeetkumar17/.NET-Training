namespace Q5
{
    /// <summary>
    /// Represents a student and provides functionality
    /// to filter eligible students based on criteria.
    /// </summary>
    public class Student
    {
        #region Properties

        // Gets or sets the roll number of the student
        public int RollNo { get; set; }

        // Gets or sets the name of the student
        public string Name { get; set; }

        // Gets or sets the marks obtained by the student
        public int Marks { get; set; }

        // Gets or sets the sports grade of the student
        public char SportsGrade { get; set; }

        #endregion

        #region Static Methods

        // Returns names of students eligible for scholarship
        public static string GetEligibleStudents(
            List<Student> studentList,
            IsEligibleforScholarship isEligible)
        {
            List<string> eligibleNames = new List<string>();

            foreach (var student in studentList)
            {
                if (isEligible(student))
                {
                    eligibleNames.Add(student.Name);
                }
            }

            return string.Join(", ", eligibleNames);
        }

        #endregion
    }
}

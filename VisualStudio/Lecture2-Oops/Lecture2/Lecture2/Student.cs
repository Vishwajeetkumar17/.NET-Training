using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture2
{
    /// <summary>
    /// Student Definition Class
    /// </summary>
    public class Student : System.Object
    {
        #region Decleration
        private string name;
        private int regNo;
        #endregion

        #region Constructor
        public Student(string name, int regNo)
        {
            this.name = name;
            this.regNo = regNo;
        }
        #endregion

        #region Member functions
        public string getName()
        {
            return name;
        }
        public int getRegNo()
        {
            return regNo;
        }
        #endregion
    }
}

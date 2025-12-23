using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorCLass
{
    /// <summary>
    /// Concatenation of error messages for invalid property assignments.
    /// </summary>
    public class Employee
    {
        private int id;
        private string name;
        private int rank;
        public string errorMessage;

        public int Id
        {
            get{
                return id;
            }
            set{
                if (value <= 0)
                {
                    id = 0;
                    errorMessage += $"Id must be greater than zero.{Environment.NewLine}";

                }
                else
                {
                    id = value;
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                               if (string.IsNullOrWhiteSpace(value))
                {
                    name = "Unknown";
                    errorMessage += $"Name cannot be empty.{Environment.NewLine}";
                }
                else
                {
                    name = value;
                }
            }
        }
        public int Rank
        {
            get
            {
                return rank;
            }
            set
            {
                if (value < 1 || value > 10)
                {
                    rank = 0;
                    errorMessage += $"Rank must be between 1 and 10.{Environment.NewLine}";
                }
                else
                {
                    rank = value;
                }
            }
        }
    }
}

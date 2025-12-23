using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorCLass
{
    public class ClassField
    {
        private int id;

        public int Id
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Id must be greater than zero.");
                }
                id = value;
            }
        }
        public string displayEmpDetails()
        {
            return $"Id: {id}";
        }
    }
}

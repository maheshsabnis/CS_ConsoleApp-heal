using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ConsoleApp
{
    /// <summary>
    /// Traditional Properties
    /// </summary>
    public class Person
    {
        private int _PersonId;
        public int PersonId
        {
            set
            {
                _PersonId = value;  
            }
            get 
            {
                return _PersonId;
            }

        }
        private string _PersonName;
        public string PersonName
        {
            
            set
            {
                _PersonName = value;
            }
            get
            {
                return _PersonName.ToUpper();
            }

        
        }
        private int _Age;

        public int Age
        {
            set
            {
                if (value < 18)
                {
                    Console.WriteLine("The Person is Minor");
                    _Age = value;
                    _PersonMajorMinor = "Minor";
                }
                else
                {
                    _Age = value;
                    _PersonMajorMinor = "Major";
                }
            }
            get
            {
                return _Age;
            }
        }

        private string _PersonMajorMinor;

        /// <summary>
        /// Read-only property
        /// </summary>
        public string PersonMajorMinor
        {
            get 
            {
                return _PersonMajorMinor;
            }
        }
    }


    /// <summary>
    /// auto-Implemented Properties
    /// </summary>
    public class Employee
    {
        
        public int EmpNo { get; set; } // read-write properties
        public string EmpName { get; set; }  // read-write properties
        public int Salary { get; } // read-only property

    }


}

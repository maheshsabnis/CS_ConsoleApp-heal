using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EmployeeInfo
{
    public class EmployeeDataOperations
    {
        // referebce of EmployeeDatabase class
        EmployeeDatabase db;

        public EmployeeDataOperations()
        {
            // instance of EmployeeDatabase
            db = new EmployeeDatabase();
        }

        /// <summary>
        /// Return all Employees from EmployeeDatabase
        /// </summary>
        /// <returns></returns>
        public EmployeeDatabase GetEmployees()
        {
            return db;
        }

        /// <summary>
        /// Adding new record into list
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public EmployeeDatabase AddEmployee(Employee emp)
        {
            // Adding EMployee object into List i.e.
            // EmployeeDatabase
            db.Add(emp);
            return db;    
        }

        public EmployeeDatabase DeleteEmployee(int empno)
        {
            // 1. Search employee from EmployeeDatabase based on empno
            Employee emp = db.Find(e => e.EmpNo == empno);
            // remove the employee from EmployeeDatabase
            db.Remove(emp);
            // return the EmployeeDatabase
            return db;     
        }
    }
}

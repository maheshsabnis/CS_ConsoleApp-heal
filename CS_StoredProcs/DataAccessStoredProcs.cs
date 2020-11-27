using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace CS_StoredProcs
{
    /// <summary>
    /// This clas will contain code to connect to DB and perform Read/Write Operations on Database
    /// using Stored Procedures
    /// </summary>
    public class DataAccessStoredProcs
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public DataAccessStoredProcs()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=ExpensesRHeal;Integrated Security=SSPI");
           
        }

        /// <summary>
        /// Calling Stored Proc which does not accepts input parameter and nor retur anything
        /// </summary>
        /// <returns></returns>

        public List<Emp> GetEmployees()
        {

            List<Emp> emps = new List<Emp>();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "GetEmployees";
                SqlDataReader reader = Cmd.ExecuteReader(); // since the SP generates cursor use DataReader
                while (reader.Read())
                {
                    var emp = new Emp()
                    {
                         EmpNo = Convert.ToInt32(reader["EmpNo"]),
                         EmpName = reader["EmpName"].ToString(),
                         Designation= reader["Designation"].ToString(),
                         Salary = Convert.ToInt32(reader["Salary"]),
                         DeptNo = Convert.ToInt32(reader["DeptNo"])
                    };
                    emps.Add(emp);
                }
                reader.Close();
                Conn.Close();
            }
            catch (SqlException ex) // Handle exceptions those occured onle ADO.NET Operations for Sql Server
            {
                Console.WriteLine($"Error Occured while performing Operation with SQL {ex.Message}");

            }
            catch (Exception ex) // High Level Exception Object, in try block other than SQL Server operation some other
            // exception occures then SqlExpcetion will fail so to catch such bexceptions use high level exception class 
            {
                Console.WriteLine($"Error Occured while performing Operation  {ex.Message}");
            }
            return emps;
        }



        public int InsertEmployee(Emp emp)
        {
            int result = 0;
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "InsertDataIntoEmpTable";
                // defining parameters
                
                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Value = Convert.ToInt32(emp.EmpNo);
                Cmd.Parameters.Add(pEmpNo);

                SqlParameter pEmpName = new SqlParameter();
                pEmpName.ParameterName = "@EmpName";
                pEmpName.Direction = ParameterDirection.Input;
                pEmpName.SqlDbType = SqlDbType.VarChar;
                pEmpName.Size = 100;
                pEmpName.Value = emp.EmpName;
                Cmd.Parameters.Add(pEmpName);

                SqlParameter pDesignation = new SqlParameter();
                pDesignation.ParameterName = "@Designation";
                pDesignation.Direction = ParameterDirection.Input;
                pDesignation.SqlDbType = SqlDbType.VarChar;
                pDesignation.Size = 100;
                pDesignation.Value = emp.Designation;
                Cmd.Parameters.Add(pDesignation);

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@Salary";
                pSalary.Direction = ParameterDirection.Input;
                pSalary.SqlDbType = SqlDbType.Int;
                pSalary.Value = Convert.ToInt32(emp.Salary);
                Cmd.Parameters.Add(pSalary);


                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Value = Convert.ToInt32(emp.DeptNo);
                Cmd.Parameters.Add(pDeptNo);


                result = Cmd.ExecuteNonQuery();

                Conn.Close();
            }
            catch (SqlException ex)  
            {
                Console.WriteLine($"Error Occured while performing Operation with SQL {ex.Message}");

            }
            catch (Exception ex)  
            {
                Console.WriteLine($"Error Occured while performing Operation  {ex.Message}");
            }
            return result;
        }


        public int GetSumOfSalariesByDeptName(string deptName)
        {
            int SalarySum = 0;
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "GetSumOfSalaryByDeptNameWithOuputParameter";
                // defining parameters

                SqlParameter pDeptName = new SqlParameter();
                pDeptName.ParameterName = "@DeptName";
                pDeptName.Direction = ParameterDirection.Input;
                pDeptName.SqlDbType = SqlDbType.VarChar;
                pDeptName.Size = 200;
                pDeptName.Value = deptName;
                Cmd.Parameters.Add(pDeptName);

                SqlParameter pSumSalary = new SqlParameter();
                pSumSalary.ParameterName = "@SumSalary";
                pSumSalary.Direction = ParameterDirection.Output; //Output Parameters
                pSumSalary.SqlDbType = SqlDbType.Int;
                Cmd.Parameters.Add(pSumSalary);
                object result = Cmd.ExecuteScalar();

                SalarySum = Convert.ToInt32(result);
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while performing Operation with SQL {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occured while performing Operation  {ex.Message}");
            }

            return SalarySum;
        }


    }
}

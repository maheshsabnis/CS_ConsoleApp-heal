using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CS_ConnectArchi_DML
{
    public class DemoMars
    {
        // defining the SqlConnection, SqlCommand References
        SqlConnection Conn;
        SqlCommand Cmd;

        // initialize the database connection
        public DemoMars()
        {
            // connection string with MultipleActiveResultSets
            // to supoort multiple Readers on one signle connection
            Conn = new SqlConnection("Data Source=.;Initial Catalog=ExpensesRHeal;Integrated Security=SSPI;MultipleActiveResultSets=true");
        }


        /// <summary>
        /// Read All records from Dept and EMp tables
        /// </summary>
        public void PrintDeptEmp()
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;

                Cmd.CommandText = "Select * from Dept;Select * from Emp";



                SqlDataReader Reader = Cmd.ExecuteReader();

                // The Reader will have two RowSets in a Result, the first is Dept and ASecond is Emp
                // TO print the Data from RowSet use Column Index instead of Column Name
                if (Reader.HasRows)
                {
                    
                    while (Reader.Read())
                        {
                             Console.WriteLine($"Value {Convert.ToInt32(Reader[0])}");
                                 Reader.NextResult(); // Move to the Next Roww Set in the Result Set
                        }
               
                   
                }
                Reader.Close();

                Conn.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Occured {ex.Message}");
            }
            
        }
        /// <summary>
        /// CLose the Firets Reader before opening the new reader
        /// </summary>

        public void DeptEmpWithoutMars()
        
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=ExpensesRHeal;Integrated Security=SSPI");
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from Dept";
            SqlDataReader ReaderDept = Cmd.ExecuteReader();
            while (ReaderDept.Read())
            {
                Console.WriteLine($"DeptNo {Convert.ToInt32(ReaderDept["DeptNo"])} DeptName = {ReaderDept["DeptName"]}"); 
            }
            ReaderDept.Close();
            Cmd.CommandText = "Select * from Emp";
            SqlDataReader ReaderEmp = Cmd.ExecuteReader();
            while (ReaderEmp.Read())
            {
                Console.WriteLine($"EmpNo {Convert.ToInt32(ReaderEmp["EmpNo"])} EmpName = {ReaderEmp["EmpName"]}");
            }
            ReaderEmp.Close();
            Conn.Close();

        }


        /// <summary>
        /// We can using MARS to make sure that one reader can be reused and be activates for multiple ReseulSets
        /// ADO.NET 2.0 from .NET Fraework 2.0
        /// </summary>
        public void DeptEmpWithMars()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=ExpensesRHeal;Integrated Security=SSPI;MultipleActiveResultSets=true");
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from Dept";
            SqlDataReader Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                Console.WriteLine($"DeptNo {Convert.ToInt32(Reader["DeptNo"])} DeptName = {Reader["DeptName"]}");
            }
           Reader.Close();
            Cmd.CommandText = "Select * from Emp";
              Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                Console.WriteLine($"EmpNo {Convert.ToInt32(Reader["EmpNo"])} EmpName = {Reader["EmpName"]}");
            }
          //  ReaderEmp.Close();
            Conn.Close();


        }

        /// <summary>
        /// Real MARS having Multiple Active Readers with their Result Sets without closing them
        /// Multiple COmmands Multiple Readers but One single Connection
        /// </summary>
        public void DeptEmpWithMarsWithMultipleCommand()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=ExpensesRHeal;Integrated Security=SSPI;MultipleActiveResultSets=true");
            Conn.Open();
            SqlCommand Cmd1 = new SqlCommand();
            Cmd1.Connection = Conn;
            Cmd1.CommandText = "Select * from Dept";
            SqlDataReader Reader1 = Cmd1.ExecuteReader();
            while (Reader1.Read())
            {
                Console.WriteLine($"DeptNo {Convert.ToInt32(Reader1["DeptNo"])} DeptName = {Reader1["DeptName"]}");
            }
             
            SqlCommand Cmd2 = new SqlCommand();
            Cmd2.Connection = Conn;
            Cmd2.CommandText = "Select * from Emp";
            SqlDataReader Reader2 = Cmd2.ExecuteReader();
            while (Reader2.Read())
            {
                Console.WriteLine($"EmpNo {Convert.ToInt32(Reader2["EmpNo"])} EmpName = {Reader2["EmpName"]}");
            }
            
            Conn.Close();


        }

    }
}
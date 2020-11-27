using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CS_ConnectArchi_DML
{
    public class DataAccess
    {
        // defining the SqlConnection, SqlCommand References
        SqlConnection Conn;
        SqlCommand Cmd;

        // initialize the database connection
        public DataAccess()
        {
            // Connection string if the connection with Admin Account
            // Data Source=. OR <ip-address> OR <machine-name> OR <localhost>;Initial Catalog=<NAME-OF-DATABASE>;Integrated Security=SSPI
            // Connection String if use the Sql Server Authentication with user name and password
            // Data Source=./ip-address/machine-name/localhost;Initial Catalog=<NAME-OF-DATABASE>;User Id=<USER-NAME>;Password=<PWD>
            // E.g. If using Sql Express
            // Data Source=.\\SqlExpress
            // E.g. If using the Local Sql Server Instance
            // Data Source=./MACHINE-NAME
            // E.g. If using Remote Server
            // Data Source=<IP-ADDRESS>/<REMOTE-SERVER-NAME>
            // E.g. If useing the Local Db Instance of Visual Studio
            // Data Source=(localdb)\\mssqllocaldb
            // In some Examples Initial Catalog is replace by Database and Data Source is reoplace by Server (Not-recommended)

            Conn = new SqlConnection("Data Source=.;Initial Catalog=ExpensesRHeal;Integrated Security=SSPI");
        }


        /// <summary>
        /// This method will read all records from Dept Table
        /// </summary>
        /// <returns></returns>
        public List<Dept> GetDepartments()
        {
            List<Dept> depts = new List<Dept>();
            // 1. Open the Connection
            Conn.Open();
            // 2. Create an instance of the Command Object
            Cmd = new SqlCommand();
            // 3. Assign the Connection object to Connection property of Command
            // SO that the Command know wh9ch connection is used to perform Read/Write Operations
            Cmd.Connection = Conn;
            // 4. Set the CommandText proeprty to Select Query to Read all Departments
            Cmd.CommandText = "Select * from Dept";
            // 5. Execute the Command usinf ExecuteReader() method. This returns DataReader  object to read al records
            SqlDataReader reader = Cmd.ExecuteReader();
            // 6. DataReader is a Cursor that contains all ResultSets thos contains Rows in it
            // to read these rows read throgh DataRead upto last record
            // The 'Read()' method will read upto the last record
            while (reader.Read())
            {
                // 7. Read each row and add in list of Depts.
                // each column value will be read using its name passed to reader object e.g. reader["<COLUMN-NAME>"]
                Dept dept = new Dept()
                {
                     DeptNo = Convert.ToInt32(reader["DeptNo"]),
                     DeptName = reader["DeptName"].ToString(),
                     Location = reader["Location"].ToString(),
                     Capacity = Convert.ToInt32(reader["Capacity"])
                };
                // 8. Add the dept object in List
                depts.Add(dept);
            }
            // 9. CLose Reader. This will close the ResultSet other wise reader will keep on open the cursor
            reader.Close();
            //10. CLose the connection
            Conn.Close();
            // 11. returning the list
            return depts;
        }
        /// <summary>
        /// This method will be used to add new Department
        /// In case when the .NET Code may have runtime errors and may crash
        /// then use exception handling with try-catch block
        /// Use the 'Exception' as top level Exception Class to handle exception
        /// </summary>
        /// <param name="dept"></param>
        public void AddDept(Dept dept)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into Dept Values({dept.DeptNo},'{dept.DeptName}','{dept.Location}',{dept.Capacity})";
                int result = Cmd.ExecuteNonQuery(); // for Insert / Update / Delete
                Console.WriteLine($"Number of Rows Added {result}");
                Conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occured {ex.Message}");
            }
         
        }

        /// <summary>
        /// This method will be used to update Department based on DeptNo 
        /// </summary>
        /// <param name="dno"></param>
        /// <param name="dept"></param>
        public void UpdateDept(int dno,Dept dept)
        {
            Conn.Open();
            Cmd = new SqlCommand(); 
            Cmd.Connection = Conn;

            // Comamnd Text is set using the String Interpolation e.g. $"{}".
            // Cmd.CommandText = $"Update Dept set Capacity={dept.Capacity} where DeptNo={dept.DeptNo}";
            // Using Parameterized Query

            // Not Recommended with string concatination
          //  Cmd.CommandText = "Update Dept Set Capacity=" + dept.Capacity + " where DeptNo=" + dept.DeptNo;

            Cmd.CommandText = "Update Dept Set Capacity=@Capacity where DeptNo=@DeptNo";

            // Define parameters using SqlParameter class
            SqlParameter pCapacity = new SqlParameter();
            // set the parameter name
            pCapacity.ParameterName = "@Capacity";
            // set the parameter Direction  (Default is input)
            pCapacity.Direction = ParameterDirection.Input;
            // set the data type of the parameter
            pCapacity.SqlDbType = SqlDbType.Int;
            // set the value
            pCapacity.SqlValue = Convert.ToInt32(dept.Capacity);
            // add the parameter in parameters collection of the Cmd object
            Cmd.Parameters.Add(pCapacity);

            // Other way of defining SQlParameter to COmmand Object
            // Only in case of Inout parameters 
            Cmd.Parameters.AddWithValue("@DeptNo", Convert.ToInt32(dept.DeptNo));


            int result  =Cmd.ExecuteNonQuery();
            Console.WriteLine($"Numberb of Records Updated {result}");
            Conn.Close();
        }
        /// <summary>
        /// This method will be used to delete Dept base don DeptNo
        /// </summary>
        /// <param name="dno"></param>
        public void DeleteDept(int dno)
        {
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Delete from Dept where DeptNo =@DeptNo";
            Cmd.Parameters.AddWithValue("@DeptNo",dno);
            int res = Cmd.ExecuteNonQuery();
            Console.WriteLine($"Records deleted {res}");
            Conn.Close();
        }




        public void UpdateNew(int dno, Dept dept)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;

                string CommandText = "Update Dept Set DeptName = @DeptName Where DeptNo =@DeptNo";
                Cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
                Cmd.Parameters.AddWithValue("@DeptNo", dept.DeptNo);
                Cmd.CommandText = CommandText;
                Cmd.ExecuteNonQuery();


                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occured ${ex.Message}");
            }
            finally // will always be executed irresective of try or catch
            { 
                 Conn.Close();
            }
        }
    }
}

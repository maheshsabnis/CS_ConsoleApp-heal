using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ADO_NET_Disconnected_CRUD
{
    public class DataAccess
    {
        SqlConnection Conn;
        DataSet Ds;
        SqlDataAdapter Adapter;

        public DataAccess()
        {
            Conn = new SqlConnection("Data SOurce=.;Initial Catalog=ExpensesRHeal;Integrated Security=SSPI");
            Ds = new DataSet();
            // DataSet will the Table in it
          //  GetDepartments();
        }

        public List<Dept> GetDepartments()
        {
            List<Dept> depts = new List<Dept>();
            Adapter = new SqlDataAdapter("Select * from Dept", Conn);
            // Fill Data into Dataset
            Adapter.Fill(Ds, "Dept");
            // Read  Records from 'Dept' DataTable in DataSet
            // DataSet Contains DaaTableCollection-->This has DataTable--> DataTable contains DataRowCollection
            DataRowCollection rows = Ds.Tables["Dept"].Rows;
            // Read each row and add it in List<Dept>
            foreach (DataRow row in rows)
            {
                depts.Add(
                      new Dept() { 
                        DeptNo = Convert.ToInt32(row["DeptNo"]),
                        DeptName = row["DeptName"].ToString(),
                        Location = row["Location"].ToString(),
                        Capacity = Convert.ToInt32(row["Capacity"])
                      }
                    );
            }

            return depts;
        }

        public void AddDept(Dept dept)
        {
            // 1. Define a ne Empty Row in the 'Dept' table inside DataSet
            DataRow drNew = Ds.Tables["Dept"].NewRow();
            // 2. Add column values in this New Row
            drNew["DeptNo"] = dept.DeptNo;
            drNew["DeptName"] = dept.DeptName;
            drNew["Location"] = dept.Location;
            drNew["Capacity"] = dept.Capacity;

            // 3. Add this new row in Rows COllection
            Ds.Tables["Dept"].Rows.Add(drNew);


            // 4. Create an Instance of SqlCommandBuilder.
            // and pass DataApater to it. This will buld Commands to 
            // execute on Database to perform CRUD Operations

            SqlCommandBuilder builder = new SqlCommandBuilder(Adapter);
            // 5. Update the data From DataSet to DataBase Server using  'Update()' method
            // SqlDataApter. This method will accept DataSet and the name of the Table being
            // Updated
            Adapter.Update(Ds, "Dept");
           
        }


        public void UpdateDepartment(Dept dept)
        {

            try
            {
                Console.WriteLine($"Before Update DataSet {Ds.GetXml()}");
                // 1. Search the Records from DataSet Table based on Primary Key
                // This will need the Typed DataSet to Search record based on P.K.
                // If not Typed DataSet then
                // a. Either convert untyped dataset into Dataset (Recommended if Data is Filled from Database)
                // b. Define the Primary Key Separately using the DataColumn Array (Do this if DataSet and tabled are created using code)

                // Using option  'b'
                // Set tghe DeptNo as Not Null and Unique
                Ds.Tables["Dept"].Columns["DeptNo"].Unique = true;
                Ds.Tables["Dept"].Columns["DeptNo"].AllowDBNull = false;

                // Take an array of All DeptNo to make it as Primary Key
                DataColumn[] columns = new DataColumn[] { Ds.Tables["Dept"].Columns["DeptNo"] };
                // Set it as Primary Key for Dept Tabel
                Ds.Tables["Dept"].PrimaryKey = columns;

                DataRow drFind = Ds.Tables["Dept"].Rows.Find(dept.DeptNo);

                // Update the Data in the drFind
                drFind["DeptNo"] = dept.DeptNo;
                drFind["DeptName"] = dept.DeptName;
                drFind["Location"] = dept.Location;
                drFind["Capacity"] = dept.Capacity;

                // USe Command Builder and Update Data

                SqlCommandBuilder builder = new SqlCommandBuilder(Adapter);

                Adapter.Update(Ds, "Dept");
            }
            catch (SqlException ex)
            {

                Console.WriteLine($"SQL Exception {ex.Message} {ex.InnerException}");
            }

            catch (Exception ex)
            {

                Console.WriteLine($" Exception {ex.Message} {ex.InnerException}");
            }

        }

        public void DeleteDepartment(int DeptNo)
        {

            try
            {
                Adapter = new SqlDataAdapter("Select * from Dept", Conn);

                // Convert UnTyped DataSet into Typed DataSet
                Adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Ds = new DataSet();
                // Fill data in DataSet
                Adapter.Fill(Ds, "Dept");

                Console.WriteLine($"Original DataSet {Ds.GetXml()}");

                // Find the Record based on Primary Key
                DataRow drFind = Ds.Tables["Dept"].Rows.Find(DeptNo);
                // Removed the Searched row from Table in DataSet
                // The roe will be removed from the Original ROws Section of the DataSet
                // and will be added on DifGram so that, the Adapter.Update()
                // will remnove this row from the Database
                drFind.Delete();
               
                Console.WriteLine($"After Row Deleted the  DataSet {Ds.GetXml()}");
                SqlCommandBuilder builder = new SqlCommandBuilder(Adapter);

                Adapter.Update(Ds, "Dept");

                Console.WriteLine("Deleted");
            }
            catch (Exception ex)
            { 
                Console.WriteLine($" Exception {ex.Message} {ex.InnerException}");
            }
        }
      




    }
}

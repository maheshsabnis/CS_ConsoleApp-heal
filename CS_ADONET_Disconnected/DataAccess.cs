using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CS_ADONET_Disconnected
{
    public class DataAccess
    {
        SqlConnection Conn;
        DataSet Ds; // The DataSet
        SqlDataAdapter Adapter; // the Data Adpater

        public DataAccess()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=ExpensesRHeal;Integrated Security=SSPI");
            Ds = new DataSet(); // UnTyped DataSet. This will not Show any constraints
        }

        public void FillData()
        {
            // 1. Instantiate the DataAdpater using Select Statement and Connection object
            Adapter = new SqlDataAdapter("Select * from Dept", Conn);

            // Convert UnTyped DataSet into Typed DataSet
            // Inform Adapater to Read COnstraints for the Table and add the COnstraints e.g. Primary Key
            // in DataSet for Table
            Adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // 2. Fill data in DataSet. The first Parameter is the DstaSet object
            // Second Parameter is name of the table inside DataSet. (For simplicity, set table name is dataset as name of table in Database)
            Adapter.Fill(Ds, "Dept");

           
            // Display data-Schema in DataSet in XML
            Console.WriteLine(Ds.GetXmlSchema());
            Console.WriteLine();
            // display data from dataset in XML
            Console.WriteLine(Ds.GetXml());

        }

        /// <summary>
        /// Create Table Programatically and Ad it in DataSet
        /// </summary>
        public void CreateDataSetSchemaUsingTableUsingCode()
        {
            // 1. Create Table Object
            DataTable tblProduct = new DataTable();
            tblProduct.TableName = "Product";
            // 2. Create Columns and Add those Columns in Table
            DataColumn colProductId = new DataColumn();
            // 2a. Set Column Name
            colProductId.ColumnName = "ProductId";
            // 2b. Set Column DataType
            colProductId.DataType = typeof(Int32);
            // 2c. Make column Unique
            colProductId.Unique = true;
            // 2d. Make column as not null
            colProductId.AllowDBNull = false;

            colProductId.AutoIncrement = true; // Auto-Increament value for the column 
            colProductId.AutoIncrementSeed = 1; // default value to start aut-increament is 1
            
            // 2d. Add COlumn in DataColumnCollection of DataTable
            tblProduct.Columns.Add(colProductId);
            

            // 2e. defining the ProductId as Primary Key

            tblProduct.PrimaryKey = new DataColumn[] { tblProduct.Columns["ProductId"] };

            // 2. Create Columns and Add those Columns in Table
            DataColumn colProductName = new DataColumn();
            // 2a. Set Column Name
            colProductName.ColumnName = "ProductName";
            // 2b. Set Column DataTyp
            colProductName.DataType = typeof(String);
            colProductName.MaxLength = 200;
            // 2c. Make column Unique
            colProductName.Unique = false;
            // 2d. Make column as not null
            colProductName.AllowDBNull = false;
            // 2d. Add COlumn in DataColumnCollection of DataTable
            tblProduct.Columns.Add(colProductName);


            // 3. Create Rows for Table
            // 3a Create a New Row Object for the Table
            DataRow dr = tblProduct.NewRow();
            // 3b. Add Column Vaues
           // dr["ProductId"] = 101;
            dr["ProductName"] = "Laptop";
            // 3c. Add the row in Rows Collection of DataTable
            tblProduct.Rows.Add(dr);


              dr = tblProduct.NewRow();
            // 3b. Add Column Vaues
            // dr["ProductId"] = 101;
            dr["ProductName"] = "Desktop";
            // 3c. Add the row in Rows Collection of DataTable
            tblProduct.Rows.Add(dr);

            // 4. Add Table in DataSet
            Ds.Tables.Add(tblProduct);

            Console.WriteLine(Ds.GetXmlSchema());
            Console.WriteLine();
            Console.WriteLine(Ds.GetXml());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CS_ADO_NET_Disconnected_CRUD
{
    public class DataAccessRelations
    {
        SqlConnection Conn;
        SqlDataAdapter AdDept, AdEmp;
        DataSet Ds;

        public DataAccessRelations()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=ExpensesRHeal;Integrated Security=SSPI");
        }

        public void SetDataRelation()
        {
            Ds = new DataSet();
            AdDept = new SqlDataAdapter("Select * from Dept",Conn);
            AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdDept.Fill(Ds, "Dept");


            AdEmp = new SqlDataAdapter("Select * from Emp",Conn);
            AdEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdEmp.Fill(Ds,"Emp");


            // Set the Relation Between Dept as Parent and Emp as Child based on the Primary / Key and
            // Foreign Key Relationship

            DataRelation DeptEmp = new DataRelation("DeptEmp",
                Ds.Tables["Dept"].Columns["DeptNo"], 
                Ds.Tables["Emp"].Columns["DeptNo"]);
            // Add the Relationship into DataSet
            Ds.Relations.Add(DeptEmp);


            // Read all Rows from the Child Table
             DataRowCollection drCollection =  Ds.Relations["DeptEmp"].ChildTable.Rows;

            foreach (DataRow item in drCollection)
            {
                Console.WriteLine($"{item["EmpNo"]} {item["EmpName"]} {item["Designation"]} {item["Salary"]} {item["DeptNo"]}");
            }   


            //Console.WriteLine($"Parent Table {DeptEmp.ParentTable.TableName}" );
            //Console.WriteLine($"Parent Table {DeptEmp.ChildTable.TableName}");

            //Console.WriteLine(Ds.GetXmlSchema());
            //Console.WriteLine(Ds.GetXml());


        }
    }
}

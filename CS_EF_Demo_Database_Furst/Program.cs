using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Demo_Database_Furst
{
    class Program
    {
        static void Main(string[] args)
        {

            // reate an instance of DeptDatabaseOPerations class
            IDataOperations<Dept, int> deptOp = new DepDatabaseOperations();

            // read all records
            var depts = deptOp.GetData();
            foreach (Dept dept in depts)
            {
                Console.WriteLine($"{dept.DeptNo} {dept.DeptName} {dept.Location} {dept.Capacity}");
            }
            Console.WriteLine();
            // add new Record
            var deptNew = new Dept() { DeptNo = 901, DeptName = "Dept-901", Location="Pune", Capacity = 9000 };
            deptOp.Create(deptNew);

            Console.WriteLine("List of Dept after adding new record");
            // list the newly added record
            depts = deptOp.GetData();
            foreach (Dept dept in depts)
            {
                Console.WriteLine($"{dept.DeptNo} {dept.DeptName} {dept.Location} {dept.Capacity}");
            }
            Console.WriteLine();
            // search record based on P.K.
            var deptSearch = deptOp.GetData(901);
            Console.WriteLine($"Searched data {deptSearch.DeptNo} {deptSearch.DeptName} {deptSearch.Location} {deptSearch.Capacity}");
            Console.WriteLine();
            // update the data
            var deptTpUpdate = new Dept() { DeptNo = 901, DeptName = "Dept-901", Location = "Pune-Bavdhan", Capacity = 9000 };
            
            deptOp.Update(deptTpUpdate.DeptNo, deptTpUpdate);
            
            Console.WriteLine("List of Dept after Updating new record");
            // list the newly added record
            depts = deptOp.GetData();
            foreach (Dept dept in depts)
            {
                Console.WriteLine($"{dept.DeptNo} {dept.DeptName} {dept.Location} {dept.Capacity}");
            }
            Console.WriteLine();

            // delete the record
            deptOp.Delete(901);
            Console.WriteLine("List of Dept after Deleting new record");
            // list the newly added record
            depts = deptOp.GetData();
            foreach (Dept dept in depts)
            {
                Console.WriteLine($"{dept.DeptNo} {dept.DeptName} {dept.Location} {dept.Capacity}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}

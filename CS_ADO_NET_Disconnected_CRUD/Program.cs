using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ADO_NET_Disconnected_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {

            // DataAccess dataAccess = new DataAccess();

            //var departments = dataAccess.GetDepartments();
            //Console.WriteLine("DeptNo\tDeptName\tLocation\tCapacity");
            //foreach (Dept dept in departments)
            //{
            //    Console.WriteLine($"{dept.DeptNo}\t{dept.DeptName}\t{dept.Location}\t{dept.Capacity}");
            //}

            //dataAccess.AddDept(new Dept() {
            //   DeptNo = 901, DeptName ="Dept-Secret",Location ="Area 51", Capacity=90000
            //});


            //dataAccess.UpdateDepartment(new Dept()
            //{
            //    DeptNo = 901,
            //    DeptName = "Dept-Secret-Info",
            //    Location = "Area 101",
            //    Capacity = 90000
            //});

            // dataAccess.DeleteDepartment(901);

            DataAccessRelations relations = new DataAccessRelations();
            relations.SetDataRelation();


            Console.ReadLine();
        }
    }
}

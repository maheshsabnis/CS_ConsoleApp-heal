using System;
using CS_ConsoleApp.MyNamespace; 
/// <summary>
/// Each Project contains atleast one top level namespace
/// </summary>
namespace CS_ConsoleApp
{
    /// <summary>
    /// An Entrypoint for executing the application
    /// Program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// The first method to be executed by 
        /// Execution Engine (?)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#"); // Print the Message   
            Console.WriteLine("Enter x");
            // convert the value into integer 
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter y");
            // convert the value into integer 
            int y = Convert.ToInt32(Console.ReadLine());

            // Create an instance of the Class MyMath 
            MyMath m = new MyMath();
            int addresult = m.Add(x,y);
            // Concate the String with Integer
            Console.WriteLine("Add = " + addresult);
            // Use the String Interpolation or aka Template String
            Console.WriteLine($"Add = {addresult}");
            int substresult = m.Subst(x,y);
            Console.WriteLine($"Subsct = {substresult}");


            Person per = new Person();
            per.PersonId = 1001; // call setter
            per.PersonName = "Mahesh"; // call setter
            per.Age = 44; // call setter

            // call getter
            Console.WriteLine($"Person Info PersonId = {per.PersonId}" +
                $"PersonName = {per.PersonName}" +
                $"Age =  {per.Age}" +
                $"Major / Minor = {per.PersonMajorMinor}");

            Employee emp = new Employee();
            emp.EmpNo = 102;
            emp.EmpName = "Mahesh";

            Console.WriteLine($"EMpNO = {emp.EmpNo} EmpNAme = {emp.EmpName}");

            Console.ReadLine(); // read a line
        }
    }
}

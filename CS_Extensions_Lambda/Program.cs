using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CS_Extensions_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {

            MathOps m = new MathOps();
            Console.WriteLine($"Add = {m.Add(30,40)}");
            Console.WriteLine($"Mult = {m.Mult(30, 40)}");

            Console.WriteLine($"Add = {m.AddSquare(30, 40)}");
            Console.WriteLine($"Mult = {m.MultSquare(30, 40)}");

            string str = "James Bond";
            Console.WriteLine($"Length of {str} = {str.Length}");

            Console.WriteLine($"Reverse of {str} = {str.ExtReverse()}");

            Console.ReadLine();
        }
    }
}

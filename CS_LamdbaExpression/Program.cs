using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CS_LamdbaExpression
{
    // declare delegate at namecpace level
    public delegate int InvokeHandler(int x);

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Direct call to method
            Console.WriteLine($"Increament Direct call {Increament(100)} ");
            // 2. To invoke method using delegate create an instance of delegate
            // type and pass method address to it
            InvokeHandler handler = new InvokeHandler(Increament);
            // Invoke the method by passing the parameter to the delegate instance
            Console.WriteLine($"Increament using Delegate {handler(100)}");

            // 3. Using the Bridge method execute the delegate
            InvokeHandler handler1 = new InvokeHandler(Increament);
            Bridge(handler1);

            // 4. Use the delegate to directly contain and hide implementation
            // Anonymous method
            // Directly compiled and executed in Binary
            InvokeHandler handler2 =  delegate (int x) {
                return x + 10; 
            };
            Console.WriteLine("Anonymous methods C# 2.0");
            Bridge(handler2); 
            Console.WriteLine();

            Console.WriteLine("Anonymous methods C# 2.0 with simpler syntax");
            Bridge(delegate(int x) { return x + 100; });

            Console.WriteLine();

            Console.WriteLine("Lambda Expression C# 3.0");
            // x goes into the method and return x + 1200
            Bridge((x)=> { return x + 1200; });

            Console.ReadLine();
        }

        /// <summary>
        /// Bridge () methoos is a brighe between Main() and Increament()
        /// </summary>
        /// <param name="h"></param>
        static void Bridge(InvokeHandler h)
        {
            Console.WriteLine($"The Result from Delegate {h(200)}");
        }

        static int Increament(int x)
        {
            return x + 10;
        }
    }

   
}

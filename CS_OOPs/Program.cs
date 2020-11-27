using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CS_OOPs
{
    class Program
    {
        static void Main(string[] args)
        {
            DeriveClass d = new DeriveClass();
            d.M1(); // call Derive class method
            DeriveClass d1 = new DeriveClass();
            // runtime type casting because DerivedClass is derived fromm BaseClass
            ((BaseClass)d1).M1(); // call base class method because of type casting

            
            // up-casting
            // defining the instance of Base class using 
            // the derive class
            Vehicle b = new Bullet();
            Console.WriteLine($"Average of Bullet = {b.Average(100, 4)}");
            Console.WriteLine($"Fuel Voplume of Bullet is {b.FuelVolume()} liters");
            // Vehicle m = new Maruti();
            // reusing an abstract class reference
            b = new Maruti();
            Console.WriteLine($"Average of Maruti = {b.Average(100, 4)}");
            Console.WriteLine($"Fuel Voplume of Maruti is {b.FuelVolume()} liters");


            Console.ReadLine();
        }
    }

    public class BaseClass
    {
        public void M1()
        {
            Console.WriteLine("Base M1");
        }
    }

    public class DeriveClass : BaseClass
    {
        // M1() is hiding the matching method from the base class
        // aka shadowing
        public new void M1()
        {
            Console.WriteLine("Derive M1");
        }
    }



    public abstract  class Vehicle
    {
        public virtual int Average(int dist, int lit)
        {
            return dist / lit;
        }
        public abstract int FuelVolume();
    }

    public class Bullet : Vehicle
    {
        public override int Average(int dist, int lit)
        {
            return base.Average(dist, lit) / 2; // overriden implementation
        }
        public override int FuelVolume()
        {
            return 100;
        }
    }

    public class Maruti : Vehicle
    {
        public override int Average(int dist, int lit)
        {
            return base.Average(dist, lit) / 4; // overriden implementation
        }
        public override int FuelVolume()
        {
            return 200;
        }
    }
}

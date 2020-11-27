using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ObjectDep_ednency
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassA a = new ClassA(); 
            ClassB b = new ClassB(a); 
            ClassC c = new ClassC(b);
            Console.ReadLine();
        }
    }

    public class ClassA
    {
        public void DoWork()
        {
           
            Console.WriteLine("DoWork A");
        }
    }

    public class ClassB
    {
        private ClassA objA;
        /// <summary>
        /// Pass the instance of ClassA to the ctor of ClassB
        /// Means ClassB is dependent on ClassA
        /// </summary>
        /// <param name="a"></param>
        public ClassB(ClassA a)
        {
            objA = a;
        }
        public void DoWork()
        {
            Console.WriteLine("DoWork B");
            objA.DoWork();
        }
    }

    public class ClassC
    {
        private ClassB objB;
        /// <summary>
        /// Pass the instance of ClassB to the ctor of ClassC
        /// Means ClassC is dependent on ClassB
        /// </summary>
        /// <param name="a"></param>
        public ClassC(ClassB b)
        {
            objB = b;
        }
        public void DoWork()
        {
            Console.WriteLine("DoWork C");
            objB.DoWork();
        }
    }
}

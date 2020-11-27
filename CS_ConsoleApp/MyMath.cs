using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CS_ConsoleApp.MyNamespace
{
    public class MyMath
    {
        // data members of class
        private int x, y, z;

        /// <summary>
        /// a and b are formal parameters
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Add(int a, int b)
        {
            x = a;
            y = b;
            z = x + y;
            return z;
        }

        public int Subst(int a, int b)
        {
            x = a;
            y = b;
            z = x - y;
            return z;
        }

    }
}

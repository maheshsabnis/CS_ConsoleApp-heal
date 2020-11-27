using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Extensions_Lambda
{
    public sealed class MathOps
    {
        public  int Add(int x, int y)
        {
            return x + y;
        }

        public int Mult(int x, int y)
        {
            return x * y;
        }
    }
    /// <summary>
    /// the extension method class
    /// </summary>
    public static class MathOpsNew  
    {
        public static  int AddSquare(this MathOps m, int x, int y)
        {
            return (x*x) + (y*y);
        }

        public static int MultSquare(this MathOps m,  int x, int y)
        {
            return (x*x) * (y*y);
        }

        public static string ExtReverse(this string s)
        {
            string result = null;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                result += s[i];
            }
            return result;
        }
    }
}

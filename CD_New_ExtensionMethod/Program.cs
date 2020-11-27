using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_New_ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Income Account");
            double income = Convert.ToDouble(Console.ReadLine());
            TaxAccounting c = new TaxAccounting();
            Console.WriteLine($"TDS = {c.CalculateTDS(income)}");
            Console.WriteLine($"GST = {c.CalculateGST(income)}");
            string str = "Mahesh Rameshrao Sabnis";
            char ch = 'a';

            int frequency = str.FindCharacterFrequency(ch);
            Console.WriteLine($"Frequenct of {ch} in {str} = {frequency}");
            

            Console.ReadLine();
        }
    }


    public sealed class TaxAccounting
    {
        public double CalculateTDS(double Salary)
        {
            return Salary * 0.1;
        }
    }

    public static class TaxAccountingExtension 
    {
        public static double CalculateGST(this TaxAccounting t, double billAmount)
        {
            return billAmount * 0.18;
        }
    
    }

    public static class StringExtensions
    {
        public static int FindCharacterFrequency(this string s, char c)
        {
            int frequency = 0;
            foreach (char v in s)
            {
                if (v == c)
                {
                    frequency++;
                }
            }
            return frequency;
        }
    }
}

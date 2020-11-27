using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_LINQ_New
{
    class Program
    {
        static void Main(string[] args)
        {
             
            // string is a collection of Characters B
            string [] Names = new string[] { "Mahesh", "Rameshrao", "Sabnis",
                "Jim", "Jill", "Mack", "James", "Sean", "Connary", "Pierce", "Brosnon",
            "Roger", "Moore", "Trimothy", "Dalton", "George", "Luznaby","Danial", "Craig"};

            //foreach (var str in Names)
            //{
            //    if (str.Length >= 7 && str.Contains('a') && str.StartsWith("R"))
            //    {
            //        Console.WriteLine(str);
            //    }
            //}
            // return al, stringshaving length greater than equal to 7
            var res_gt_7 = Names.Where(str=>str.Length >= 7);
            Console.WriteLine();
            Console.WriteLine("Greater than EQ 7");
            Console.WriteLine();
            foreach (var item in res_gt_7)
            {
                Console.WriteLine(item);
            };
            Console.WriteLine();
            Console.WriteLine("Stroimg contains 'a' ");
            Console.WriteLine();
            var res_comntains_a = res_gt_7.Where(str=>str.Contains('a'));
            foreach (var item in res_comntains_a)
            {
                Console.WriteLine(item);
            };
            Console.WriteLine();
            Console.WriteLine("Start from 'R' ");
            Console.WriteLine();
            var res_starts_From_R = res_comntains_a.Where(str => str.StartsWith("R"));
            foreach (var item in res_starts_From_R)
            {
                Console.WriteLine(item);
            };


            Console.WriteLine();
            Console.WriteLine("Putting all Together");

            var combineResult = Names.Where(str => str.Length >= 7)
                                      .Where(str => str.Contains('a'))
                                      .Where(str => str.StartsWith("R"));
            Console.WriteLine();
            foreach (var item in combineResult)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Standard LINQ Syntax");
            var combineLINQ = from str in Names
                              where str.Length >= 8 && str.Contains('a')
                                && str.StartsWith("R")
                              select str;
            foreach (var item in combineLINQ)
            {
                Console.WriteLine(item);
            }

             
            

            Console.ReadLine();
        }
    }





}

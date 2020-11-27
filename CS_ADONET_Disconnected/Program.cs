using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ADONET_Disconnected
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            // dataAccess.FillData();
            dataAccess.CreateDataSetSchemaUsingTableUsingCode();
            Console.ReadLine();
        }
    }
}

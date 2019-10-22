using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemedialOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var things = new Bunch<string>();
            things.Add("Dan");
            things.Add("Jeff");
            things.Add("Don");
            Console.WriteLine($"There are {things.Count} names in my list");
            Console.ReadKey();
        }
    }
}

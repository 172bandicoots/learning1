using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "Computer";
            Console.WriteLine(a + " Says HELLO WORLD \n\n Please enter your name:");
            Console.WriteLine("Hello " + Console.ReadLine());
            Console.WriteLine("\n \n You can press any key to exit.");
            Console.ReadLine(); //pause
        }
    }
}

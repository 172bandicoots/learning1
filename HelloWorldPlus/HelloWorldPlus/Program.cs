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
            string a = "Computer";  //assign a value to string variable
            Console.WriteLine(a + " Says HELLO WORLD \n\n Please enter your name:"); //output line to screen
            Console.WriteLine("Hello " + Console.ReadLine());  //output line to screen + prompt for input
            Console.WriteLine("\n \n You can press any key to exit.");
            Console.ReadLine(); //pause  takes input from the command line
        }
    }
}

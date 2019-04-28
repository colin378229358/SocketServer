using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppWeb.WebReference;

namespace ConsoleAppWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            string a="1";
            string b="2";
            WebReference.WebService1 webService1=new WebService1();
            Console.WriteLine(webService1.HelloWorld());
            Console.WriteLine(webService1.Add(a,b));
            Console.ReadKey();
        }
    }
}

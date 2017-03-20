using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenApple
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1.Run(args);
            
            Test2<int> Observer = new Test2<int>();
            Observer.StateChanged += (obj) => { Console.WriteLine("Notified of {0}!".f(obj)); };

            var logger = new FileSystemLogger("log.txt");
            var test3 = new Test3(logger);
            Console.WriteLine(test3.getString("some of us"));

            Test4 parser = new Test4("n", new char[] { ';' });
            parser.Parse("n1;n2;n3;n4")
                .ToList().ForEach(x => Console.WriteLine(x));
            parser.Parse("n1;n2;n3;n4;")
                .ToList().ForEach(x => Console.WriteLine(x));
            try
            {
                parser.Parse("n1;n666666666666666;n3;n4")
                    .ToList().ForEach(x => Console.WriteLine(x));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HResult);
            }
        }
    }
}
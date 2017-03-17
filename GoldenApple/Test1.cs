using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenApple
{
    class Test1
    {
        //private int m_Variable;
        //public int Variable
        //{
        //    get { return Variable; }
        //    set { Variable = value; }
        //}

        //if we not use accessors, why we declare them (also, with overflow)?
        public int Variable { get; set; }

        static void Main(string[] args)
        {
            Test1 obj;
            //CS0165  Use of unassigned local variable 'obj'
            //obj = new Test1();
            obj.Variable = 5;
            Console.WriteLine(obj.Variable);
        }
    }
}

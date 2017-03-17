using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenApple
{
    class Test2<T>
    {
        /// <summary>
        /// Lol
        /// <seealso cref="https://en.wikipedia.org/wiki/Observer_pattern"/>
        /// </summary>
        public event Action<T> StateChanged;
    }
}
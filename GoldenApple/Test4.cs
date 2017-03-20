using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenApple
{
    public class Test4
    {
        protected string _controlChar;
        protected char[] _delimiter;

        public Test4(string controlChar,char[] delimiter)
        {
            this._controlChar = controlChar;
            this._delimiter = delimiter;
        }
        /// <summary>
        /// parse string with pre-settings
        /// </summary>
        /// <param name="input">string for parse</param>
        /// <exception cref="FormatException"></exception>
        /// <returns>array of parsed values</returns>
        public int[] Parse(string input)
        {
            return input.Split(this._delimiter, StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    var value = x.Replace(this._controlChar, "");
                    int result = -1;
                    if (!int.TryParse(value, out result))
                    {
                        var index = input.IndexOf(x);
                        throw new FormatException("Collection item is incorrect, index: {0}".f(index));
                    }
                    return result;
                })
                .OrderByDescending(x => x)
                .ToArray();
        }
    }
}

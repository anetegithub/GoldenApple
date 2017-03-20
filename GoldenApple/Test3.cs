using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenApple
{
    /// <example>
    /// <code>
    /// var logger = new FileSystemLogger("log.txt");
    /// var test3 = new Test3(logger);
    /// Console.WriteLine(test3.getString("some of us"));
    /// </code>
    /// </example>
    public class Test3
    {
        ILogger<string> logger;

        public Test3(ILogger<string> logger)
        {
            this.logger = logger;
        }

        [Obsolete("Use 'getString' instead",true)]
        public string GetString(string param)
        {            
            var sw = new StreamWriter("log.txt", true);
            sw.WriteLine("{0:G}: param = \"{1}\"", DateTime.Now, param);
            sw.Close();
            return string.Format("Your param is {0}", param);
        }
        
        public string getString(string param)
        {
            logger.Log(param);

            return "Your param is {0}".f(param);
        }        
    }
    
    public static class Extensions
    {
        public static string f(this string s, params object[] args)
        {
            //a little bit slower, but more clearly
            return string.Format(s, args);
        }
    }

    public class ConsoleNotifier : INotifier<string>
    {
        private ConsoleNotifier() { }

        public static bool Notify(string data)
        {
            var notifier = new ConsoleNotifier();
            return notifier.notify(data);
        }

        public bool notify(string data)
        {
            try
            {
                Console.WriteLine(data);
                return true;
            }
            catch { return false; }
        }
    }

    public interface ILogger<Tin>
    {
        bool Log(Tin data);
    }

    public class FileSystemLogger : ILogger<string>
    {
        string _filename;
        public FileSystemLogger(string filename)
        {
            this._filename = filename;
        }

        public bool Log(string data)
        {
            try
            {
                var value = "{0:G} >> param = \"{1}\"".f(
                    DateTime.Now,
                    data);
                File.WriteAllText(_filename, value);
                return true;
            }
            catch (Exception ex)
            {
                if (!ConsoleNotifier.Notify(ex.ToString()))
                    throw;
                else
                    return false;
            }
        }
    }
}

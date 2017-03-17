using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenApple
{
    public class Test3
    {
        public string GetString(string param)
        {            
            var sw = new StreamWriter("log.txt", true);
            sw.WriteLine("{0:G}: param = \"{1}\"", DateTime.Now, param);
            sw.Close();
            return string.Format("Your param is {0}", param);
        }

        public string getString(string param)
        {
            var logger = new FileSystemLogger("log.txt");
            logger.log(param);

            return "Your param is {0}".f(param);
        }        
    }
    
    public static class Extensions
    {
        public static string f(this string s, params object[] args)
        {
            //a little bit slower, but clearly
            return string.Format(s, args);
        }
    }

    public interface INotifier<T>
    {
        bool notify(T data);
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

    public interface ILogger<T>
    {
        bool log(T data);
    }

    public class FileSystemLogger : ILogger<string>
    {
        string _filename;
        public FileSystemLogger(string filename)
        {
            this._filename = filename;
        }

        public bool log(string data)
        {
            try
            {
                File.WriteAllText(_filename, data);
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

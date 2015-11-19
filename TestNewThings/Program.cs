using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNewThings
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = new FirstClass();
            
            obj1.AddString("Hello");
            var obj2 = new FirstClass();
            obj2.AddString("hello world");

            var obj3 = new SecondClass();
            obj3.AddString("hej hej");

            Console.WriteLine(obj1.StringList<FirstClass>().ToListString());
            Console.WriteLine(obj2.StringList<FirstClass>().ToListString());
            Console.WriteLine(obj3.StringList<SecondClass>().ToListString());
            Console.ReadKey();
        }


    }
    public static class Extensions
    {
        public static string ToListString(this List<string> strs)
        {
            var output = "";
            foreach (var str in strs)
            {
                output += str + " ";
            }
            return output;
        }
        public static List<string> GetStringList<T>(this T obj) where T : BaseClass
        {
            var type = typeof (T);
            var props = type.GetField("staticStr");
            
            return (List<string>)props.GetValue(null);
            //return (List<string>)props.GetValue();
        } 
    }
    public abstract class BaseClass
    {

        public List<string> StringList<T>() where T : BaseClass
        {
            return ((T)this).GetStringList();
        }
       
    }

    public class FirstClass : BaseClass
    {
        public static List<string> staticStr = new List<string>();

        public void AddString(string hello)
        {
            staticStr.Add(hello);
        }
    }
    internal class SecondClass : BaseClass
    {
        public static List<string> staticStr = new List<string>();

        public void AddString(string hello)
        {
            staticStr.Add(hello);
        }
    }

   
}

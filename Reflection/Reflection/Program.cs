using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Reflection
{
    interface IOoop
    {
        void Working();
    }
    class Software : IOoop
    {
        public int number = 0;
        private string Name;
        private double Version;
        private string Destination;

        public Software()
        {
 
        }
        public Software(string name, string destination, double version)
        {
            Version = version;
            Destination = destination;
            Name = name;
        }
        public void POInformation()
        {
            Console.WriteLine($"Name: {Name}, Destination: {Destination}, Version: {Version}.");
        }
        public void Work(string name)
        {
            Console.WriteLine($"{name} is working.");
        }
        public void Upgrade()
        {
            Version += 0.2;
            Console.WriteLine($"The company released a new version of the {Name} : {Version}.");
        }
        public string name
        {
            get
            {
                return Name;
            }
        }
        public void Working() { }
    }
    static class Reflector
    {
        static Software s = new Software("fgb", "gtr " , 1.44);

        static public void IntoFile(string name)
        {
            StreamWriter writer = new StreamWriter("d:/Information.txt", false);
            Type t = s.GetType();
            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            writer.WriteLine("namespace - {0}\n", t.Namespace);
            writer.WriteLine("full name - {0}\n", t.FullName);
            writer.WriteLine("base type - {0}\n", t.BaseType);
            writer.WriteLine("–––––––––––––––––--––––\n");
            writer.WriteLine($"\nМетоды класса {name}");
            MethodInfo[] methods = t.GetMethods();
            foreach (MethodInfo method in methods)
            {
                writer.WriteLine("- {0}", method.Name);
            }
            writer.WriteLine("–––––––––––––––––--––––\n");
            writer.WriteLine($"Поля класса {name}");
            FieldInfo[] fi = t.GetFields(flags);
            foreach (FieldInfo field in fi)
            {
                writer.WriteLine("- {0}", field.Name);
            }
            writer.WriteLine("––––––––––––––––---–––––\n");
            writer.WriteLine($"Информация о классе {name}");
            writer.WriteLine("Базовый класс - {0}", t.BaseType);
            writer.WriteLine("Абстрактный?: {0}", t.IsAbstract);
            writer.WriteLine("Защищённый класc?: {0}", t.IsSealed);
            writer.WriteLine("–––––––––––––––––––––––––––\n");
            writer.WriteLine($"Свойства класса {name}");
            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo prop in pi)
            {
                writer.WriteLine(" - {0}", prop.Name);
            }
            writer.WriteLine("–––––––––––––––––––––––––––\n");
            writer.Close();
        }

        static public void GetMethods(string name)
        {
            var flags = BindingFlags.Public;
            Type myType = s.GetType();
            Console.WriteLine($"\nМетоды класса {name}\n");
            MethodInfo[] methods = myType.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    Console.Write($"- {method.Name}\n");
                }
        }

        static public void GetFieldAndProperties(string name)
        {
            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            Type myType = s.GetType();
            Console.WriteLine($"\nПоля класса {name}\n");
            FieldInfo[] fi = myType.GetFields(flags);
            foreach (FieldInfo field in fi)
            {
                Console.Write($"- {field.Name}\n");
            }
            Console.WriteLine($"\nСвойства класса {name}\n");
            PropertyInfo[] pi = myType.GetProperties();
            foreach (PropertyInfo prop in pi)
            {
                Console.Write($" - {prop.Name}\n");
            }
        }

        static public void GetInterfaces(string name)
        {
            Type myType = s.GetType();
            Type[] ifaces = myType.GetInterfaces();
            Console.WriteLine($"\nИнтерфейсы класса {name}\n");
            foreach (Type i in ifaces)
            {
                Console.Write($"- {i.Name}");
            }

        }

        static public void GetMethodsWithType(string name, string nameParameter)
        {
            ArrayList arrayList = new ArrayList(6);
            var flags = BindingFlags.Public;
            Type myType = arrayList.GetType();
            Console.WriteLine($"\n\nМетоды класса {name} с типом параметра {nameParameter}\n");
            MethodInfo[] methods = myType.GetMethods();
            foreach (MethodInfo m in methods)
            {
                ParameterInfo[] p = m.GetParameters();
                foreach (ParameterInfo per in p)
                {
                    if (per.ParameterType.Name == nameParameter)
                    {
                        Console.Write(" --> " + m.ReturnType.Name + " \t" + m.Name + "(");
                        for (int i = 0; i < p.Length; i++)
                        {
                            Console.Write(p[i].ParameterType.Name + " " + p[i].Name);
                            if (i + 1 < p.Length) Console.Write(", ");
                        }
                        Console.Write(")\n");
                    }
                }
            }
        }

        static public void GetSpecialMethod(string name, string methodName)
        {
            string str;
            Type myType = s.GetType();

            FileStream fs = new FileStream("d:/read.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            str = sr.ReadLine();

            MethodInfo method = myType.GetMethod(methodName);
            if (method != null)
            {
                Console.WriteLine($"\n\nВызван метод {methodName} класса {name} с параметром {str}:");
                object object1 = method.Invoke( Activator.CreateInstance(myType), new object[] { str });
                Console.WriteLine(object1);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        { 
            Reflector.IntoFile("Software");
            Reflector.GetMethods("Software");
            Reflector.GetFieldAndProperties("Software");
            Reflector.GetInterfaces("Software");
            Reflector.GetMethodsWithType("ArrayList", "Int32");
            Reflector.GetSpecialMethod("Software", "Work");

            Console.ReadKey();
        }
    }
}

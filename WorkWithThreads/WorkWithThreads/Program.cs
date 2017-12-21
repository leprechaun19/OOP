using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace WorkWithThreads
{
    class Program
    {
        static string objlocker = "null";
        static void Main(string[] args)
        {
            int num = 0;
            int i = 1;
            StreamWriter wrt = new StreamWriter("d:/Processes.txt", false);

            //5
            TimerCallback tm = new TimerCallback(timer1);
            // создаем таймер
            Timer timer = new Timer(tm, num, 0, 7000);

            //1
            foreach (Process item in Process.GetProcesses())
            {
                wrt.WriteLine($"\t\t{i} процесс\n");
                wrt.WriteLine("Имя процесса:               " + item.ProcessName);
                wrt.WriteLine("Идентификатор процесса:     " + item.Id);
                wrt.WriteLine("Базовый приоритет процесса: " + item.BasePriority);
                i++;
            }

            //2
            AppDomain myDomain = AppDomain.CurrentDomain;
            Console.WriteLine("\tСведения о текущем домене приложения");
            Console.WriteLine("Имя текущего домена приложения: " + myDomain.FriendlyName + "\n" + "Идентификатор домена в процессе: " + myDomain.Id +
                "\n" + "Сведения о конфигурации:    " + myDomain.SetupInformation + "\n");

            Assembly[] assemblies = myDomain.GetAssemblies();
            Console.WriteLine("\tИмена сборок, загруженных в домен:");
            foreach (Assembly ass in assemblies)
            {
                Console.WriteLine(ass.FullName);
            }

            AppDomain newDomain = AppDomain.CreateDomain("New");
            //newDomain.Load("Programma.exe");
            AppDomain.Unload(newDomain);

            //3
            /*
            Thread myThread = new Thread(Counter);
            myThread.Start();
            Thread.Sleep(5000);
            myThread.Suspend();
            Console.WriteLine("Состояние потока: " + myThread.ThreadState);
            Console.WriteLine("myThread приостановлен");
            Thread.Sleep(5000);
            Console.WriteLine("Состояние потока: " + myThread.ThreadState);
            myThread.Resume();
            Console.WriteLine("myThread возобновлен");
            Console.WriteLine("Состояние потока: " + myThread.ThreadState);
            Thread.Sleep(2000);
            Console.WriteLine("Приоритет потока: " + myThread.Priority);
            Thread.Sleep(2000);
            Console.WriteLine("Состояние потока: " + myThread.ThreadState);
            Thread.Sleep(2000);
            Console.WriteLine("Состояние потока: " + myThread.ThreadState);*/

            //4a
            /*
            StreamWriter writ = new StreamWriter("d:\\2counter.txt", false);
                Thread Thread1 = new Thread(Count1);
                Thread1.Priority = ThreadPriority.BelowNormal;
                Thread1.Start(writ);
                Thread Thread2 = new Thread(Count2);
                Thread2.Start(writ);*/

            Console.ReadKey();
        }

        public static void Counter()
        {
            StreamWriter wrt = new StreamWriter("d:\\counter.txt", false);
            Console.WriteLine("\nВведите диапазон: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                wrt.WriteLine($"{i}");
                Console.WriteLine($"  {i}");
                Thread.Sleep(1000);
            }
            wrt.Close();
        }

        public static void Count1(object writer)
        {
            StreamWriter wrt = (StreamWriter)writer;
            for (int i = 1; i <= 30; i++)
            {
                wrt.WriteLine($"{i}");
                Console.WriteLine($"1 thread  {i}");
                i++;
                Thread.Sleep(1000);
            }
            wrt.Close();
        }

        public static void Count2(object writer)
        {
            StreamWriter wrt = (StreamWriter)writer;
            for (int i = 2; i <= 30; i++)
            {
                wrt.WriteLine($"{i}");
                Console.WriteLine($"2 thread  {i}");
                i++;
                Thread.Sleep(1000);
            }
            wrt.Close();
        }

        public static void timer1(object object1)
        {
            Console.WriteLine("\tТаймер сработал! Пора кушать!");
        }
    }
}

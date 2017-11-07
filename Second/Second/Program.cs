using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IDo
    {
         void coding();
    }
    abstract class Programmer
    {
        public virtual void coding() { }
    }
    class Student : Programmer, IDo
    {
        public Student()
        {

        }
        void IDo.coding()
        {
            Console.WriteLine("интерфейс");
        }
        public override void coding()
        {
            Console.WriteLine("класс");
        }
    }

            class Program
    {
        static void Main(string[] args)
        {
            Student Nikita = new Student();
            Nikita.coding();
            ((IDo)Nikita).coding();
            Console.ReadKey();
        }
    }
}

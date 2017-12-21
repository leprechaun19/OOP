using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Owner
    {
        private readonly int ID;
        private readonly string Name;
        private readonly string Company;
        public Owner(int ID, string Name, string Company)
        {
            this.ID = ID;
            this.Name = Name;
            this.Company = Company;
        }
    }
    static class MathObject
    {
        public static int Max(Queue queue)
        {
            int max = int.MinValue;
            for (int i = 0; i < queue.queue.Length; i++)
            {
                if (queue.queue[i] > max)
                    max = queue.queue[i];
            }
            return max;
        }
        public static int Min(Queue queue)
        {
            int min = int.MaxValue;
            for (int i = 0; i < queue.queue.Length; i++)
            {
                if (queue.queue[i] < min)
                    min = queue.queue[i];
            }
            return min;
        }
        public static int Sum(Queue queue)
        {
            int sum = 0;
            for (int i = 0; i < queue.queue.Length; i++)
            {
                sum += queue.queue[i];
            }
            return sum;
        }
        public static void Obnulenie(this Queue queue)
        {
            for (int i = 0; i < queue.queue.Length; i++)
            {
                if (queue.queue[i] < 0)
                {
                    queue.queue[i] = 0;
                }
            }
            queue.PrintQueue();
        }
        public static int FirstNumber(this string s)
        {
            string ans = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    ans += s[i];
                    i++;
                    while(s[i] >= '0' && s[i] <= '9' && i < s.Length)
                    {
                        ans += s[i];
                        i++;
                    }
                    break;
                }
            }

            if (ans.Length == 0)
            {
                Console.WriteLine("Alina");
                return 0;
            }
            return Convert.ToInt32(ans);
        }
    }
    class Queue
    {
        class Date
        {
            string day;
            string month;
            string year;
            public Date(string day, string month, string year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
        }
        private readonly Date date = new Date("11", "10", "2017");
        private readonly Owner owner = new Owner(1568744534, "Alina", "OAO Bank");
        public int[] queue;
        private int size;
        static public int counter = 5;
        public Queue(int size)
        {
            queue = new int[size];
            this.size = size;
        }
        public int Size
        {
            get
            {
                return size;
            }
        }
        public void PrintQueue()
        {
            for (int i = 0; i < queue.Length; i++)
            {
                Console.Write($"{queue[i]}    ");
            }
            Console.WriteLine();
        }
        public static Queue operator /(int ssize, Queue qqueue)
        {
            int newElement;
            Console.WriteLine("/ operation");
            if (qqueue.Size == counter)
            {
                Console.WriteLine("Очередь заполнена");
            }
            else
            {
                Console.WriteLine("Введите элемент:");
                newElement = int.Parse(Console.ReadLine());
                qqueue.queue[counter] = newElement;
                counter++;
                qqueue.PrintQueue();
            }
            return qqueue;
        }
        public static Queue operator ++(Queue quueue)
        {
            Console.WriteLine("++ operation\n");
            for (int i = 0; i < counter; i++)
            {
                quueue.queue[i] = quueue.queue[i + 1];
            }

            quueue.queue[counter] = 0;
            counter--;
            quueue.PrintQueue();
            return quueue;
        }
        public static Queue operator --(Queue queue)
        {
            return queue;
        }
        public static bool operator false(Queue queue)
        {
            int counter = 0;
            for (int i = 0; i < queue.queue.Length; i++)
            {
                if (queue.queue[i] % 2 == 0)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine($"В очереди нет четныч чисел");
                return false;
            }
            else
            {
                Console.WriteLine($"В очереди есть четные числа");
                return true;
            }
        }
        public static bool operator true(Queue queue)
        {
            int counter = 0;
            for (int i = 0; i < queue.queue.Length; i++)
            {
                if (queue.queue[i] % 2 == 0)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine($"В очереди есть четные числа");
                return true;
            }
            else
            {
                Console.WriteLine($"В очереди нет четныч чисел");
                return false;
            }
        }
        public int this[int i]
        {
            get
            {
                if (i >= queue.Length || i < 0)
                {
                    Console.WriteLine("Некорректно введен индекс.");
                    return 0;
                }
                return queue[i];
            }
            set
            {
                if (i >= queue.Length || i < 0)
                {
                    Console.WriteLine("Некорректно введен индекс. Не удается установить значение.");
                }
                else
                {
                    queue[i] = value;
                }
            }
        }
        public static explicit operator int(Queue queue)
        {
            int number = 0;
            for (int i = 0; i < queue.queue.Length; i++)
            {
                if (queue.queue[i] > 0)
                {
                    number++;
                }
            }
            return number;
        }
        
    }
    class Program
    {
        
        static void Main(string[] args)
        {
             void Line()
            {
                Console.WriteLine("______________________________");
            }

            Queue queue_1 = new Queue(10);
            Queue queue_2 = new Queue(0);
            for (int i = 0; i < 5; i++)
            {
                queue_1.queue[i] = int.Parse(Console.ReadLine());
            }
            queue_1.PrintQueue();

            Console.WriteLine("int(): " + (int)queue_1 + "\n");
            Line();

            Console.WriteLine(5 / queue_1);
            Line();

            Console.WriteLine(queue_1++);
            Line();

            if (queue_1)
            {
            }
            Line();

            Console.Write("Обнуление отрицательных чисел:\n");
            queue_1.Obnulenie();
            Line();

            string str = "I am 228 yea1337rs old. 1488";
            Console.WriteLine($"Строка - {str}");
            int num = str.FirstNumber();
            Console.WriteLine(num);

            Console.ReadKey();
        }
    }
}
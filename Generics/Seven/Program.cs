using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seven
{
    interface Ioperations<T>
    {
        void Add(T item);
        void Remove(int index);
        void Print();
    }

    class Client : IEquatable<Client>
    {
        private string Name;
        private string PassportNumber;
        private string IDNumber;

        public Client(string name, string passportNumber, string idNumber)
        {
            Name = name;
            PassportNumber = passportNumber;
            IDNumber = idNumber;
        }
        public override string ToString()
        {
            return String.Format($"Name - {Name}, \n ID number - {IDNumber}, \n Passport Number - {PassportNumber}\n");
        }
        public bool Equals(Client client)
        {
            if (Name == client.Name && PassportNumber == client.PassportNumber && IDNumber == client.IDNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Queue<T> : Ioperations<T> where T : IEquatable<T>
    {
        public List<T> list;
        public Queue()
        {
            list = new List<T>();
        }
        public int Size
        {
            get
            {
                return list.Count;
            }
        }
        public T this[int i]
        {
            set
            {
                if (i >= list.Count || i < 0)
                {
                    Console.WriteLine("Некорректно введен индекс. Не удается установить значение.");
                }
                else
                {
                    list[i] = value;
                }
            }
        }
        public void Add(T newItem)
        {
            list.Add(newItem);
        }
        public void Remove(int index)
        {
            if(index > list.Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                list.RemoveAt(index);
            }
        }
        public void Print()
        {
            foreach (T items in list)
            {
                Console.WriteLine(items.ToString());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Queue<int> intQueue = new Queue<int>();
                intQueue.Add(5);
                intQueue.Add(10);
                intQueue.Add(7);
                intQueue.Remove(1);
                intQueue.Print();

                Queue<Client> clientQueue = new Queue<Client>();
                clientQueue.Add(new Client("Алина", "fesgfv565gf", "23bgtgtt4y65tgr"));
                clientQueue.Add(new Client("Katya", "23243ffg56", "34gfb87dc7fhh5t8"));
                clientQueue.Add(new Client("Petr", "3jf84f73guf", "472hfe47hfr54hfh"));
                clientQueue.Print();

                Queue<string> stringQueue = new Queue<string>();
                stringQueue.Add("Александра");
                stringQueue.Add("Виктория");
                stringQueue.Add("Жанна");
                stringQueue.Print();
                stringQueue.Remove(10);
            }
            catch (IndexOutOfRangeException el)
            {
                Console.WriteLine("Index out of range exception\n");
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }
            Console.ReadKey();
        }
    }
}

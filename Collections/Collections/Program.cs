using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    
    class Program
    {
        class Client : IComparable<Client>, IComparer<Client>
        {

            private string name;
            private string PassportNumber;
            private string IDNumber;
            public Client(string Name, string passportNumber, string idNumber)
            {
                name = Name;
                PassportNumber = passportNumber;
                IDNumber = idNumber;
            }
            public override string ToString()
            {
                return String.Format($"Name: {Name}\nID number - {IDNumber}\nPassport Number - {PassportNumber}");
            }
            public string Name
            {
                get
                {
                    return name;
                }
            }
            public int CompareTo(Client client)
            {
                if (this.IDNumber == client.IDNumber)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            public int Compare(Client client1, Client client2)
            {
                if(client1.IDNumber == client2.IDNumber)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        static int GetRandomDigit()
        {
            Random rand = new Random();
            return (rand.Next(-100, 100));
        }
        static void RemoveDictionaryElement(Dictionary<long, string> dictionary, int n)
        {
            Dictionary<long, string>.KeyCollection keys = dictionary.Keys;
            for (int i = 0; i < n; i++)
            {
                dictionary.Remove(keys.First());
            }
        }
        static void RemoveDictionaryClientElement(Dictionary<long, Client> dictionaryC, int n)
        {
            Dictionary<long, Client>.KeyCollection keys = dictionaryC.Keys;
            for (int i = 0; i < n; i++)
            {
                dictionaryC.Remove(keys.First());
            }
        }
        static void Main(string[] args)
        {
            //1
            ArrayList list = new ArrayList();

            Random rand = new Random();
            int val = GetRandomDigit();
            list.Add(rand.Next(-100, 100));
            list.Add(rand.Next(-100, 100));
            list.Add(val);
            list.Add(rand.Next(-100, 100));
            list.Add(rand.Next(-100, 100));
            list.Add("Dogs love people.");
            list.RemoveAt(list.IndexOf(val));

            Console.WriteLine($"Количество элементов ArrayList = {list.Count}");
            foreach(object obj in list)
            {
                Console.WriteLine(obj);
            }
            //2
            int k = 1;
            Dictionary<long, string> menu = new Dictionary<long, string>
            {
                {1956399174,"coffee"}
            };
            menu.Add(4399239884, "potato");
            menu.Add(7433683, "spagetti");
            menu.Add(324567898, "tiramisu");
            menu.Add(190273693, "borch");
            menu.Add(454545683, "meat");
            menu.Add(1000903683, "bliny");
            menu.Add(765436445, "ice-cream");

            Console.WriteLine("                 Элементы обобщенной коллекции Dictionary:");
            foreach (KeyValuePair<long, string> dict in menu)
            {
                Console.WriteLine($"Ключ - {dict.Key}, значение - {dict.Value}");
            }

            RemoveDictionaryElement(menu, 3);
            menu[7294631974] = "pizza";

            Dictionary<long, string>.ValueCollection values = menu.Values;
            List<string> menu1 = new List<string>();
            foreach (string str in values)
            {
                menu1.Add(str);
            }

            Console.WriteLine("             Элементы обобщенной коллекции List:");
            foreach (string str in menu1)
            {
                Console.WriteLine($"{k} элемент - {str}");
                k++;
            }


            if (!menu1.Contains("meat"))
            {
                Console.WriteLine("     List не содержит элемента ice-cream");
            }
            else
            {
                Console.WriteLine("     List содержит элемент ice-cream");
            }

            //3
            int n = 1;
            Dictionary<long, Client> clientDictionary = new Dictionary<long, Client>
            {
                {42058009174, new Client("Alina", "8hgidh384ungh", "395jnvjgf484u")}
            };
            clientDictionary.Add(676669884, new Client("Alina", "29vnjred83rjh", "393nfjerjk9392nr"));
            clientDictionary.Add(22929683, new Client("Alexander", "7392hfhjv74th", "47ndjf73hfnri83"));
            clientDictionary.Add(134557898, new Client("Elena", "190x01tr22cx92", "fcj383utghe84r37r"));
            clientDictionary.Add(757384738, new Client("Maksim", "720xpwd73neo", "fh374yr87348i3"));
            clientDictionary.Add(71856583, new Client("Janna", "wi92pd4mf9e0j", "fhi3u4hr473ut8e"));

            Console.WriteLine("                 Элементы обобщенной коллекции Dictionary<Client>:");
            foreach (KeyValuePair<long, Client> diction in clientDictionary)
            {
                Console.WriteLine($"Ключ - {diction.Key}, значение - {diction.Value}");
            }

            RemoveDictionaryClientElement(clientDictionary, 2);
            clientDictionary[7294631974] = new Client("Bonie", "3298rjfri3r78", "fekj387ur34fn");

            Dictionary<long, Client>.ValueCollection valuesc = clientDictionary.Values;
            List<Client> menu2 = new List<Client>();
            foreach (Client cl in valuesc)
            {
                menu2.Add(cl);
            }

            Console.WriteLine("                 Элементы обобщенной коллекции List<Client>:");
            foreach (Client cl in menu2)
            {
                Console.WriteLine($"{n+1} элемент - {cl.ToString()}");
                n++;
            }

            //4
            ObservableCollection<Client> clientiki = new ObservableCollection<Client>();
            clientiki.CollectionChanged += Clientiki_CollectionChanged;

            clientiki.Add(new Client("Bonie", "3298djfri3r78", "fekj457ur34fn"));
            clientiki.RemoveAt(0);

            Console.ReadKey();
        }

        private static void Clientiki_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Client newUser = e.NewItems[0] as Client;
                    Console.WriteLine("\nДобавлен новый объект: {0}", newUser.Name);
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Client oldUser = e.OldItems[0] as Client;
                    Console.WriteLine("Удален объект: {0}", oldUser.Name);
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    Client replacedUser = e.OldItems[0] as Client;
                    Client replacingUser = e.NewItems[0] as Client;
                    Console.WriteLine("Объект {0} заменен объектом {1}",
                    replacedUser.Name, replacingUser.Name);
                    break;
            }
        }
    }
}

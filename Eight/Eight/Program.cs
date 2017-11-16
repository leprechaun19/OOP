using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight
{
    class Program
    {
        class User
        {
            public delegate void UpgradeEvent();
            public delegate void WorkEvent();

            public event UpgradeEvent Upgrade;
            public event WorkEvent Work;

            public User()
            {
                Upgrade = delegate { };
                Work = delegate { };
            }
            public void DoWork()
            {
                Work();
            }
            public void DoUpgrade()
            {
                Upgrade();
            }
        }

        class Software
        {
            private string Name;
            private double Version;
            private string Destination;

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
            public void Work()
            {
                Console.WriteLine($"{Name} is working.");
            }
            public void Upgrade()
            {
                Version += 0.2;
                Console.WriteLine($"The company released a new version of the {Name} : {Version}.");
            }
        }

        static void Main(string[] args)
        { 
            Software security = new Software("KasperskySecurity", "Antivirus", 7.0);
            Software player = new Software("Fast Player", "Media Player", 1.0);
            Software os = new Software("Marshmello", "Mobile Software", 6.0);

            security.POInformation();
            player.POInformation();
            os.POInformation();

            User Alina = new User();

            Alina.Upgrade += security.Upgrade;
            Alina.Upgrade += player.Upgrade;
            Alina.Upgrade += os.Upgrade;

            Alina.Work += security.Work;
            Alina.Work += player.Work;
            Alina.Work += os.Work;

            Console.WriteLine("\nРеакция на события\n");
            Alina.DoWork();
            Alina.DoUpgrade();

            Console.WriteLine("\nПосле события\n");
            security.POInformation();
            player.POInformation();
            os.POInformation();

            //использование алгоритмов вместе с блочными лямбда-выражениями
            Action<string[]> String = (string[] str) =>
            {
                str[0] += "Mini ., textik,.  dly ,obrabotki";
            };

            String += (string[] str) =>
            {
                string newStr = "";
                string del = "?/,!.:-;";
                for (int i = 0; i < str[0].Length; i++)
                {
                    bool isPunkt = false;
                    for (int j = 0; j < del.Length; j++)
                    { 
                        if (str[0][i] == del[j])
                        {
                            isPunkt = true;
                            break;
                        }
                    }
                    if (!isPunkt)
                    {
                        newStr += str[0][i];
                    }
                }
                str[0] = newStr;
            };

            String += (string[] str) => {
                string newStr = str[0][0].ToString();
                for (int i = 1; i < str[0].Length; i++)
                {
                    if (!(str[0][i] == ' ' && str[0][i - 1] == ' '))
                    {
                        newStr += str[0][i];
                    }
                }
                str[0] = newStr;
            };

            String += (string[] str) =>
            {
                str[0] = str[0].ToUpper();
            };

            string[] strr = new string[1];
            strr[0] = "Se-/n-!d-, ?            !! mes?/sa:ge ";

            Console.WriteLine($"\nСтрока: {strr[0]}\n");
            String(strr);
            Console.WriteLine($"Обработанная строка: {strr[0]}");

            Console.ReadKey();
        }
    }
}

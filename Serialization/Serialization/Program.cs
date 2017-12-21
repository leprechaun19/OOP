using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace Serialization
{
    [Serializable]
    [DataContract]
    public class Person
    {
        public int x = 1;
        [DataMember]
        public string FirstName;
        [DataMember]
        public string Surname;
        [DataMember]
        public string Address;

        public Person() { }
        public Person(string name, string surname, string address)
        {
            FirstName = name;
            Surname = surname;
            Address = address;
        }
        public override string ToString()
        {
            return String.Format($"name - {FirstName} {Surname}, address - {Address}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person Sasha = new Person("Sasha", "Gromov" , "str.Malinoeskaya h.78");
            Person Billy = new Person("Billy", "Anderson", "str.envkd h.45");
            Person Alexey = new Person("Alexey", "Michaylov", "str.Rokossovskogo h.103");
            Person[] people = new Person[] { Sasha, Billy, Alexey};

            //бинарная сериализация
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("d:/person.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Sasha);
            }

            //бинарная десериализация
            using (FileStream fss = new FileStream("d:/person.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine($"Бинарная десериализация");
                Person neww = (Person)formatter.Deserialize(fss);
                Console.WriteLine($"x -  {neww.x}\n {neww.ToString()}");
            }

            //soap сериализация
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fstream = new FileStream("d:/soap.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormatter.Serialize(fstream, people);
            }

            //soap десериализация
            using (FileStream fss = new FileStream("d:/soap.soap", FileMode.OpenOrCreate))
            {
                Console.WriteLine($"\nSOAP десериализация");
                Person[] ppl = (Person[])soapFormatter.Deserialize(fss);
                foreach (Person person in ppl)
                {
                    Console.WriteLine($"{person.ToString()}");
                }
            }

            //json сериализация
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Person[]));
            using (FileStream fstream = new FileStream("d:/peopl.json", FileMode.Create, FileAccess.Write))
            {
                jsonFormatter.WriteObject(fstream, people);
            }

            //json десериализация
            using (FileStream fss = new FileStream("d:/peopl.json", FileMode.OpenOrCreate))
            {
                Console.WriteLine($"\nJSON десериализация");
                Person[] pples = (Person[])jsonFormatter.ReadObject(fss);
                foreach (Person person in pples)
                {
                    Console.WriteLine($"{person.ToString()}");
                }
            }

            //xml сериализация
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Person[]));
            using (FileStream fstream = new FileStream("d:/people.xml", FileMode.Create, FileAccess.Write))
            {
                xmlFormatter.Serialize(fstream, people);
            }

            //xml десериализация
            using (FileStream fss = new FileStream("d:/people.xml", FileMode.OpenOrCreate))
            {
                Console.WriteLine($"\nXML десериализация");
                Person[] pples = (Person[])xmlFormatter.Deserialize(fss);
                foreach (Person person in pples)
                {
                    Console.WriteLine($"{person.ToString()}");
                }
            }

            //селекторы XPath
            XmlDocument xml = new XmlDocument();
            xml.Load("d:/people.xml");
            XmlElement xRoot = xml.DocumentElement;

            //1
            XmlNodeList childnodes1 = xRoot.SelectNodes("Person[1]");
            foreach (XmlNode node in childnodes1)
            {
                Console.WriteLine($"\nСелектор выбирает первый дочерний узел");
                Console.WriteLine(node.InnerText);
            }

            //2
            XmlNodeList childnodes = xRoot.SelectNodes("//Person/FirstName");
            Console.WriteLine($"\nСелектор выбирает значение поля FirstName у каждого узла");
            foreach (XmlNode node in childnodes)
            {
                Console.WriteLine(node.InnerText);
            }

            //LINQ to XML
            XDocument xmldoc = XDocument.Load("d:/people.xml");
            var items = from x in xmldoc.Element("ArrayOfPerson").Elements("Person")
                        where x.Element("Surname").Value == "Michaylov"
                        select x;

            Console.WriteLine($"\nВыбирает узел Person у которого значение Surname == Michaylov");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}

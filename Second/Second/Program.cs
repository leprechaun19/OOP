using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Car
    {
        private readonly uint ID;
        public string brand;
        public string model;
        private int yearOfRelease;
        public int cost;
        private string color;
        private string registrationNumber;
        private string Republic { get; } = "Belarus";
        private const int codeOfRepublic = 37;
        static int numberOfObjects = 0;
    }
        
    partial class Car
    { 
        //конструкторы
        static Car()
        {
            Console.WriteLine("________________________________________");
        }
        public Car(string br, string mod, int yeaar, int cos, string colr, string number) : this(cos)
        {
            brand = br;
            model = mod;
            yearOfRelease = yeaar;
            cost = cos;
            color = colr;
            registrationNumber = number;
            ID = (uint)(brand.GetHashCode() + model.GetHashCode());
            numberOfObjects++;
        }
        private Car(int Cost)
        {
            int typeInt = 77;
            if(Cost.GetType() == typeInt.GetType())
            {
                Console.Write("");
            }
        }
        //методы и свойства
        public override Boolean Equals(Object obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(GetType() == obj.GetType())
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        { 
            return model.GetHashCode() + brand.GetHashCode(); ;
        }
        public override string ToString()
        {
            Console.WriteLine();
            Console.WriteLine("                Информация об автомобиле");
            Console.WriteLine($"ID машины:             {ID}");
            Console.WriteLine($"Марка машины:          {brand}");
            Console.WriteLine($"Модель машины:         {model}");
            Console.WriteLine($"Год выпуска:           {yearOfRelease}");
            Console.WriteLine($"Стоимость:             {cost}");
            Console.WriteLine($"Цвет:                  {color}");
            Console.WriteLine($"Регистрационный номер: {registrationNumber}");
            Console.WriteLine($"Общее кол-во объектов: {numberOfObjects}");
            return base.ToString();
        }
        private int YearofRelease
        {
            set
            {
                if (value < 1700 || value > 2017)
                {
                    Console.WriteLine("Неверная дата");
                }
                else
                { yearOfRelease = value; }
            }
            get { return yearOfRelease; }
        }
        public int Age()
        {
            int age;
            age = 2017 - yearOfRelease;
            return age;
        }
        public static void Information()
        {
            int j;
            Type typ = typeof(Car);
            FieldInfo[] field = typ.GetFields();
            MethodInfo[] method = typ.GetMethods();
            PropertyInfo[] property = typ.GetProperties();

            Console.WriteLine("          Поля класса: ");
            for (j = 0; j < field.Length; j++)
            {
                Console.WriteLine($"  --{field[j].Name}");
            }

            Console.WriteLine("          Методы класса: ");
            for (j = 0; j < method.Length; j++)
            {
                Console.WriteLine($"   --{method[j].Name}");
            }

            Console.WriteLine("          Свойства класса: ");
            for (j = 0; j < property.Length; j++)
            {
                Console.WriteLine($"  --{property[j].Name}");
            }
        }
        public void NDS(ref int cost, int nds, out int newCost)
        {
            cost = cost + nds;
            newCost = cost;
        }
    }
            class Program
    {
        static void Main(string[] args)
        {
            
            string enteredName;
            string enteredModel;
            int period_of_use;
            int outParametr;
            int i;
            int count = 1;

            Car.Information();
            Car BMW = new Car("Bmw", "523i", 2010, 42259, "black", "YG47BJ4892AY29TN9");
            Car Chevrolet = new Car("Chevrolet", "Tahoe LTZ", 2012, 40883, "black", "O63GK6Q126UZZ29AA");

            //проверка методов
            Console.WriteLine($"Равны ли 2 объекта?      {BMW.Equals(Chevrolet)}");
            Console.WriteLine($"Тип bmw =                {BMW.GetType()}");
            Console.WriteLine($"Хэш-код chevrolet =      {Chevrolet.GetHashCode()}");
            Console.WriteLine($"Метод ToString() bmw =   {BMW.ToString()}");
            Console.WriteLine($"Цена chevrolet =         {Chevrolet.cost}");
            Chevrolet.NDS(ref Chevrolet.cost, 2000, out outParametr);
            Console.WriteLine($"Цена chevrolet после ref = {Chevrolet.cost}");

            Car[] cars = new Car[6];
            cars[0] = new Car("Citroen",     "C5",        2006, 23193,  "black", "UB771X8WYU090IOP4");
            cars[1] = new Car("Range Rover", "Evoque",    2011, 46386,  "white", "TG889041OL9TX4G6R");
            cars[2] = new Car("Lexus",       "GS 350 AWD",2015, 72321,  "silver","78BHG911GFU090ION");
            cars[3] = new Car("Nissan",      "Primera",   2003, 3193,   "blue",  "YUI5NH7631E7VC6G4");
            cars[4] = new Car("Citroen",     "A5",        2009, 33193,  "white", "NJ98YGH43S390OKO3");
            cars[5] = new Car("Lexus",       "Evoque",    2009, 56386,  "black", "TG8897939L9TX4G6R");


            Console.Write("\nВведите марку автомобиля: ");
            enteredName = Console.ReadLine();

            for (i = 0; i < cars.Length; i++)
            {
                if(enteredName == cars[i].brand)
                {
                    Console.Write($"\n                     {count}");
                    count++;
                    cars[i].ToString();
                }
                else { Console.WriteLine("Автомобилей данной марки нет!"); }
            }

            Console.Write("\nВведите модель автомобиля: ");
            enteredModel = Console.ReadLine();
            Console.Write("Введите минимальный срок эксплуатации: ");
            period_of_use = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            count = 1;
            for (i = 0; i < cars.Length; i++)
            {
                if (enteredModel == cars[i].model && cars[i].Age() > period_of_use)
                {
                    Console.Write($"\n                     {count}");
                    count++;
                    cars[i].ToString();
                }
                else
                {
                    Console.WriteLine("Автомобилей данной модели нет!");
                }
            }

            //анонимный тип
            var Cars = new {Brand = "Nestle", Model = "Chocolate", Cost = 2345 };
            Console.WriteLine($"\n Анонимный тип:{Cars}");

            Console.ReadKey();
        }
    }
}

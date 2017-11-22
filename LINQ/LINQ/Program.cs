using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{ 
    class Car
    {
        private readonly uint ID;
        private string brand;
        private string model; 
        private int yearOfRelease;
        private int cost; 
        private string color; 
        private string registrationNumber; 
        //конструкторы  
        public Car(string br, string mod, int yeaar, int cos, string colr, string number) 
        { 
            brand = br; 
            model = mod; 
            yearOfRelease = yeaar; 
            cost = cos; 
            color = colr; 
            registrationNumber = number; 
            ID = (uint) (brand.GetHashCode() + model.GetHashCode());
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
            return base.ToString(); 
        } 
        public int YearofRelease
        { 
            set 
            { 
               if (value< 1700 || value> 2017) 
                { 
                    Console.WriteLine("Неверная дата"); 
                } 
                else 
                { yearOfRelease = value; } 
            } 
            get { return yearOfRelease; } 
        } 
        public string Brand
        {
            get
            {
                return brand;
            }
        }
        public string Color
        {
            get
            {
                return color;
            }
        }
        public int Cost
        {
            get
            {
                return cost;
            }
        }
        public int Age()
        {
        int age;
        age = 2017 - yearOfRelease;
        return age;
        }
        public void NDS(ref int cost, int nds, out int newCost)
        {
        cost = cost + nds;
        Console.WriteLine("класс");
        newCost = cost;
        }
        public void Machine()
        {
            Console.WriteLine($"{brand}, {model}, {yearOfRelease}, {registrationNumber}, {cost}, {color}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1
            string[] months = { "January", "Febriary", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"};
            string[] SummerWinterMonths = { "June", "July", "August", "December", "January", "Febriary" };


            IEnumerable<string> request1 = months
                .Where(n => n.Length == 8);
            Console.WriteLine("     1 запрос, выбирающий последовательность месяцев с длиной строки равной 8");
            foreach (string str in request1)
            {
                Console.WriteLine(str);
            }


            IEnumerable<string> request2 = months
                        .Where(s => s.Length < 1);
            IEnumerable<string> request2_1;
            foreach (string st in SummerWinterMonths)
            { 
                request2_1 = months
                        .Where(s => s.Equals(st));
                request2 = request2.Concat(request2_1);
            }
            Console.WriteLine("     2 запрос, выбирающий из последовательности только зимние и летние месяцы"); 
            foreach (string str in request2)
            {
                Console.WriteLine(str);
            }


            IEnumerable<string> request3 = months
                .OrderBy(s => s);
            Console.WriteLine("     3 запрос, сортирующий последовательность в алфавитном порядке");
            foreach (string str in request3)
            {
                Console.WriteLine(str);
            }


            int count = months.Count(s => s.Contains("u"));
            Console.WriteLine($"     4 запрос, выводящий количество слов, содержащих 'u'\n{count}");


            IEnumerable<string> request5 = months
                .Where(s => s.Length > 4);
            Console.WriteLine("     5 запрос, выводящий послед-ть из слов длиной не менее 4");
            foreach (string str in request5)
            {
                Console.WriteLine(str);
            }

            //2
            List<Car> cars = new List<Car>();
            cars.Add(new Car("Citroen", "C5", 2006, 23193, "black", "UB771X8WYU090IOP4"));
            cars.Add(new Car("Range Rover", "Evoque", 2011, 46386, "white", "TG889041OL9TX4G6R"));
            cars.Add(new Car("Citroen", "GS 350 AWD", 2015, 72321, "silver", "78BHG911GFU090ION"));
            cars.Add(new Car("Nissan", "Primera", 2003, 3193, "blue", "YUI5NH7631E7VC6G4"));
            cars.Add(new Car("Citroen", "A5", 2009, 33193, "white", "NJ98YGH43S390OKO3"));
            cars.Add(new Car("Lexus", "Evoque", 2009, 38486, "black", "TG8897939L9TX4G6R"));

            IEnumerable<Car> request6 = cars
                .Where(s => s.Brand == "Citroen");
            Console.WriteLine("     1 запрос, выводящий список автомобилей марки Сitroen");
            foreach (Car car in request6)
            {
                car.Machine();
            }

            IEnumerable<Car> request7 = request6
                .Where(s => s.Age() > 10);
            Console.WriteLine("     2 запрос, выводящий список автомобилей марки Сitroen эксплуатированных больше 10 лет");
            foreach (Car car in request7)
            {
                car.Machine();
            }


            string col = "black";
            int first = 0;
            int seco = 40000;
            IEnumerable<Car> request8 = cars
                .Where(s => s.Color == col);
            request8 = request8
                .Where(s => s.Cost > first && s.Cost < seco);
            Console.WriteLine("     3 запрос, выводящий список автомобилей черного цвета с диапазоном цены от 0 до 40000");
            foreach (Car car in request8)
            {
                car.Machine();
            }


            IEnumerable<Car> request9 = cars
                .OrderBy(s => s.Age());
            Car request10 = request9.Last();
            Console.WriteLine("     4 запрос, выводящий самый старый автомобиль");
            request10.Machine();


            IEnumerable<Car> request11 = cars
                .OrderBy(s => s.Cost);
            Console.WriteLine("     5 запрос, выводящий автомобили отсортированные по цене");
            foreach (Car car in request11)
            {
                car.Machine();
            }


            IEnumerable<Car> request12 = cars
                .OrderBy(s => s.Age());
            IEnumerable<Car> request13 = request12
                .Take(5);
            Console.WriteLine("     6 запрос, выводящий 5 самых молодых автомобилей");
            foreach (Car car in request13)
            {
                car.Machine();
            }

            Console.ReadKey();
        }
    }
}

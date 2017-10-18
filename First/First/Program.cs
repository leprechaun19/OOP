using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = -5;
            char b = 'z';
            float c = 19.23F;
            bool d = true;
            sbyte e = -128;
            short f = -23758;
            long g = -123_456_789;
            byte h = 255;
            uint z = 3_556_678_353;
            ulong j = 123_456_789;
            ushort k = 27569;
            double l = 0.0000020857392958;
            decimal m = 235.75524m;

            //неявные преобразования
            sbyte o = 2;
            short p = -45;
            decimal q = p;
            double r = p;

            ulong s = 4_546_990;
            double t = s;

            //явные преобразования
            int u = 55555;
            byte v = (byte)u;

            ulong w = (ulong)u;

            char x = 'k';
            byte y = (byte)x;

            decimal ppp = 8765;
            char aa = (char)z;

            sbyte bb = 127;
            ushort cc = (ushort)bb;

            //упаковка и распаковка
            int dd = 501;
            object ee = dd;

            int ff = (int)ee;

            //неявно типизированные переменные
            var gg = "Alina";
            var array = new int[] {1,4,67,67 };
            Console.WriteLine("The first element of array = " + array.First());
            

            //тип nullable
            int? jj = null;
            char? kk = null;
            Console.Write("Are null and null equal? ");
            Console.WriteLine(jj == kk);

            //сравнение строк
            string mm = "stars";
            string nn = "stars";
            string oo = "cat ";
            if (mm == nn)
            {
                Console.WriteLine("stars = stars");
            }
            if (mm != oo)
            {
                Console.WriteLine("stars != cat");
            }

            //другие операции со строками
            string pp = "story";
            string insert = "not ";

            string qq = String.Concat(oo,pp);
            Console.WriteLine("concat = " + qq);

            string rr = "My favorite color is blue";
            Console.WriteLine("Substring = " + rr.Substring(18));
            Console.WriteLine("Remove = " + rr.Remove(21,4));
            Console.WriteLine("Insert = " + rr.Insert(21,insert));

            string xx = "Ba/na.na";
            char[] separator = new char[] { '/', '.' };
            string[] arr = xx.Split(separator);
            int i;
            Console.Write("Split = ");
            for (i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ' ');
            }
            Console.WriteLine();

            string ss = String.Copy(pp);
            Console.WriteLine("copy = " + ss);

            //массивы
            int co;
            int[,] Array1 = new int[2,3]{ {1,3,9}, {2,8,4} };
            for (i = 0; i < 2; i++)
            {
                for (co = 0; co < 3; co++)
                {
                    Console.Write("  " + Array1[i,co]);
                }
                Console.WriteLine();
            }

            //массив строк
            string[] Array2 = new string[] {"Monday", "Tuesday", "Sunday", "Friday"};
            int length_array2 = Array2.Length;
            Console.WriteLine();
            Console.WriteLine("Length of array2 = " + length_array2);
            for (co = 0; co < 4; co++)
            {
                Console.WriteLine("  " + Array2[co]);
            }

            //ступенчатый массив
            int[][] Array3 = {new int[2], new int[3], new int[4]};
            for (i = 0; i < 2; i++)
            {
               Console.Write("Enter Array3[0,{0}] ", i);
               Array3[0][i] = int.Parse(Console.ReadLine());
            }
            for (i = 0; i < 3; i++)
            {
                Console.Write("Enter Array3[1,{0}] ", i);
                Array3[1][i] = int.Parse(Console.ReadLine());
            }
            for (i = 0; i < 4; i++)
            {
                Console.Write("Enter Array3[2,{0}] ", i);
                Array3[2][i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            //неявно типизированные переменные
            var arrr = new int[]{10,35,258,6 };
            var stroka = " gfgfgfgf";
            var sstring = new string[] { "dd", "ss", "ff"};

            //кортежи
            (int time, string company, char symbol, string mom, ulong zp) work = ( 8, "oao", '*', "mom", 12_245_000);
            (int tht, string fgvfgggb, char ujujk, string htynt, ulong zdedfp) worhk = (9, "oao", '^', "mimi", 12_288_000);

            Console.WriteLine("  " + work.time + "  " + work.company + "  " + work.symbol + "  " + work.mom + "  " + work.zp);

            int tm = work.time;
            string comp = work.company;
            char symb = work.symbol;
            string mo = work.mom;
            ulong zpp = work.zp;

            bool equal = work.Equals(worhk);
            Console.WriteLine();
            Console.WriteLine("Are tuples equal? " + equal);

            //функция
            (int, int, int, char) CreateCortage(int[] Array, string strokaa)
            {
                int Max_Element = Array.Max();
                int Min_Element = Array.Min();
                int SumOfElement = Array.Sum();
                char bykva = strokaa.First();

                return (Max_Element, Min_Element, SumOfElement, bykva);
            }
            int[] Array4 = {1, 2, 10, 4, 5};
            string myName = "Alina";
            var (min, max, sum, firs) = CreateCortage(Array4, myName);
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(sum);
            Console.WriteLine(firs);

            Console.ReadKey();
        }
        
    }
}

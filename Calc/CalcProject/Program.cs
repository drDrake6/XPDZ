using System;

namespace CalcProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //App.RomanNumber rn = new App.RomanNumber();
            Console.WriteLine(App.RomanNumber.RTOA("IX"));

            Console.WriteLine(App.RomanNumber.ATOR(9));
            Console.WriteLine(7 / 2);
            Console.WriteLine(App.RomanNumber.Nearest(9));

            var x = new App.RomanNumber(9);
            string str = x.ToString();
            Console.WriteLine(str);
        }
    }
}


//azaza

//ololo


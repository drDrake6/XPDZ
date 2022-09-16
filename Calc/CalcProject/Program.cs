using System;
using CalcProject.App;

namespace CalcProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc(new Resources());
            calc.Run();
        }
    }
}



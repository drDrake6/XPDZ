using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalcProject.App
{
    public class Calc
    {
        public Resources _resources { get; set; }
        public Calc(Resources resources)
        {
            _resources = resources;
            RomanNumber.Resources = resources;  
        }
        public void Run()
        {

            RomanNumber rn1;
            RomanNumber rn2;
            while (true)
            {
                Console.WriteLine(_resources.EnterNumber());
                String inp = Console.ReadLine();
                
                try
                {
                    rn1 = new RomanNumber(RomanNumber.RTOA(inp!));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine(_resources.ConsoleErr());
                    continue;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.WriteLine(_resources.EnterNumber());
                String inp = Console.ReadLine();

                try
                {
                    rn2 = new RomanNumber(RomanNumber.RTOA(inp!));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine(_resources.ConsoleErr());
                    continue;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                break;
            }

            Console.WriteLine(_resources.Result(rn1.Add(rn2).ToString()));
        }
    }
}

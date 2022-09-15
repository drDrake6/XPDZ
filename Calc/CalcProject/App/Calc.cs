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
        void EnterNumber(ref RomanNumber rn)
        {
            while (true)
            {
                Console.WriteLine(_resources.EnterNumber());
                String inp = Console.ReadLine();

                try
                {
                    rn = new RomanNumber(RomanNumber.RTOA(inp!));
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

                return;
            }
        }
        public void Run()
        {

            RomanNumber rn1 = null;
            RomanNumber rn2 = null;

            EnterNumber(ref rn1);
            EnterNumber(ref rn2);

            try
            {
                Console.WriteLine(_resources.Result(rn1.Add(rn2).ToString()));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalcProject.App
{
    public class Calc
    {       
        public delegate RomanNumber Operation(RomanNumber left, RomanNumber right);
        static readonly Dictionary<string, Operation> Operations = new()
        {
            { "+", RomanNumber.Add },
            { "-", RomanNumber.Substract },
            { "*", RomanNumber.Mult },
            { "/", RomanNumber.Devide },
            { "%", RomanNumber.Modulo}
        };

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

        public string Calculate(ref RomanNumber left, ref RomanNumber right, Operation operation)
        {
            try
            {
                return operation(left, right).ToString();
            }

            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);
                left = null;
                right = null;
                return "";
            }
        }

        public void Run()
        {

            try
            {
                while (true)
                {
                    Console.WriteLine(_resources.ChoseLanguage());
                    for (int i = 0; i < Resources.langs.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}) {Resources.langs[i]};");
                    }
                    int lang_num = int.Parse(Console.ReadLine()) - 1;

                    if(lang_num >= Resources.langs.Length || lang_num < 0)
                    {
                        Console.WriteLine(_resources.WrongInput());
                        continue;
                    }

                    _resources.lang = Resources.langs[lang_num];
                    break;
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            RomanNumber rn1 = null;
            RomanNumber rn2 = null;
            string res = "";
            
            try
            {
                while (true)
                {
                    EnterNumber(ref rn1);
                    EnterNumber(ref rn2);

                    string op = "";

                    while (true)
                    {
                        Console.WriteLine(_resources.EnterOperation());
                        op = Console.ReadLine();
                        if (!Operations.Keys.Contains(op))
                        {
                            Console.WriteLine(_resources.UnknownOperation());
                            continue;
                        }
                        break;
                    }

                    res = Calculate(ref rn1, ref rn2, Operations[op]);

                    if (res == "") continue;

                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine(_resources.Result(res));
        }
    }
}

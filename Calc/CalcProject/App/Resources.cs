using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class Resources
    {
        static string UNSUPPORT_MESSAGE = "Unsupported lang";
        public string lang { get; set; } = "en-US";
        public static readonly string[] langs = { "en-US", "uk-UA" };
        public string EmptyStringMessage()
        {
            return lang switch
            {
                "en-US" => "Empty string not allowed",
                "uk-UA" => "Порожній рядок неприпустимий",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string NullStringMessage()
        {
            return lang switch
            {
                "en-US" => "string was null",
                "uk-UA" => "рядок був null",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string NullNumberMessage()
        {
            return lang switch
            {
                "en-US" => "some number was null",
                "uk-UA" => "якесь число було null",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string InvalidArgumentMessage(Type type)
        {
            return lang switch
            {
                "en-US" => $"Invalid argument type {type}",
                "uk-UA" => $"некорректний аргумент {type}",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string NotExistMessage(char digit)
        {
            return lang switch
            {
                "en-US" => $"{digit} doesn't exists",
                "uk-UA" => $"{digit} не існує",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string EnterNumber()
        {
            return lang switch
            {
                "en-US" => "enter a number",
                "uk-UA" => "введіть число",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string EnterOperation(char digit)
        {
            return lang switch
            {
                "en-US" => "enter an operation",
                "uk-UA" => "введіть операцію",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string Result(string res)
        {
            return lang switch
            {
                "en-US" => $"result {res}",
                "uk-UA" => $"результат {res}",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string ConsoleErr()
        {
            return lang switch
            {
                "en-US" => $"Console Error",
                "uk-UA" => $"Помилка консолі",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string WrongInput()
        {
            return lang switch
            {
                "en-US" => $"Wrong input",
                "uk-UA" => $"Невырний ввод",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE) //""
            };
        }

        public string ChoseLanguage()
        {
            return lang switch
            {
                "en-US" => $"Chose a language",
                "uk-UA" => $"Вибирите мову",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string EnterOperation()
        {
            return lang switch
            {
                "en-US" => $"Enter an operation",
                "uk-UA" => $"Введіть операцію",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }

        public string UnknownOperation()
        {
            return lang switch
            {
                "en-US" => $"Unknown operation",
                "uk-UA" => $"Невідома опреація",
                _ => throw new ArgumentException(UNSUPPORT_MESSAGE)
            };
        }
    }
}

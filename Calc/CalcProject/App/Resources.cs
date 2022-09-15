using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class Resources
    {
        public string EmptyStringMessage(string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => "Empty string not allowed",
                "uk-UA" => "Порожній рядок неприпустимий",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public string NullStringMessage(string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => "string was null",
                "uk-UA" => "рядок був null",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public string NullNumberMessage(string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => "some number was null",
                "uk-UA" => "якесь число було null",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public string InvalidArgumentMessage(Type type, string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => $"Invalid argument type {type}",
                "uk-UA" => $"некорректний аргумент {type}",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public string NotExistMessage(char digit, string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => $"{digit} doesn't exists",
                "uk-UA" => $"{digit} не існує",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public string EnterNumber(string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => "enter a number",
                "uk-UA" => "введіть число",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public string EnterOperation(char digit, string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => "enter an operation",
                "uk-UA" => "введіть операцію",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public string Result(string res, string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => $"result {res}",
                "uk-UA" => $"результат {res}",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public string ConsoleErr(string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => $"Console Error",
                "uk-UA" => $"Помилка консолі",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }
    }
}

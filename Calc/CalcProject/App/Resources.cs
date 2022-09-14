using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class Resources
    {
        public static string EmptyStringMessage(string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => "Empty string not allowed",
                "uk-UA" => "Порожній рядок неприпустимий",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public static string NullStringMessage(string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => "string was null",
                "uk-UA" => "рядок був null",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public static string NullNumberMessage(string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => "some number was null",
                "uk-UA" => "якесь число було null",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public static string InvalidArgumentMessage(Type type, string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => $"Invalid argument type {type}",
                "uk-UA" => $"некорректний аргумент {type}",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public static string NotExistMessage(char digit, string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => $"{digit} doesn't exists",
                "uk-UA" => $"{digit} не існує",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public record RomanNumber
    {
        static readonly string rnums = "IVXLCDM";
        static readonly int[] anums = {1, 5, 10, 50, 100, 500, 1000};
        public int val { get; set; }
        public RomanNumber(int x)
        {
            val = x;
        }
        public override string ToString()
        {
            return ATOR(val);                 
        }
        public static int Nearest(int x)
        {
            int i = anums.Length / 2;
            int left = 0;
            int right = 0;
            while (true)
            {
                if(Math.Abs(left - right) == 1)
                {
                    return i;
                }

                if (anums[i] < x)
                {
                    left = i;
                    i = left + right / 2;
                }
                else if (anums[i] > x)
                {
                    right = i;
                    i = left + right / 2;
                }
                else
                {
                    return i;
                } 

            }
        }
        public static int RTOA(string str)
        {
            if (str == null) throw new ArgumentNullException("string was null");
            if (str.Length == 0) throw new ArgumentNullException("string was empty");

            bool counter = false;
            if (str.StartsWith("-"))
            {
                counter = true;
                str = str.Substring(1, str.Length - 1);
            }

            if (str == "N") return 0;


            int num = 0;
            int left = 0;
            int right = 0;

            left = rnums.IndexOf(str[0]);
            if (left == -1)
                throw new ArgumentException(str[0] + " doesn't exists");

            for (int i = 0; i < str.Length - 1; i++)
            {
                right = rnums.IndexOf(str[i + 1]);
                if (right == -1)
                    throw new ArgumentException(str[i + 1] + " doesn't exists");               

                if (left < right) 
                    num -= anums[left];
                else 
                    num += anums[left];
  
                left = right;
            }

            num += anums[left];

            if (counter)
            {
                return -num;
            }
            return num;
        }
        public static string ATOR(int x)
        {

            if (x == 0)
                return "N";

            string result = "";
            if (x < 0)
            {
                x = Math.Abs(x);
                result += "-";
            }

            
            int[] digits = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romanDigits = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            for (int i = 0; i < digits.Length; i++)
            {
                while (x >= digits[i])
                {
                    x -= digits[i];
                    result += romanDigits[i];
                }
            }

            return result;
        }
        public RomanNumber Add(RomanNumber right)
        {
            if (right == null) throw new ArgumentNullException("number was null");
            return new(this.val + right.val);
        }

        public RomanNumber Add(int right)
        {
            return new(this.val + right);
        }
        public RomanNumber Add(string right)
        {
            if (right == null) throw new ArgumentNullException("number was null");
            return new(this.val + RTOA(right));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class RomanNumber
    {
        static readonly string rnums = "IVXLCDM";
        static readonly int[] anums = {1, 5, 10, 50, 100, 500, 1000};
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
            return num;
        }

        public static string ATOR(int x)
        {
            int prev = 0;
            string res = "";
            for (int i = anums.Length - 1; i >= 0; i--)
            {
                prev = x - anums[i];                
                if (prev >= 0)
                {
                    res += rnums[i];
                    x -= anums[i];
                    i = anums.Length;
                }
            }
            return res;
        }
    }
}

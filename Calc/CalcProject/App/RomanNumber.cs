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
        public static int Parse(string str)
        {
            int num = 0;
            int left = 0;
            int right = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                left = rnums.IndexOf(str[i]);
                right = rnums.IndexOf(str[i + 1]);

                if (left == -1)
                    throw new Exception(str[i] + " doesn't exists");
                if (right == -1)
                    throw new Exception(str[i + 1] + " doesn't exists");

                if (left < right)
                {
                    num -= anums[left];
                }
                else
                {
                    num += anums[left];
                }
            }

            num += anums[rnums.IndexOf(str[str.Length - 1])];
            return num;
        }
    }
}

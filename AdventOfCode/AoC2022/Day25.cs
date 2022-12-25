using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode
{
    public static class AoC2022Day25
    {
        static Dictionary<int, string> SNAFU;
        public static void Part1()
        {
            SNAFU = new()
            {
                { -2, "=" },
                { -1, "-" },
                { 0, "0" },
                { 1, "1" },
                { 2, "2" },
                { 3, "1=" },
                { 4, "1-" },
                { 8, "2=" },
                { 9, "2-" },
            };  
            string input;
            List<long> numbers = new();
            while ((input = Console.ReadLine()) != "")
            {
                numbers.Add(ParseSNAFU(input));
            }

            Console.WriteLine(numbers.Sum());
            Console.WriteLine(ConvertToSNAFU(numbers.Sum()));
            Console.ReadLine();
        }

        private static long ParseSNAFU(string number)
        {
            long snafu = 0;
            for (int i = number.Length - 1, p = 0; i >= 0; i--, p++)
            {
                switch (number[i])
                {
                    case '=':
                        snafu += (long)(-2 * Math.Pow(5, p));
                        break;
                    case '-':
                        snafu += (long)(-1 * Math.Pow(5, p));
                        break;
                    case '0':
                        snafu += (long)(0 * Math.Pow(5, p));
                        break;
                    case '1':
                        snafu += (long)(1 * Math.Pow(5, p));
                        break;
                    case '2':
                        snafu += (long)(2 * Math.Pow(5, p));
                        break;
                }
            }

            return snafu;
        }
        /*
        34978907874317*/
        private static string ConvertToSNAFU(long number)
        {
            for(int a = 2; a <= 2; a++)
                for(int b = -1; b <= 2; b++)
                for(int c = 1; c <= 2; c++)
                for(int d = -1; d <= 2; d++)
                for(int e = 1; e <= 2; e++)
                for(int f = 1; f <= 2; f++)
                for(int g = 0; g <= 2; g++)
                for(int h = -2; h <= 2; h++)
                for(int i = -2; i <= 2; i++)
                for(int j = -2; j <= 2; j++)
                for(int k = -2; k <= 2; k++)
                for(int l = -2; l <= 2; l++)
                for(int m = -2; m <= 2; m++)
                for(int n = -2; n <= 2; n++)
                for(int o = -2; o <= 2; o++)
                for(int p = -2; p <= 2; p++)
                for(int q = -2; q <= 2; q++)
                for(int r = -2; r <= 2; r++)
                for(int s = -2; s <= 2; s++)
                for(int t = -2; t <= 2; t++)
                {
                    //var snafuString = SNAFU[n] + SNAFU[o] + SNAFU[p] + SNAFU[q] + SNAFU[r] + SNAFU[s];
                    var snafuString = SNAFU[a] + SNAFU[b] + SNAFU[c] + SNAFU[d] + SNAFU[e] + SNAFU[f] + SNAFU[g] + SNAFU[h] + SNAFU[i] + SNAFU[j] + SNAFU[k] + SNAFU[l] + SNAFU[m] + SNAFU[n] + SNAFU[o] + SNAFU[p] + SNAFU[q] + SNAFU[r] + SNAFU[s] + SNAFU[t];
                    var parsed = ParseSNAFU(snafuString);
                    if (parsed > number)
                        Console.WriteLine("Help");
                    if (parsed == number)
                        return snafuString;
                }       
            return "Failed";
        }

    }
}
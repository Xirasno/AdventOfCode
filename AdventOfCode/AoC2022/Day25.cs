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
        static Dictionary<string, string> SNAFU;
        public static void Part1()
        {
            SNAFU = new()
            {
                { "=", "-" },
                { "-", "0" },
                { "0", "1" },
                { "1", "2" },
                { "2", "=" },
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
            var lowestPower = 0;
            for (int i = 100; i >= 0; i--)
                if (number / (long)Math.Pow(5, i) > 0)
                {
                    lowestPower = i;
                    break;
                }
            
            string digit = "";
            for (int i = lowestPower; i >= 0; i--)
            {
                var newNumber = number / (long)Math.Pow(5, i);
                digit += newNumber;
                number -= newNumber * (long)Math.Pow(5, i);
            }

            var convertedDigit = "";
            var saved = false;
            switch (digit.ToString()[^1])
            {
                case '4':
                    convertedDigit += "-";
                    saved = true;
                    break;
                case '3':
                    convertedDigit += "=";
                    saved = true;
                    break;
                default:
                    convertedDigit += digit.ToString()[^1];
                    break;
            }

            var endChar = "";
            for (int c = digit.ToString().Length - 2; c >= 0; c--)
            {
                switch (digit.ToString()[c])
                {
                    case '4':
                        endChar = convertedDigit[^1].ToString();
                        if (saved)
                            convertedDigit = SNAFU["-"] + convertedDigit;
                        else convertedDigit = "-" + convertedDigit;
                        saved = true;
                        break;
                    case '3':
                        endChar = convertedDigit[^1].ToString();
                        if (saved)
                            convertedDigit = SNAFU["="] + convertedDigit;
                        else convertedDigit = "=" + convertedDigit;
                        saved = true;
                        break;
                    case '2':
                        if (saved)
                            convertedDigit = SNAFU[digit.ToString()[c].ToString()] + convertedDigit;
                        else convertedDigit = digit.ToString()[c] + convertedDigit;
                        break;
                    default:
                        if (saved)
                            convertedDigit = SNAFU[digit.ToString()[c].ToString()] + convertedDigit;
                        else convertedDigit = digit.ToString()[c] + convertedDigit;
                        saved = false;
                        break;
                }
            }

            return convertedDigit;
        }

    }
}
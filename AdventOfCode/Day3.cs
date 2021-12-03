using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class Day3
    {
        public static void Part1()
        {
            List<string> bits = new List<string>();
            string input;
            int inputLength;

            while ((input = Console.ReadLine()) != "")
            {
                bits.Add(input);
            }
            inputLength = bits[0].Length;

            int gamma = 0;
            for (var i = 0; i < inputLength; i++)
            {
                gamma |= GetMostCommonBit(bits, i, inputLength - 1 - i);
            }
            int epsilon = gamma ^ ((1 << inputLength) - 1);
            Console.WriteLine($"Gamma = {gamma}; Epsilon = {epsilon}; Power consumption = {gamma * epsilon}");
        }

        public static void Part2()
        {
            List<string> bits = new List<string>();
            string input;
            int inputLength;

            while ((input = Console.ReadLine()) != "")
            {
                bits.Add(input);
            }
            inputLength = bits[0].Length;

            int oxigen = 0, co2 = 0, i = 0;
            List<string> o2bits = new List<string>(bits), co2bits = new List<string>(bits);
            while (o2bits.Count > 1)
            {
                o2bits = GetMostCommonBit(o2bits, i);
                i++;
            }
            i = 0;
            while (co2bits.Count > 1)
            {
                co2bits = GetLeastCommonBit(co2bits, i);
                i++;
            }

            oxigen = ConvertToBits(o2bits.First());
            co2 = ConvertToBits(co2bits.First());

            Console.WriteLine($"Oxigen = {oxigen}; CO2 = {co2}; Life Support = {oxigen * co2}");
        }

        private static int GetMostCommonBit(List<string> bits, int pos, int binPos)
        {
            var newBits = bits.Select(s => s.ElementAt(pos).ToString())
                .Select(c => int.Parse(c));
            if (newBits.Sum() > (newBits.Count() / 2.0f))
                return 1 << binPos;
            else return 0;
        }

        private static List<string> GetMostCommonBit(List<string> bits, int pos)
        {
            var newBits = bits.Select(s => s.ElementAt(pos).ToString())
                .Select(c => int.Parse(c));
            if (newBits.Sum() >= (newBits.Count() / 2.0f))
                return bits.Where(s => s.ElementAt(pos) == '1').ToList();

            else return bits.Where(s => s.ElementAt(pos) == '0').ToList(); 
        }

        private static List<string> GetLeastCommonBit(List<string> bits, int pos)
        {
            var newBits = bits.Select(s => s.ElementAt(pos).ToString())
                .Select(c => int.Parse(c));
            if (newBits.Sum() >= (newBits.Count() / 2.0f))
                return bits.Where(s => s.ElementAt(pos) == '0').ToList();

            else return bits.Where(s => s.ElementAt(pos) == '1').ToList(); 
        }

        private static int ConvertToBits(string b)
        {
            int bin = 0;
            for(int i = 0; i < b.Length; i++)
            {
                bin |= (int.Parse(b.ElementAt(i).ToString())) << (b.Length - 1 - i);
            }
            return bin;
        }
    }
}

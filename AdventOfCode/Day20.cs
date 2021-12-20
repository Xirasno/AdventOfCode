using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day20
    {
        private static bool[] Algorithm;
        public static void Part1()
        {
            string input = Console.ReadLine(); Console.ReadLine();
            Algorithm = new bool[input.Length];
            for (int i = 0; i < input.Length; i++)
                Algorithm[i] = input[i] == '#';

            List<List<bool>> inputImage = new();
            while ((input = Console.ReadLine()) != "")
            {
                List<bool> row = new();
                for (int i = 0; i < input.Length; i++)
                    row.Add(input[i] == '#');
                inputImage.Add(row);
            }
            int sizeIncrease = 5;
            bool[,] image = new bool[inputImage.Count + (2 * sizeIncrease), inputImage.Count + (2 * sizeIncrease)]; 
            for (int i = sizeIncrease, x = 0; x < inputImage.Count; i++, x++)
                for (int j = sizeIncrease, y = 0; y < inputImage.Count; j++, y++)
                {
                    image[j, i] = inputImage.ElementAt(x).ElementAt(y);
                }

            image.Write();

            int litPixels = 0;
            bool[,] enhanced = (bool[,])image.Clone();
            for (int i = 0; i < 2; i++)
            {
                enhanced = OldEnhance(enhanced);
                Console.WriteLine(); enhanced.Write();
            }

            foreach (bool b in enhanced)
                if (b)
                    litPixels++;

            Console.WriteLine(litPixels);
        }

        public static void Part2()
        {
            string input = Console.ReadLine(); Console.ReadLine();
            Algorithm = new bool[input.Length];
            for (int i = 0; i < input.Length; i++)
                Algorithm[i] = input[i] == '#';

            List<List<bool>> inputImage = new();
            while ((input = Console.ReadLine()) != "")
            {
                List<bool> row = new();
                for (int i = 0; i < input.Length; i++)
                    row.Add(input[i] == '#');
                inputImage.Add(row);
            }

            int iterations = 50;
            int sizeIncrease = iterations + 1;
            bool[,] image = new bool[inputImage.Count + (2 * sizeIncrease), inputImage.Count + (2 * sizeIncrease)];
            for (int i = sizeIncrease, x = 0; x < inputImage.Count; i++, x++)
                for (int j = sizeIncrease, y = 0; y < inputImage.Count; j++, y++)
                {
                    image[j, i] = inputImage.ElementAt(x).ElementAt(y);
                }

            //image.Write();

            int litPixels = 0;
            bool[,] enhanced = (bool[,])image.Clone();
            for (int i = 0; i < iterations; i++)
            {
                enhanced = OldEnhance(enhanced);
                if (i % 2 != 0)
                {
                    for (int j = 0; j < enhanced.GetLength(0); j++)
                    {
                        enhanced[0, j] = false;
                        enhanced[enhanced.GetLength(0) - 1, j] = false;
                        enhanced[j, 0] = false;
                        enhanced[j, enhanced.GetLength(1) - 1] = false;
                    }
                }
                if (i == iterations - 1)
                {
                    Console.WriteLine(); enhanced.Write();
                }
            }

            for (int i = (sizeIncrease - iterations) / 2; i < enhanced.GetLength(0) - ((sizeIncrease - iterations) / 2); i++)
                for (int j = (sizeIncrease - iterations) / 2; j < enhanced.GetLength(1) - ((sizeIncrease - iterations) / 2); j++)
                    if(enhanced[i, j])
                        litPixels++;

            Console.WriteLine(litPixels);
        }

        public static bool[,] Enhance(bool[,] image)
        {
            bool[,] newImage = new bool[image.GetLength(0) + 2, image.GetLength(1) + 2];
            bool[,] largerImage = new bool[image.GetLength(0) + 2, image.GetLength(1) + 2];
            for (int i = 0; i < image.GetLength(0); i++)
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    largerImage[i + 1, j + 1] = image[i, j];
                }

            for (int i = 0; i < largerImage.GetLength(0); i++)
                for (int j = 0; j < largerImage.GetLength(1); j++)
                {
                    string bit = "";
                    if (i != 0 && j != 0) bit += largerImage[j - 1, i - 1] ? "1" : "0"; else bit += 0;
                    if (i != 0) bit += largerImage[j, i - 1] ? "1" : "0"; else bit += 0;
                    if (i != 0 && j != largerImage.GetLength(1) - 1) bit += largerImage[j + 1, i - 1] ? "1" : "0"; else bit += 0;
                    if (j != 0) bit += largerImage[j - 1, i] ? "1" : "0"; else bit += 0;
                    bit += largerImage[j, i] ? "1" : "0";
                    if (j != largerImage.GetLength(1) - 1) bit += largerImage[j + 1, i] ? "1" : "0"; else bit += 0;
                    if (i != largerImage.GetLength(1) - 1 && j != 0) bit += largerImage[j - 1, i + 1] ? "1" : "0"; else bit += 0;
                    if (i != largerImage.GetLength(1) - 1 && j != 0) bit += largerImage[j, i + 1] ? "1" : "0"; else bit += 0;
                    if (i != largerImage.GetLength(1) - 1 && j != largerImage.GetLength(1) - 1) bit += largerImage[j + 1, i + 1] ? "1" : "0"; else bit += 0;
                    int b = Convert.ToInt32(bit, 2);
                    newImage[j, i] = Algorithm[b];
                }

            return newImage;
        }

        public static bool[,] OldEnhance(bool[,] image)
        {
            bool[,] newImage = new bool[image.GetLength(0), image.GetLength(1)];
            for (int i = 0; i < image.GetLength(0); i++)
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    string bit = "";
                    if (i != 0 && j != 0) bit += image[j - 1, i - 1] ? "1" : "0"; else bit += 0;
                    if (i != 0) bit += image[j, i - 1] ? "1" : "0"; else bit += 0;
                    if (i != 0 && j != image.GetLength(1) - 1) bit += image[j + 1, i - 1] ? "1" : "0"; else bit += 0;
                    if (j != 0) bit += image[j - 1, i] ? "1" : "0"; else bit += 0;
                    bit += image[j, i] ? "1" : "0";
                    if (j != image.GetLength(1) - 1) bit += image[j + 1, i] ? "1" : "0"; else bit += 0;
                    if (i != image.GetLength(1) - 1 && j != 0) bit += image[j - 1, i + 1] ? "1" : "0"; else bit += 0;
                    if (i != image.GetLength(1) - 1 && j != 0) bit += image[j, i + 1] ? "1" : "0"; else bit += 0;
                    if (i != image.GetLength(1) - 1 && j != image.GetLength(1) - 1) bit += image[j + 1, i + 1] ? "1" : "0"; else bit += 0;
                    int b = Convert.ToInt32(bit, 2);
                    newImage[j, i] = Algorithm[b];
                }

            return newImage;
        }

        private static void Write(this bool[,] image)
        {
            for (int j = 0; j < image.GetLength(1); j++)
            {
                for (int i = 0; i < image.GetLength(0); i++)
                {
                    Console.Write(image[i, j] ? "#" : ".");
                }
                Console.WriteLine();
            }
        }
    }
}
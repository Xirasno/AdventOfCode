using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day24
    {
        private static Dictionary<string, int> Variables = new() { { "w", 0 },{ "x", 0 },{ "y", 0 },{ "z", 0 } };
        public static void Part1()
        {
            string input;
            List<string> monad = new();

            while ((input = Console.ReadLine()) != "")
            {
                monad.Add(input);
            }
            
            string[] splitInput;
            int[] modelNr = new int[14] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            long highest = 0;
            for (long m = 49999999999999, i = 0; m >= 25999999999999; m--, i = 0, modelNr = m.ToString().Select(c => int.Parse(c.ToString())).ToArray())
            {
                if (modelNr.Any(n => n == 0))
                    continue;

                for (int j = 0; j < monad.Count; j++)
                {
                    splitInput = monad[j].Split(' ');
                    if (splitInput[0] == "div" && (splitInput[2] == "w" || splitInput[2] == "x" || splitInput[2] == "y" || splitInput[2] == "z") && Variables[splitInput[2]] == 0)
                    { Variables["z"] = -1; break; }
                    if (splitInput[0] == "mod" && (splitInput[2] == "w" || splitInput[2] == "x" || splitInput[2] == "y" || splitInput[2] == "z") && (Variables[splitInput[1]] < 0 || Variables[splitInput[2]] <= 0))
                    { Variables["z"] = -1; break; }

                    switch (splitInput[0])
                    {
                        case "inp":
                            Variables[splitInput[1]] = modelNr[i++];
                            break;

                        case "add":
                            Variables[splitInput[1]] = Variables[splitInput[1]].Add(splitInput[2]);
                            break;

                        case "mul":
                            Variables[splitInput[1]] = Variables[splitInput[1]].Mul(splitInput[2]);
                            break;

                        case "div":
                            Variables[splitInput[1]] = Variables[splitInput[1]].Div(splitInput[2]);
                            break;

                        case "mod":
                            Variables[splitInput[1]] = Variables[splitInput[1]].Mod(splitInput[2]);
                            break;

                        case "eql":
                            Variables[splitInput[1]] = Variables[splitInput[1]].Eql(splitInput[2]);
                            break;

                        default:
                            break;

                    }
                }
                if(Variables["z"] == 0)
                {
                    Console.WriteLine(m);
                    break;
                }
                Variables["w"] = 0;
                Variables["x"] = 0;
                Variables["y"] = 0;
                Variables["z"] = 0;
            }

            Console.WriteLine(highest);
        }

        /*public static void Part2()
        {

        }*/

        public static int Add(this int a, string b)
        {
            if (b == "w" || b == "x" || b == "y" || b == "z")
                return a + Variables[b];
            else return a + int.Parse(b);
        }

        public static int Mul(this int a, string b)
        {
            if (b == "w" || b == "x" || b == "y" || b == "z")
                return a * Variables[b];
            else return a * int.Parse(b);
        }

        public static int Div(this int a, string b)
        {
            if (b == "w" || b == "x" || b == "y" || b == "z")
                return a / Variables[b];
            else return a / int.Parse(b);
        }

        public static int Mod(this int a, string b)
        {
            if (b == "w" || b == "x" || b == "y" || b == "z")
                return a % Variables[b];
            else return a % int.Parse(b);
        }

        public static int Eql(this int a, string b)
        {
            if (b == "w" || b == "x" || b == "y" || b == "z")
                return a == Variables[b] ? 1 : 0;
            else return a == int.Parse(b) ? 1 : 0;
        }
    }
}
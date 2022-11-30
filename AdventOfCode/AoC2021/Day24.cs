using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day24
    {
        private static Dictionary<string, long> Variables = new() { { "w", 0 },{ "x", 0 },{ "y", 0 },{ "z", 0 } };
        private static int[] LastNumber = new int[] { 15, 5, 6, 7, 9, 6, 14, 3, 1, 3, 4, 6, 7, 1 };
        public static void Part1()
        {
            string input;
            string[] variables = new string[] { "w", "x", "y", "z" };
            List<string> monad = new();

            while ((input = Console.ReadLine()) != "")
            {
                if (!variables.Contains(input[^1].ToString()))
                    input = "n" + input;
                monad.Add(input);
            }

            
            string[] splitInput;
            long m = 26111111111111; //39998269249755
            int[] modelNr = m.ToString().Select(c => int.Parse(c.ToString())).ToArray();
            for (; m < 39998269249755; m++, modelNr = m.ToString().Select(c => int.Parse(c.ToString())).ToArray())
            {
                if (m % 1000000 == 0)
                    Console.WriteLine(m);
                if (modelNr.Any(n => n == 0))
                    continue;
                for (int g = 0, i = 13; g < modelNr.Length; g++, i--)
                {
                    Variables["z"] += modelNr[g] * (long)Math.Pow(26, i) + LastNumber[g] * (long)Math.Pow(26, i);
                }
                /*
                for (int j = 0; j < monad.Count; j++)
                {
                    splitInput = monad[j].Split(' ');
                    if (splitInput[0] == "div" && variables.Contains(splitInput[2]) && Variables[splitInput[2]] == 0)
                    { Variables["z"] = -1; break; }
                    if (splitInput[0] == "mod" && variables.Contains(splitInput[2]) && (Variables[splitInput[1]] < 0 || Variables[splitInput[2]] <= 0))
                    { Variables["z"] = -1; break; }

                    switch (splitInput[0])
                    {
                        case "inp":
                            Variables[splitInput[1]] = modelNr[i++];
                            break;

                        case "add":
                            Variables[splitInput[1]] += Variables[splitInput[2]];
                            break;

                        case "nadd":
                            Variables[splitInput[1]] += int.Parse(splitInput[2]);
                            break;

                        case "mul":
                            Variables[splitInput[1]] *= Variables[splitInput[2]];
                            break;

                        case "nmul":
                            Variables[splitInput[1]] *= int.Parse(splitInput[2]);
                            break;

                        case "div":
                            Variables[splitInput[1]] /= Variables[splitInput[2]];
                            break;

                        case "ndiv":
                            Variables[splitInput[1]] /= int.Parse(splitInput[2]);
                            break;

                        case "mod":
                            Variables[splitInput[1]] %= Variables[splitInput[2]];
                            break;

                        case "nmod":
                            Variables[splitInput[1]] %= int.Parse(splitInput[2]);
                            break;

                        case "eql":
                            Variables[splitInput[1]] = Variables[splitInput[1]] == Variables[splitInput[2]] ? 1 : 0;
                            break;

                        case "neql":
                            Variables[splitInput[1]] = Variables[splitInput[1]] == int.Parse(splitInput[2]) ? 1 : 0;
                            break;

                        default:
                            break;

                    }
                }*/
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
        }

        /*public static void Part2()
        {

        }*/
    }
}
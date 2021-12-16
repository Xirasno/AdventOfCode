using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day16
    {
        private static Dictionary<char, string> Map = new Dictionary<char, string>()
        {
            {'0', "0000"},
            {'1', "0001"},
            {'2', "0010"},
            {'3', "0011"},
            {'4', "0100"},
            {'5', "0101"},
            {'6', "0110"},
            {'7', "0111"},
            {'8', "1000"},
            {'9', "1001"},
            {'A', "1010"},
            {'B', "1011"},
            {'C', "1100"},
            {'D', "1101"},
            {'E', "1110"},
            {'F', "1111"},
        };

        public static void Part1()
        {
            string packet = Console.ReadLine();
            string bitOutput = "";
            for (int i = 0; i < packet.Length; i++)
                bitOutput += Map[packet[i]];

            List<int> versions = new();
            List<string> packets = new() { bitOutput };
            while (packets.Any() && !packets.All(p => p.StartsWith("LIT")))
            {
                var curPacket = packets.First();
                if (curPacket.StartsWith("LIT"))
                    continue;
                versions.Add(Convert.ToInt32(curPacket[..3], 2));
                packets = packets.Concat(Unpack(curPacket)).ToList();
                packets.Remove(curPacket);
            }


            Console.WriteLine(versions.Aggregate((a, b) => a + b));
        }

        /*public static void Part2()
        {

        }*/

        private static List<string> Unpack(string bits)
        {
            List<string> packets = new();
            string packet = "";
            int type = Convert.ToInt32(bits.Substring(3, 3), 2);

            if (type == 4)
            {
                packet = "LIT";
                for (int i = 6; i < bits.Length; i += 5)
                {
                    packet += bits.Substring(i + 1, 4);
                    if (bits[i] == '0')
                        break;
                }
                packets.Add(packet);
            }
            else if (type == 6)
            {
                char indicator = bits[6];
                if (indicator == '0')
                {
                    int lenght = Convert.ToInt32(bits.Substring(7, 15), 2);
                    packets = packets.Concat(GetSubPackets(bits.Substring(22, lenght))).ToList();
                }
                else if (indicator == '1')
                {
                    int nr = Convert.ToInt32(bits.Substring(7, 11), 2);
                    for (int i = 0; i < nr; i++)
                    {
                    }
                }

            }                

            return packets;
        }

        private static List<string> GetSubPackets(string bits)
        {
            List<string> packets = new();
            for (int i = 0; i < bits.Length; i++)
            {
                var packet = "";
                int type = 0;
                try { type = Convert.ToInt32(bits.Substring(i + 3, 3), 2); }
                catch { break; }
                if (type == 4)
                {
                    packet += bits[..6];
                    for (int k = i + 6; k < bits.Length; k += 5)
                    {
                        packet += bits.Substring(k, 5);
                        if (bits[k] == '0')
                            break;
                    }
                    packets.Add(packet);
                    i += packet.Length;
                }

                else if (type == 6)
                {
                    char indicator = bits[i + 6];
                    if (indicator == '0')
                    {
                        int lenght = Convert.ToInt32(bits.Substring(i + 7, 15), 2);
                        var subPackets = GetSubPackets(bits.Substring(i + 22, lenght));
                        packets = packets.Concat(subPackets).ToList();
                        i += subPackets.Aggregate((a, b) => a + b).Length;
                    }
                    else if (indicator == '1')
                    {
                        int nr = Convert.ToInt32(bits.Substring(i + 7, 11), 2);
                        for (int k = 0; k < nr; k++)
                        {
                        }
                    }
                }
            }
            return packets;
        }
    }
}
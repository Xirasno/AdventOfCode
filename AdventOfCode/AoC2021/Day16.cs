using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day16
    {
        private static Dictionary<char, string> Map = new()
        {
            {'0', "0000"}, {'1', "0001"}, {'2', "0010"}, {'3', "0011"}, {'4', "0100"}, {'5', "0101"}, {'6', "0110"}, {'7', "0111"}, 
            {'8', "1000"}, {'9', "1001"}, {'A', "1010"}, {'B', "1011"}, {'C', "1100"}, {'D', "1101"}, {'E', "1110"}, {'F', "1111"},
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
                packets.Sort();
                var curPacket = packets.First();
                if (curPacket.StartsWith("LIT"))
                    continue;
                versions.Add(Convert.ToInt32(curPacket[..3], 2));
                packets = packets.Concat(Unpack(curPacket)).ToList();
                packets.Remove(curPacket);
            }


            Console.WriteLine(versions.Aggregate((a, b) => a + b));
        }

        public static void Part2()
        {
            string packet = Console.ReadLine();
            string bitOutput = "";
            for (int i = 0; i < packet.Length; i++)
                bitOutput += Map[packet[i]];

            long value = Unpack2(bitOutput);


            Console.WriteLine(value);
        }

        private static long Unpack2(string bits)
        {
            List<string> packets = new();
            string packet = "";
            int type = Convert.ToInt32(bits.Substring(3, 3), 2);

            if (type == 4)
            {
                for (int i = 6; i < bits.Length; i += 5)
                {
                    packet += bits.Substring(i + 1, 4);
                    if (bits[i] == '0')
                        break;
                }
                return Convert.ToInt64(packet, 2);
            }

            char indicator = bits[6];
            if (indicator == '0')
            {
                int length = Convert.ToInt32(bits.Substring(7, 15), 2);
                packets = packets.Concat(GetSubPackets(bits.Substring(22, length))).ToList();
            }
            else if (indicator == '1')
            {
                int count = Convert.ToInt32(bits.Substring(7, 11), 2);
                packets = packets.Concat(GetSubPackets(bits[18..], count)).ToList();
            }

            switch (type)
            {
                case 0:
                    return packets.Select(p => Unpack2(p)).Aggregate((a, b) => a + b);
                case 1:
                    return packets.Select(p => Unpack2(p)).Aggregate((a, b) => a * b);
                case 2:
                    return packets.Select(p => Unpack2(p)).Min();
                case 3:
                    return packets.Select(p => Unpack2(p)).Max();
                case 5:
                    return Unpack2(packets[0]) > Unpack2(packets[1]) ? 1 : 0;
                case 6:
                    return Unpack2(packets[0]) < Unpack2(packets[1]) ? 1 : 0;
                case 7:
                    return Unpack2(packets[0]) == Unpack2(packets[1]) ? 1 : 0;
                default: break;
            }

            return 0;
        }

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
            else
            {
                char indicator = bits[6];
                if (indicator == '0')
                {
                    int length = Convert.ToInt32(bits.Substring(7, 15), 2);
                    packets = packets.Concat(GetSubPackets(bits.Substring(22, length))).ToList();
                }
                else if (indicator == '1')
                {
                    int count = Convert.ToInt32(bits.Substring(7, 11), 2);
                    packets = packets.Concat(GetSubPackets(bits[18..], count)).ToList();
                }

            }                

            return packets;
        }
        private static List<string> GetSubPackets(string bits, int count = int.MaxValue)
        {
            List<string> packets = new();
            for (int n = 0; n < count; n++)
            {
                var packet = "";
                int type = 0;
                try { type = Convert.ToInt32(bits.Substring(3, 3), 2); } catch { break; }
                if (type == 4)
                {
                    packet += bits[..6];
                    for (int k = 6; k < bits.Length; k += 5)
                    {
                        packet += bits.Substring(k, 5);
                        if (bits[k] == '0')
                            break;
                    }
                    packets.Add(packet);
                    bits = bits.Remove(0 ,packet.Length);
                }

                else
                {
                    char indicator = bits[6];
                    if (indicator == '0')
                    {
                        int length = 0;
                        length = Convert.ToInt32(bits.Substring(7, 15), 2);
                        string subPackets = "";
                        subPackets = bits[..22] + bits.Substring(22, length);
                        packets.Add(subPackets);
                        bits = bits.Replace(subPackets, "");
                    }
                    else if (indicator == '1')
                    {
                        int count2 = 0;
                        count2 = Convert.ToInt32(bits.Substring(7, 11), 2);
                        var subPackets = GetSubPackets(bits[18..], count2);
                        packet = bits[..18];
                        packet += subPackets.Count > 0 ? subPackets.Aggregate((a, b) => a + b) : "";
                        packets.Add(packet);
                        bits = bits.Remove(0, packet.Length);
                    }
                }
            }
            return packets;
        }
    }
}
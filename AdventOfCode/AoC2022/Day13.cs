using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day13
    {
        public static void Part1()
        {
            string input;
            int rightOrder = 0;
            int index = 0;
            while ((input = Console.ReadLine()) != "")
            {
                index++;
                var left = ParsePacket(input);
                var right = ParsePacket(Console.ReadLine());
                Console.WriteLine($"Pair: {index}");
                var p = ComparePackets(left, right);
                Console.WriteLine($"Result: {p}");
                if (p == 1)
                    rightOrder += index;

                Console.ReadLine();
            }
            Console.WriteLine(rightOrder++);
        }

        public static void Part2()
        {
            string input;
            List<Packet> packets = new();

            Packet p2 = new Packet(-1, null)
            { packets = new List<Packet>() { new Packet(2, null) } };
            Packet p6 = new Packet(-1, null)
            { packets = new List<Packet>() { new Packet(6, null) } };
            packets.Add(p2);
            packets.Add(p6);

            int index = 0;
            while ((input = Console.ReadLine()) != "")
            {
                packets.Add(ParsePacket(input));
                packets.Add(ParsePacket(Console.ReadLine()));
                Console.ReadLine();
            }

            for (int i = 0; i < packets.Count - 1; i++)
            {
                for (int j = 0; j < packets.Count - i - 1; j++)
                {
                    var p = ComparePackets(packets[j], packets[j + 1]);
                    if (p == -1)
                    {
                        var temp = packets[j];
                        var temp2 = packets[j + 1];

                        packets[j] = temp2;
                        packets[j + 1] = temp;
                    }
                }
            }
            int i2 = packets.IndexOf(packets.First(p => p.packets.Any(l => l.value == 2 && l.parent == null))) + 1;
            int i6 = packets.IndexOf(packets.First(p => p.packets.Any(l => l.value == 6 && l.parent == null))) + 1;
            Console.WriteLine(i2*i6);
        }

        // 1 = true, 0 = tbd, -1 = false;
        public static int ComparePackets(Packet left, Packet right)
        {
            /*Console.WriteLine($"========================================================================================\n" +
                $"Left: {left.value}, Right: {right.value}\n");*/
            if (left.packets.Count == 0 && right.packets.Count == 0)
            {
                if (left.value == -1 && right.value != -1)
                    return 1;
                if (left.value < right.value)
                    return 1;
                else if (left.value == right.value)
                    return 0;
                return -1;
            }

            if (left.packets.Count > 0 && right.packets.Count > 0)
            {
                for (int i = 0; i < right.packets.Count && i < left.packets.Count; i++)
                {
                    var p = ComparePackets(left.packets[i], right.packets[i]);
                    if (p == 0)
                        continue;
                    return p;
                }

                if (left.packets.Count < right.packets.Count)
                    return 1;
                if (left.packets.Count > right.packets.Count)
                    return -1;
                else
                    return 0;
            }

            if (left.packets.Count == 0 && right.packets.Count > 0)
            {
                if (left.value == -1)
                    return 1;

                var p = ComparePackets(new Packet(left.value, left), right.packets[0]);
                if (p == 0)
                    return 1;
                else return p;
            }

            if (right.packets.Count == 0 && left.packets.Count > 0)
            {
                if (right.value == -1)
                    return -1;

                var p = ComparePackets(left.packets[0], new Packet(right.value, right));
                if (p == 0)
                    return -1;
                else return p;
            }

            return 0;
        }

        public static Packet ParsePacket(string input)
        {
            Packet root = new(null);
            var curPacket = root;
            for (int i = 1; i < input.Length - 1; i++)
            {
                switch (input[i])
                {
                    case '[':
                        var newChild = new Packet(curPacket);
                        curPacket = newChild;
                        break;
                    case ']':
                        curPacket.parent.packets.Add(curPacket);
                        curPacket = curPacket.parent;
                        break;
                    case ',':
                        break;
                    default:
                        if(int.TryParse(input[i+1].ToString(), out var k))
                            curPacket.packets.Add(new Packet(int.Parse(input[i..(i+2)].ToString()), curPacket));
                        else curPacket.packets.Add(new Packet(int.Parse(input[i].ToString()), curPacket));
                        break;
                }
            }

            return root;
        }

        public class Packet
        {
            public Packet parent;
            public List<Packet> packets;
            public int value;

            public Packet(Packet parent)
            {
                this.parent = parent;
                this.packets = new();
                this.value = -1;
            }

            public Packet(int value, Packet parent)
            {
                this.parent = parent;
                this.packets = new();
                this.value = value;
            }
        }
    }
}
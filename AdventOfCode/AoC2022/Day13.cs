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
            int rightOrder = 0, index = 1;
            while ((input = Console.ReadLine()) != "")
            {
                var left = ParsePacket(input);
                var right = ParsePacket(Console.ReadLine());

                 if (ComparePackets(left, right) == 1)
                    rightOrder += index;

                Console.ReadLine();
                index++;
            }
            Console.WriteLine(rightOrder);
        }

        /*public static void Part2()
        {
        }*/

        // 1 = true, 0 = tbd, -1 = false;
        public static int ComparePackets(Packet left, Packet right)
        {
            if (left.packets.Count == 0 && right.packets.Count == 0)
            {
                if (left.value == -1 && right.value != -1)
                    return 1;
                if (left.value < right.value)
                    return 1;
                else if (left.value == right.value)
                    return 0; // not really true, but not false either
                return -1;
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

            for (int i = 0; i < right.packets.Count; i++)
            {
                if (i > left.packets.Count - 1)
                    return 1;

                var p = ComparePackets(left.packets[i], right.packets[i]);
                if (p == 0)
                    continue;
                return p;
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
                        curPacket.packets.Add(new Packet(int.Parse(input[i].ToString()), curPacket));
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
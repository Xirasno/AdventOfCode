﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode
{
    public static class AoC2022Day17
    {
        public static void Part1()
        {
            string movement = "><<<<>>><<<><<<<>>><<<>>><<<><<<<><<>>><<<>><<<<>>>><<<><<>>><>><<<<>>><><<><<>><<<>>><<<>>>><<>><>>>><>>><<<<>>>><<<<>>><<<>>>><>>><<<>><>><<><<<>>>><>>><<>><<<><<<><<<>>><>>><<<>><<<><><<>>>><<>>><>>>><<<>>><<<><<<<>>><<<><<<<><<>><>>><<>><<<<>>>><<<>><>>><<>><<>>>><<<<><<<<><<<><<>>><>>><<><<>><<>><<>>><<>>><>>>><<<><><<>>><<<<><<>>>><>>>><<<><>><<>>><<<<>>><<<<>>>><>><>><<>>>><<<<>><<<<>>><<<<><<<<><<<<>>>><<<<>>><<>>><<>>>><>>><<<>>>><<<>><<<>>>><<><<<<>><<>>><<<<><<<>>>><<><<>>><<<<><<><><<<<>><<<>>>><>>>><<<>>>><<<<>><><<<<>><<<<><><<<<>>>><<<>>>><>><<<>><<<<>>><>>><<<><<>>>><<>><>>>><>>><<<<>><><<<>>>><<><<<<><<<>><<<<>>><<>>><<<<><>>>><<><<<>><<<><>><<>>><<<><>>><<<<><<<>>><<<<>>><<>>><<<<>><<<<><<>>><<<>>><>>>><<<>><>>>><<>>>><<<>><<>>>><><<><<<<>>>><<<>><<<><<<>>><<>>>><<>><<><<<>><><<<<><<>>>><<<<>>>><<><>><<<><<>>>><<<><<<<>>>><<<><<>>><<>>>><>><>>>><<>>>><<<>>>><<<>>>><>>><<<<>>>><<<<>><<>><>>><<>>><<><<<>>>><<<<>>>><<><<<>><<>>><>>><<><<<<><<>><<<>>>><<<>>><<<><>>><<<<>>>><<>>><>>><<<<>>><>>>><<<<>><<<<>>>><<<<>><>>><<<<>>>><<><<<<>>><<>><<>>><<<>>><><<><<<>>>><>><>><<>>><<>>>><<<<>>>><<<<>><<<<>><>>><<>>><<<<>>><<<<><>>><<<><<<<><<<>><>>><<<>><<<<>><<<<><<><<<><<<<>>><<>><<<>><<<>>><<<<><<<>>><<><>>>><<<<><<<>><<<>>>><<<<><<<>>><<><<<<>>>><<<<>>>><<>>>><<<>>>><<><>>><>>><<<<>>><<>>>><<<<>>>><<<<>>>><<<>>><><<<><><<<><><><>>><><<<<><<>>><>>>><<>>>><<<<>><<<>>><<<><><<>><<<<><<<><<>>><>>>><<<<>><<>><<>><<<<>>>><<<>>>><<<>>><>><<>><>>><<>>>><<<<>>>><<<<>>><<<><>>>><>><<<<>>>><>>>><<><<<<>>>><<<>><<<>>><<>>><<>>><><<<<><<>>>><<>>>><<<>><<>><<>>>><><<<>><<>>>><<<>><<<>>><<>>><>><<<<>>>><>>>><<<<>>>><<>>>><<>>><>>><<<>>><<>><<<<><<<<><<>>>><<>>>><<<><<<<><<<><>><>><<<><><>><>><><<<>><<<<>>><>>><<<>><<<>>><<<>>>><>>>><<<>>>><<<<>>>><<<><>>>><<<>>>><<<><<<<>>><>>>><<<>><<<<><<<>>><<<<>><><<<<>>>><<<>>><>>>><>>>><><<>><<><<<>><>>><><><<>>><><<<>>>><<><>>><<<<>><<>><><>><<<>>>><<<>>>><<><<<>>><<<<><<>>><<><<>><<>><<<<>>>><<><<<>>>><<><>>>><<><<<>><<<<>>>><<<<>><<><<<<><<<<><<>>><<<<>>><<>>>><<<<>>>><>>>><>>><<>><<<<><<<>><<>><<<>>><<<>><<<><<<<>>>><>>>><<><<>><<<>>><<<<>><<<>>>><<>>>><<<><<<>>>><<<><<<<>><<<<>>>><<><<>><<<>>><<<><<<>>>><<<<>><<><<><<<<>>>><<>><>>>><<>>>><>>>><<><<>><<<>>><>>><<<<>><>>>><<<<>>>><>><<<>>>><<<<>><<<<>>><<<>><<<<>><<<>><<<<>><<<<>>>><<<><>><<<<>>><<<<>>>><<>><<<><<<<>>><<<>><<<>>><<>><>>><<>><<<<>>><<<><>>><>>><>>><<<<>>><<<<>><<<<>>><>>><>><<<<>><<<<>>>><<><<<>>><<<<>>><>><<>>><<>><<<>><>>>><<>><<<><<<>>><<<>>><><<><<<><<>>><<>>><<>><<>>><<>>>><<<><>><>>><<<<>>><<<>>>><<>><<><<<<>><<<>>><<<><<>><>><>>><<<>>><<>><<<<>>>><<<<>>>><<>><<<><<<<>><<<>>><><<>>>><<<<>><>><<<>><<<>>>><<<<><<<>>>><<<><<<<><>>><<>><>>>><<>>><>>>><<<>><<<<><<><<>>>><<><<<<><<>><<<<>>><<<<>>>><>>><<<><>>>><<>>>><<<>><<<>>>><<>><<<<>><><<<<>>><<>>>><<<<><<>>><<<>><>>>><<<><<<<><<<><><>>><<><<<>><<>>><<<<><<>>><><<<>>><>><<>>>><<>><<>>><<>>><<>>><>><><<<><<<>>>><>>>><<><<<<>>>><<<>>><<<<>>><<<><<<>>>><<<><<<><<<<>>>><<<<><<><<<>>>><>>><<<><>><<>><<<<>>>><>><<>><<<<>>><<<<>>><>>><>>><>><<<<><<<><<<><<<<>><>>><<<><<>>><<<>><>><><><><>>><<><<<<>><<<>>>><<><<<<>>>><<<>>><><<<<>>>><>>>><<<<><<>><>><>>><>>>><<><>><<<<>><<<<>><<><<<>>>><<<<>>>><<<<>>><<><<<<>><<<<>><<<>>><<<>>><>><<<<>>><<<>><<<><<<<><<<<><<<>>><<>>><<><<>>><><<>>><<<<>><<<>>><>>>><<>><>>>><<>><<<<>>>><<><<<>>><<<>>>><>>><<>><>><<<>><>>>><<<>><<<<>>>><<>>><>><<>>>><<<<><<<<><<<>><<<>><><<<<>>>><<<>>><<<<>><><>>><<><>>>><>><<<<>>><>>><<<><>>><>><>>>><<>>><<<><><<<<>><>>>><>>>><<<>>><<<<>>><<<<>><<<<>><<<>>>><<<><<<<>><<<>>><<<><<<>>><<><<>>><<<>>><<>><<<<>>><<<>>><>><<<<><<<<><>><><<<<>><<<>><<>>>><<<>><<>><<<<>>>><<>>><<<<><<<<><<>>>><<>>><<<>><>>>><<<<><<><<>>>><<>>>><<<>><>>><>>><<<<>>><<<<>>><<>><<>>><>>><<<>>>><<>>><<<>>><<>><<<<>>><>><<<>>>><><<<<><<>>><<<<>>><<<<>>>><<<<>><>>>><>>><<><<>>><<>><<<>>><><<<<>>>><<<<><<<>>>><<<>>><<>>><>><<><<>>>><>><<<><<<<>><<<<>><<<><>><<>><<><<<<><<<><<<>><<>>>><<>>><<<<><<<>><<>>>><<<<><<>>><<>><<<<><<><<<<>>>><<>>><<<<>><<<<>>><<<<>>><<<<>><<<<><<>>>><>>>><<<>>>><>>><<<>><<>><><<<><>>>><<<<>>><<<>>>><<><<<<>>>><><>>>><<<>>>><<><<<<>><<><<<<>>><<<<><>>>><>>><<><<<>><>>>><<<>>>><<>>><<>>><<<><<>>><<<>><<>>><<<>>>><>>><<>>>><>>><>><><<>>>><>>><<>>>><>>>><>><><<<<><<<>>>><<<<>>>><<<<>>><<>>><>>>><>><<<><<<<>>><<<<>>>><<>>>><<>>>><<>><<><>><<<<>>><<<>>>><<<<>>><><<<<>><<<><><><<<><<>>>><<>>>><>>><<>><<><<<<><><>>>><<<<>>>><<<<>><>><<<>><<><<>>>><<<<>>>><<<>><>><<<>><>>><<>>>><<>><<>>>><<>><<>>>><<<><>>>><<<<>>><<>><<<><<<<><<>><<<<>><<<>>>><<>>>><<<<>>>><<>>><>>><<><<<<><<>>><<<>>>><<><<>>>><<<>>>><<<<><<><<>>><<<<>><<<>>><>><<<<>>>><<>>><<<<>>>><>><<<><<><<<>>>><<<<><<>>><>>>><<>>>><<<<>>><>>>><<<<>>><<>>><<>>><<>>>><<>><<<>>><<<><<>>><<>>><<>>><>>><<<>>>><<<<>><<<<>>>><><<>>>><<>>>><<><<<>>>><<<>>>><<<><<>>><<<>>>><<><<<>>><<>><<<>>>><<><<>>><>>><>>><<>>>><><<<<><>>><>>>><<<<>>>><<>>>><>>><<<>>>><<>>>><<><<<<>>><<<<>><><<>>>><<<>>><<<<>>><<>>>><<<<>><>>>><<<<><<<<>>>><<<<>><<<<>><<<<><<><<<><<><<><<<<><<>>><<<<>><><<<>>>><<>><>><<<<>>>><><<><<<<>><<<<>><<<>>><>><<<<>>>><<>>><>>><<<>>>><<<>>>><<<>><<>><<<><>>>><<<<>>>><>>>><<<<>>><<>>>><<<>>><<<<>><>>>><<<><<<<>>><>>><<<<>><<<>><<<>><<<>>>><>>>><<>><<<>><><>>>><<<<><<>><<>>><<<>>><>>>><<<><<<<>><<>>><<<<>>>><<>>>><<<>><<<<>>><<<><<>><>>>><<<<><<<<>>><<>><<<>>><<>><<<>>><<<>>><>>><<<<><<>>><<<<>><<<<>>>><>>><<<<>>>><>>><<<<>>>><<<<>><<><<>><<<<>><<<<>>><<>>><<<><<>><>><<<><<<<>>>><<>><<>><<<<>>><<>><<>>>><<>><><<>>>><<<<>>><<><<<>>><<<>>><>>><<<<>>>><<<>><<>>>><<<<>><>><>>><<>><<<>>>><<<><<<<>>><><<<<>>><<<>>>><<<<>>>><<<>><<><<>><<<<>>><<><<<<><>>><>>>><><<>>>><<<><<<<><><<>>><<>>><<<<>>><<<>>>><>><<<<>><<<<>>><<<<>>><<<<>><<<>>><<<>>>><<<><<>>>><<<><<<<>><<<<><<<<>><<<<>>>><<>>>><<<<>>><><<<>>>><<<><>>><<><<<<>>>><<>>><<<<>>><<<>><<<>>><<<<>>>><<<><<<>>>><<<>>><<>>>><>><<>>><<<>>><<<>>>><>>><<<>>><<><><><<<<>><<<<>><<<<>>><<<>>>><<><>><>><<><<<<>>>><>><><<<<>><<<<><>>>><<<>>>><><><<<<><>>><<<>><<<>>>><<<<>>><<<>><<<<><<>><>><>>><<><<>>>><<<<>>><>>><><><<<<>>><<<<>>><><>><<><<<>><>>>><<<<><<<>>>><>>><<<>>>><<>><>>><<<<>><<<><<<>>>><>>><<<>><>>>><<<>>><<<><<<><<<>>>><<><<<>>>><<>>><<<<>>>><>><<>><<<>><<<<>>><<<>><<>><<<>>>><<<>>>><<<<>>><<<<>><<<<>>><<<<><<>>>><<>>><<<><><>><<>><<<>><>>>><<<>><<<<>>>><<<<><<<><<<><<>><<>>><<<<>>><>><>>>><<<<>>>><>>><<>>><>>>><>>>><<<>><<<<>>>><<<><>>>><<<<><<>><<<<>>>><<>><>><<>>><<>><<>>>><<<<>><<<>>><<><<<<>><<<<>>><<<><>><<><<>><<<<>><<<>>><<<<>>><<<>>><>><>><<<<>><<<>>>><<<<>>><<>>><<<<>>><<<>>>><<<<>><<>>>><><<><<<>>>><<<<>>>><><><>>>><<<<><<<>>>><>><>><<<>>>><<<>>>><>><><<>><<<><>><<>>><><>>><<>><<>><<>><<><<<>><<>><<<<><<<<>>>><<<<>><<<<>><<<>><<<<>><<<<>><>><>>><<<>>><<<><<>>>><<>><<<><<<>>><<<>>><<<<><<<>>><<>>><>><<<>>>><<<>><>>>><><<>>>><<<<><<>>><<<<><>>><<><>>><<<<>><<<>>><>><<<>>>><<<>><<><<<><<<>><<<>>>><<<>>>><>>>><<><>>>><<>>>><<>>>><<<<>><<>>>><<><>><<<<>><<<<><<<<><><><<>>>><><>>><<>>>><>><<<<>>><>>>><><<<<>>>><>><<<><<<><<<<>>>><<<>>>><<<>>><<<<>><<<><<<>>>><<<<>>><>>>><<>><<>>>><<<>>><<><<<<>>><><<><<<<>>><><<<>>>><<<>><<<><><<<<>><>><<<><<<>><>>><<<<>>><<<>>><<<>>>><<>><<<>>>><>>>><<>><<<>>>><<<<>>>><<<>>>><<<>>>><>><>>>><<<>><<>>><<><<<<>>><<<<><<>><<>><<<>><<<>>><<<><<<<>>><<<<>><>><<<>><<<<><>>><<<>>><<>>>><<<>><>><>>><<>>>><<<<><<<<>>><<<>>><<<>>>><<<>><<<<>>><<<<>>>><>>><<<>>>><<<>><<<>>><<<>>>><<<<>>>><<>>><><<<<><<>>><<><>>><<>>><<>>>><<<<>><<>>>><<<><><<<>><><<<>>>><<>>><>>>><<>><<>>><<>>>><<<<>>>><<>>>><<<><<><<<><<>><<>>><>><<>>>><<<>>>><>><<<>><>><<<<>><>><<<><<><><<><<<<>>><<><<><<<><<>>><<<>><<<>>>><<>>><>><><<><<<<><>><<<>><<>>>><>>><<<>>><>>>><<<<>>><>><<>>>><<<>>><<><<<<>>><<<>>>><<<<>>>><<<<>>>><>>>><<<<>><><><>>>><<<>><<<<>>>><<<>>><<>><<><<<>>><<<><<<><>>>><<<<>><<<<>>><<<>>><<<>>><<>><<><><<<>>><<<>>><<<><><<>><<>>><>>><<<>>><<<<>>>><<<<><<>>>><>>>><<><<>>><>>><<>>>><><<>>>><<>><<<<>>><><<>><<>><<>>><>><>>>><<<<>>><<>><<<><<<<>>><<<<>>><<><<<<>><>>><<><<<>>><<<<>>><<>>><><>>><<<<>>>><>><<<>><<<><<><<<>>><<<<>>><<>><<>>><<><<<>><<<<>>>><>>>><<<<>>><<>>>><><<<<>>><>><<>><<<>><<<<><<<>><<<<>>><<<>>><<><>><<<<><>><<<<>><<<><<<<>>><<<>><<<>><<<<><<<><<>>>><<>><<<>>>><><<<<>>>><<<<>><<<<><<>>>><><>>>><<<>>><>>><<<>><<<<>>><<<<>>>><<<<>>><<><>><<<<>><>>>><<<<>>>><>><<>><<<>><<<>><<>><<<>>><<<<>>><<<<>><<<<>>>><<><<<>><<<>>>><>>>><<>><<>><<<>>><<>><<<<><<>>><<<>>><><<><>><>>><<>>><<<<><<><<<<><><<<>>><>>>><>>>><<<>>>><>><<<>>><>><><><<><>>><<>><<<>>><<<<>>>><<>><>>>><>>><<<>><<<>><<<<>>>><<<>><<<>>><>>>><<<<>><>><<><>>>><<<><>><<<>>>><<>>><>>><<<<>>>><<<><>>>><<<<><<<<>>><<<>>>><<<>>><<<>><<<<>>><<<<>><<<<>>>><<<<><<>>>><<>>><<>>><<<<>>>><><<<<>>>><<<>>>><>>>><<<><<><><<>><<<<>><<>><<<<>>>><<<>><<<>><<<><<<><<<<><<<>>><><>>>><>>><<<>>><<<>>><<<>><<<<>><<<<>>>><<<>>>><<>><<<>>><>>>><<>><>>>><>><<<<>>>><><<<>>>><<<>><<>>>><<<<><><<>>>><><<>><<<>><<<<>>><<<>>>><<<><>><<<><><<<<>><<<>><<<><<>>><<<>>><<<<>><>><<<><<<<>>><<<<><><><<<>><<<<>><<>><<<><<>><<<<>>><<<<>>>><<<>>><<>>>><<<<>>>><<<><<<>>>><<>>>><<<<>>><<>>>><<<>>><<<>><>>>><<<<>>><<>><<<>><<><>>>><<<><<<<>>><><<<<>><<<>>>><>><<><>>>><<<<>>><>>><<><>><><<<<>><>>><<>><<>>><<>><<>><<>>>><<<>>><>><<>>><<>>><>><><<<>><<<<>>>><<<>>>><<>><<><<>>><<>><<<>><>>><<>>>><<<<><<><<<<>><>>><<>><><<<><<<<>>>><<<>><<>>><<<<>>>><>>>><<<>>>><<<><<>><><<<<><<<>>><<<<>>><<<>>><<<>>><>><>><><<>>>><<>><<<>><<<>>><<<>>>><<><<<><>>><<<><<<>><<<>>><<>><<<>>><<>>><<<<>><>><><<<>>><<<>>>><>>><>>><<<>>><<<>>><<>>><<<<><<<<>><><<>>>><<<>>><<<><<<>>><><<>>>><<>>><<>><<<>>><<><<<>>><>><<>>><<>><<<><<>>><><<><<>>><<><><<<>>>><<<<>>>><<<>><<<<>><<<<><<<><>>>><<>>>><<><>>><<>>><<><>>>><<<<>>>><<<>><<<<>><>>><<<<>>>><<<<>>>><<<<>>>><<<<>>><><><<>>><<<>>>><<<<>><<<<><<<>><<><<><>>>><><<<>>><<>>>><<<>>>><<<<>>><<<<>>>><<<>><<<>><<<<><<<<>>>><<>><<>>>><<<<>>><<<>>><<>>><<>>>><><<<<>><<<>>><<<>><<<<>>><<<<>>>><>><>><<>>>><<<>><<<>>>><<<<>><<<<>><>>>><><>><<<<>><<<>><<<>>><><>>><<<<>>><<<>>>><<<>><><<<>><<<<>><<<<>>>><><<<>>><>><<<><>>>><<<>>>><>>>><<<>>>><<<><<<><<>>>><>><<<<>><<>>><<<<>>>><<>><<<<>>><<<>>><<<<>>>><>><<>><<<>>>><<<>>><<>>><<<>>><>>><<<<><<<<><<>>><>>";
            HashSet<(int, long)> grid = new();

            List<Shape> shapes = new()
            {
                new Shape(new() { (0, 0), (1, 0), (2, 0), (3, 0) }),        // ####

                // # 
                new Shape(new() { (1, 0), (0, 1), (1, 1), (2, 1), (1, 2) }), //###
                                                                             // #

                //   # 
                new Shape(new() { (2, 2), (2, 1), (0, 0), (1, 0), (2, 0) }), //   #
                                                                             // ###

                // # 
                new Shape(new() { (0, 0), (0, 1), (0, 2), (0, 3) }),        // #
                                                                            // #
                                                                            // #

                new Shape(new() { (0, 0), (0, 1), (1, 0), (1, 1) }),        // ##
                                                                            // ##
            };

            const int Steps = 2022;
            int shapeNr = 0;
            long curLowest = 0;
            for (int i = 0, n = 0; i < Steps; i++, shapeNr++)
            {
                bool stopped = false;
                bool moveDown = false;
                if (shapeNr == shapes.Count)
                    shapeNr = 0;

                // Doing it this way ensures I can edit the new shape without altering the original
                var newShape = new Shape(new HashSet<(int, long)>(shapes[shapeNr].shape));

                if (!newShape.Move((3, curLowest + 4), grid, 0))
                    Console.WriteLine("Something went wrong, initial place failed");
                while (true)
                {
                    if (n == movement.Length)
                        n = 0;
                    if (moveDown)
                    {
                        if (!newShape.Move((0, -1), grid, 0))
                        {
                            foreach (var l in newShape.shape)
                                grid.Add(l);
                            stopped = true;
                        }
                        moveDown = false;
                    }
                    else
                    {
                        switch (movement[n])
                        {
                            case '<':
                                newShape.Move((-1, 0), grid, 0);
                                break;

                            case '>':
                                newShape.Move((1, 0), grid, 0);
                                break;

                        }
                        n++;
                        moveDown = true;
                    }

                    if (stopped)
                    {
                        curLowest = grid.Max(g => g.Item2);
                        break;
                    }
                }
            }

            Console.WriteLine(curLowest);
        }

        public static void Part2()
        {
            //string movement = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";
            //string movement = "v";
            string movement = "><<<<>>><<<><<<<>>><<<>>><<<><<<<><<>>><<<>><<<<>>>><<<><<>>><>><<<<>>><><<><<>><<<>>><<<>>>><<>><>>>><>>><<<<>>>><<<<>>><<<>>>><>>><<<>><>><<><<<>>>><>>><<>><<<><<<><<<>>><>>><<<>><<<><><<>>>><<>>><>>>><<<>>><<<><<<<>>><<<><<<<><<>><>>><<>><<<<>>>><<<>><>>><<>><<>>>><<<<><<<<><<<><<>>><>>><<><<>><<>><<>>><<>>><>>>><<<><><<>>><<<<><<>>>><>>>><<<><>><<>>><<<<>>><<<<>>>><>><>><<>>>><<<<>><<<<>>><<<<><<<<><<<<>>>><<<<>>><<>>><<>>>><>>><<<>>>><<<>><<<>>>><<><<<<>><<>>><<<<><<<>>>><<><<>>><<<<><<><><<<<>><<<>>>><>>>><<<>>>><<<<>><><<<<>><<<<><><<<<>>>><<<>>>><>><<<>><<<<>>><>>><<<><<>>>><<>><>>>><>>><<<<>><><<<>>>><<><<<<><<<>><<<<>>><<>>><<<<><>>>><<><<<>><<<><>><<>>><<<><>>><<<<><<<>>><<<<>>><<>>><<<<>><<<<><<>>><<<>>><>>>><<<>><>>>><<>>>><<<>><<>>>><><<><<<<>>>><<<>><<<><<<>>><<>>>><<>><<><<<>><><<<<><<>>>><<<<>>>><<><>><<<><<>>>><<<><<<<>>>><<<><<>>><<>>>><>><>>>><<>>>><<<>>>><<<>>>><>>><<<<>>>><<<<>><<>><>>><<>>><<><<<>>>><<<<>>>><<><<<>><<>>><>>><<><<<<><<>><<<>>>><<<>>><<<><>>><<<<>>>><<>>><>>><<<<>>><>>>><<<<>><<<<>>>><<<<>><>>><<<<>>>><<><<<<>>><<>><<>>><<<>>><><<><<<>>>><>><>><<>>><<>>>><<<<>>>><<<<>><<<<>><>>><<>>><<<<>>><<<<><>>><<<><<<<><<<>><>>><<<>><<<<>><<<<><<><<<><<<<>>><<>><<<>><<<>>><<<<><<<>>><<><>>>><<<<><<<>><<<>>>><<<<><<<>>><<><<<<>>>><<<<>>>><<>>>><<<>>>><<><>>><>>><<<<>>><<>>>><<<<>>>><<<<>>>><<<>>><><<<><><<<><><><>>><><<<<><<>>><>>>><<>>>><<<<>><<<>>><<<><><<>><<<<><<<><<>>><>>>><<<<>><<>><<>><<<<>>>><<<>>>><<<>>><>><<>><>>><<>>>><<<<>>>><<<<>>><<<><>>>><>><<<<>>>><>>>><<><<<<>>>><<<>><<<>>><<>>><<>>><><<<<><<>>>><<>>>><<<>><<>><<>>>><><<<>><<>>>><<<>><<<>>><<>>><>><<<<>>>><>>>><<<<>>>><<>>>><<>>><>>><<<>>><<>><<<<><<<<><<>>>><<>>>><<<><<<<><<<><>><>><<<><><>><>><><<<>><<<<>>><>>><<<>><<<>>><<<>>>><>>>><<<>>>><<<<>>>><<<><>>>><<<>>>><<<><<<<>>><>>>><<<>><<<<><<<>>><<<<>><><<<<>>>><<<>>><>>>><>>>><><<>><<><<<>><>>><><><<>>><><<<>>>><<><>>><<<<>><<>><><>><<<>>>><<<>>>><<><<<>>><<<<><<>>><<><<>><<>><<<<>>>><<><<<>>>><<><>>>><<><<<>><<<<>>>><<<<>><<><<<<><<<<><<>>><<<<>>><<>>>><<<<>>>><>>>><>>><<>><<<<><<<>><<>><<<>>><<<>><<<><<<<>>>><>>>><<><<>><<<>>><<<<>><<<>>>><<>>>><<<><<<>>>><<<><<<<>><<<<>>>><<><<>><<<>>><<<><<<>>>><<<<>><<><<><<<<>>>><<>><>>>><<>>>><>>>><<><<>><<<>>><>>><<<<>><>>>><<<<>>>><>><<<>>>><<<<>><<<<>>><<<>><<<<>><<<>><<<<>><<<<>>>><<<><>><<<<>>><<<<>>>><<>><<<><<<<>>><<<>><<<>>><<>><>>><<>><<<<>>><<<><>>><>>><>>><<<<>>><<<<>><<<<>>><>>><>><<<<>><<<<>>>><<><<<>>><<<<>>><>><<>>><<>><<<>><>>>><<>><<<><<<>>><<<>>><><<><<<><<>>><<>>><<>><<>>><<>>>><<<><>><>>><<<<>>><<<>>>><<>><<><<<<>><<<>>><<<><<>><>><>>><<<>>><<>><<<<>>>><<<<>>>><<>><<<><<<<>><<<>>><><<>>>><<<<>><>><<<>><<<>>>><<<<><<<>>>><<<><<<<><>>><<>><>>>><<>>><>>>><<<>><<<<><<><<>>>><<><<<<><<>><<<<>>><<<<>>>><>>><<<><>>>><<>>>><<<>><<<>>>><<>><<<<>><><<<<>>><<>>>><<<<><<>>><<<>><>>>><<<><<<<><<<><><>>><<><<<>><<>>><<<<><<>>><><<<>>><>><<>>>><<>><<>>><<>>><<>>><>><><<<><<<>>>><>>>><<><<<<>>>><<<>>><<<<>>><<<><<<>>>><<<><<<><<<<>>>><<<<><<><<<>>>><>>><<<><>><<>><<<<>>>><>><<>><<<<>>><<<<>>><>>><>>><>><<<<><<<><<<><<<<>><>>><<<><<>>><<<>><>><><><><>>><<><<<<>><<<>>>><<><<<<>>>><<<>>><><<<<>>>><>>>><<<<><<>><>><>>><>>>><<><>><<<<>><<<<>><<><<<>>>><<<<>>>><<<<>>><<><<<<>><<<<>><<<>>><<<>>><>><<<<>>><<<>><<<><<<<><<<<><<<>>><<>>><<><<>>><><<>>><<<<>><<<>>><>>>><<>><>>>><<>><<<<>>>><<><<<>>><<<>>>><>>><<>><>><<<>><>>>><<<>><<<<>>>><<>>><>><<>>>><<<<><<<<><<<>><<<>><><<<<>>>><<<>>><<<<>><><>>><<><>>>><>><<<<>>><>>><<<><>>><>><>>>><<>>><<<><><<<<>><>>>><>>>><<<>>><<<<>>><<<<>><<<<>><<<>>>><<<><<<<>><<<>>><<<><<<>>><<><<>>><<<>>><<>><<<<>>><<<>>><>><<<<><<<<><>><><<<<>><<<>><<>>>><<<>><<>><<<<>>>><<>>><<<<><<<<><<>>>><<>>><<<>><>>>><<<<><<><<>>>><<>>>><<<>><>>><>>><<<<>>><<<<>>><<>><<>>><>>><<<>>>><<>>><<<>>><<>><<<<>>><>><<<>>>><><<<<><<>>><<<<>>><<<<>>>><<<<>><>>>><>>><<><<>>><<>><<<>>><><<<<>>>><<<<><<<>>>><<<>>><<>>><>><<><<>>>><>><<<><<<<>><<<<>><<<><>><<>><<><<<<><<<><<<>><<>>>><<>>><<<<><<<>><<>>>><<<<><<>>><<>><<<<><<><<<<>>>><<>>><<<<>><<<<>>><<<<>>><<<<>><<<<><<>>>><>>>><<<>>>><>>><<<>><<>><><<<><>>>><<<<>>><<<>>>><<><<<<>>>><><>>>><<<>>>><<><<<<>><<><<<<>>><<<<><>>>><>>><<><<<>><>>>><<<>>>><<>>><<>>><<<><<>>><<<>><<>>><<<>>>><>>><<>>>><>>><>><><<>>>><>>><<>>>><>>>><>><><<<<><<<>>>><<<<>>>><<<<>>><<>>><>>>><>><<<><<<<>>><<<<>>>><<>>>><<>>>><<>><<><>><<<<>>><<<>>>><<<<>>><><<<<>><<<><><><<<><<>>>><<>>>><>>><<>><<><<<<><><>>>><<<<>>>><<<<>><>><<<>><<><<>>>><<<<>>>><<<>><>><<<>><>>><<>>>><<>><<>>>><<>><<>>>><<<><>>>><<<<>>><<>><<<><<<<><<>><<<<>><<<>>>><<>>>><<<<>>>><<>>><>>><<><<<<><<>>><<<>>>><<><<>>>><<<>>>><<<<><<><<>>><<<<>><<<>>><>><<<<>>>><<>>><<<<>>>><>><<<><<><<<>>>><<<<><<>>><>>>><<>>>><<<<>>><>>>><<<<>>><<>>><<>>><<>>>><<>><<<>>><<<><<>>><<>>><<>>><>>><<<>>>><<<<>><<<<>>>><><<>>>><<>>>><<><<<>>>><<<>>>><<<><<>>><<<>>>><<><<<>>><<>><<<>>>><<><<>>><>>><>>><<>>>><><<<<><>>><>>>><<<<>>>><<>>>><>>><<<>>>><<>>>><<><<<<>>><<<<>><><<>>>><<<>>><<<<>>><<>>>><<<<>><>>>><<<<><<<<>>>><<<<>><<<<>><<<<><<><<<><<><<><<<<><<>>><<<<>><><<<>>>><<>><>><<<<>>>><><<><<<<>><<<<>><<<>>><>><<<<>>>><<>>><>>><<<>>>><<<>>>><<<>><<>><<<><>>>><<<<>>>><>>>><<<<>>><<>>>><<<>>><<<<>><>>>><<<><<<<>>><>>><<<<>><<<>><<<>><<<>>>><>>>><<>><<<>><><>>>><<<<><<>><<>>><<<>>><>>>><<<><<<<>><<>>><<<<>>>><<>>>><<<>><<<<>>><<<><<>><>>>><<<<><<<<>>><<>><<<>>><<>><<<>>><<<>>><>>><<<<><<>>><<<<>><<<<>>>><>>><<<<>>>><>>><<<<>>>><<<<>><<><<>><<<<>><<<<>>><<>>><<<><<>><>><<<><<<<>>>><<>><<>><<<<>>><<>><<>>>><<>><><<>>>><<<<>>><<><<<>>><<<>>><>>><<<<>>>><<<>><<>>>><<<<>><>><>>><<>><<<>>>><<<><<<<>>><><<<<>>><<<>>>><<<<>>>><<<>><<><<>><<<<>>><<><<<<><>>><>>>><><<>>>><<<><<<<><><<>>><<>>><<<<>>><<<>>>><>><<<<>><<<<>>><<<<>>><<<<>><<<>>><<<>>>><<<><<>>>><<<><<<<>><<<<><<<<>><<<<>>>><<>>>><<<<>>><><<<>>>><<<><>>><<><<<<>>>><<>>><<<<>>><<<>><<<>>><<<<>>>><<<><<<>>>><<<>>><<>>>><>><<>>><<<>>><<<>>>><>>><<<>>><<><><><<<<>><<<<>><<<<>>><<<>>>><<><>><>><<><<<<>>>><>><><<<<>><<<<><>>>><<<>>>><><><<<<><>>><<<>><<<>>>><<<<>>><<<>><<<<><<>><>><>>><<><<>>>><<<<>>><>>><><><<<<>>><<<<>>><><>><<><<<>><>>>><<<<><<<>>>><>>><<<>>>><<>><>>><<<<>><<<><<<>>>><>>><<<>><>>>><<<>>><<<><<<><<<>>>><<><<<>>>><<>>><<<<>>>><>><<>><<<>><<<<>>><<<>><<>><<<>>>><<<>>>><<<<>>><<<<>><<<<>>><<<<><<>>>><<>>><<<><><>><<>><<<>><>>>><<<>><<<<>>>><<<<><<<><<<><<>><<>>><<<<>>><>><>>>><<<<>>>><>>><<>>><>>>><>>>><<<>><<<<>>>><<<><>>>><<<<><<>><<<<>>>><<>><>><<>>><<>><<>>>><<<<>><<<>>><<><<<<>><<<<>>><<<><>><<><<>><<<<>><<<>>><<<<>>><<<>>><>><>><<<<>><<<>>>><<<<>>><<>>><<<<>>><<<>>>><<<<>><<>>>><><<><<<>>>><<<<>>>><><><>>>><<<<><<<>>>><>><>><<<>>>><<<>>>><>><><<>><<<><>><<>>><><>>><<>><<>><<>><<><<<>><<>><<<<><<<<>>>><<<<>><<<<>><<<>><<<<>><<<<>><>><>>><<<>>><<<><<>>>><<>><<<><<<>>><<<>>><<<<><<<>>><<>>><>><<<>>>><<<>><>>>><><<>>>><<<<><<>>><<<<><>>><<><>>><<<<>><<<>>><>><<<>>>><<<>><<><<<><<<>><<<>>>><<<>>>><>>>><<><>>>><<>>>><<>>>><<<<>><<>>>><<><>><<<<>><<<<><<<<><><><<>>>><><>>><<>>>><>><<<<>>><>>>><><<<<>>>><>><<<><<<><<<<>>>><<<>>>><<<>>><<<<>><<<><<<>>>><<<<>>><>>>><<>><<>>>><<<>>><<><<<<>>><><<><<<<>>><><<<>>>><<<>><<<><><<<<>><>><<<><<<>><>>><<<<>>><<<>>><<<>>>><<>><<<>>>><>>>><<>><<<>>>><<<<>>>><<<>>>><<<>>>><>><>>>><<<>><<>>><<><<<<>>><<<<><<>><<>><<<>><<<>>><<<><<<<>>><<<<>><>><<<>><<<<><>>><<<>>><<>>>><<<>><>><>>><<>>>><<<<><<<<>>><<<>>><<<>>>><<<>><<<<>>><<<<>>>><>>><<<>>>><<<>><<<>>><<<>>>><<<<>>>><<>>><><<<<><<>>><<><>>><<>>><<>>>><<<<>><<>>>><<<><><<<>><><<<>>>><<>>><>>>><<>><<>>><<>>>><<<<>>>><<>>>><<<><<><<<><<>><<>>><>><<>>>><<<>>>><>><<<>><>><<<<>><>><<<><<><><<><<<<>>><<><<><<<><<>>><<<>><<<>>>><<>>><>><><<><<<<><>><<<>><<>>>><>>><<<>>><>>>><<<<>>><>><<>>>><<<>>><<><<<<>>><<<>>>><<<<>>>><<<<>>>><>>>><<<<>><><><>>>><<<>><<<<>>>><<<>>><<>><<><<<>>><<<><<<><>>>><<<<>><<<<>>><<<>>><<<>>><<>><<><><<<>>><<<>>><<<><><<>><<>>><>>><<<>>><<<<>>>><<<<><<>>>><>>>><<><<>>><>>><<>>>><><<>>>><<>><<<<>>><><<>><<>><<>>><>><>>>><<<<>>><<>><<<><<<<>>><<<<>>><<><<<<>><>>><<><<<>>><<<<>>><<>>><><>>><<<<>>>><>><<<>><<<><<><<<>>><<<<>>><<>><<>>><<><<<>><<<<>>>><>>>><<<<>>><<>>>><><<<<>>><>><<>><<<>><<<<><<<>><<<<>>><<<>>><<><>><<<<><>><<<<>><<<><<<<>>><<<>><<<>><<<<><<<><<>>>><<>><<<>>>><><<<<>>>><<<<>><<<<><<>>>><><>>>><<<>>><>>><<<>><<<<>>><<<<>>>><<<<>>><<><>><<<<>><>>>><<<<>>>><>><<>><<<>><<<>><<>><<<>>><<<<>>><<<<>><<<<>>>><<><<<>><<<>>>><>>>><<>><<>><<<>>><<>><<<<><<>>><<<>>><><<><>><>>><<>>><<<<><<><<<<><><<<>>><>>>><>>>><<<>>>><>><<<>>><>><><><<><>>><<>><<<>>><<<<>>>><<>><>>>><>>><<<>><<<>><<<<>>>><<<>><<<>>><>>>><<<<>><>><<><>>>><<<><>><<<>>>><<>>><>>><<<<>>>><<<><>>>><<<<><<<<>>><<<>>>><<<>>><<<>><<<<>>><<<<>><<<<>>>><<<<><<>>>><<>>><<>>><<<<>>>><><<<<>>>><<<>>>><>>>><<<><<><><<>><<<<>><<>><<<<>>>><<<>><<<>><<<><<<><<<<><<<>>><><>>>><>>><<<>>><<<>>><<<>><<<<>><<<<>>>><<<>>>><<>><<<>>><>>>><<>><>>>><>><<<<>>>><><<<>>>><<<>><<>>>><<<<><><<>>>><><<>><<<>><<<<>>><<<>>>><<<><>><<<><><<<<>><<<>><<<><<>>><<<>>><<<<>><>><<<><<<<>>><<<<><><><<<>><<<<>><<>><<<><<>><<<<>>><<<<>>>><<<>>><<>>>><<<<>>>><<<><<<>>>><<>>>><<<<>>><<>>>><<<>>><<<>><>>>><<<<>>><<>><<<>><<><>>>><<<><<<<>>><><<<<>><<<>>>><>><<><>>>><<<<>>><>>><<><>><><<<<>><>>><<>><<>>><<>><<>><<>>>><<<>>><>><<>>><<>>><>><><<<>><<<<>>>><<<>>>><<>><<><<>>><<>><<<>><>>><<>>>><<<<><<><<<<>><>>><<>><><<<><<<<>>>><<<>><<>>><<<<>>>><>>>><<<>>>><<<><<>><><<<<><<<>>><<<<>>><<<>>><<<>>><>><>><><<>>>><<>><<<>><<<>>><<<>>>><<><<<><>>><<<><<<>><<<>>><<>><<<>>><<>>><<<<>><>><><<<>>><<<>>>><>>><>>><<<>>><<<>>><<>>><<<<><<<<>><><<>>>><<<>>><<<><<<>>><><<>>>><<>>><<>><<<>>><<><<<>>><>><<>>><<>><<<><<>>><><<><<>>><<><><<<>>>><<<<>>>><<<>><<<<>><<<<><<<><>>>><<>>>><<><>>><<>>><<><>>>><<<<>>>><<<>><<<<>><>>><<<<>>>><<<<>>>><<<<>>>><<<<>>><><><<>>><<<>>>><<<<>><<<<><<<>><<><<><>>>><><<<>>><<>>>><<<>>>><<<<>>><<<<>>>><<<>><<<>><<<<><<<<>>>><<>><<>>>><<<<>>><<<>>><<>>><<>>>><><<<<>><<<>>><<<>><<<<>>><<<<>>>><>><>><<>>>><<<>><<<>>>><<<<>><<<<>><>>>><><>><<<<>><<<>><<<>>><><>>><<<<>>><<<>>>><<<>><><<<>><<<<>><<<<>>>><><<<>>><>><<<><>>>><<<>>>><>>>><<<>>>><<<><<<><<>>>><>><<<<>><<>>><<<<>>>><<>><<<<>>><<<>>><<<<>>>><>><<>><<<>>>><<<>>><<>>><<<>>><>>><<<<><<<<><<>>><>>";
            HashSet<(int, long)> grid = new();

            List<Shape> shapes = new()
            {
                new Shape(new() { (0, 0), (1, 0), (2, 0), (3, 0) }),        // ####

                                                                             // # 
                new Shape(new() { (1, 0), (0, 1), (1, 1), (2, 1), (1, 2) }), //###
                                                                             // #

                                                                             //   # 
                new Shape(new() { (2, 2), (2, 1), (0, 0), (1, 0), (2, 0) }), //   #
                                                                             // ###

                                                                            // # 
                new Shape(new() { (0, 0), (0, 1), (0, 2), (0, 3) }),        // #
                                                                            // #
                                                                            // #

                new Shape(new() { (0, 0), (0, 1), (1, 0), (1, 1) }),        // ##
                                                                            // ##
            };

            const long Steps = 1_000_000_000_000;
            int shapeNr = 0;// 4;
            long curLowest = 0, height;
            long floor = 0;
            int n = 0;
            long i = 0;//414;
            HashSet<(int, long)> firstSet, otherSet = new();

            i = 1715;
            shapeNr = 0;
            n = 10033;
            height = 2732;
            for (; i + 1715 < Steps; i += 1715)
                height += 2711;
            for (; i < Steps; i++, shapeNr++)
            {
                bool stopped = false;
                bool moveDown = false;
                if (shapeNr == shapes.Count)
                    shapeNr = 0;

                // Doing it this way ensures I can edit the new shape without altering the original
                var newShape = new Shape(new HashSet<(int, long)>(shapes[shapeNr].shape));

                if (!newShape.Move((3, curLowest + 4), grid, floor))
                    Console.WriteLine("Something went wrong, initial place failed");
                while (true)
                {
                    if (n == movement.Length)
                        n = 0;

                    if (moveDown)
                    {
                        if (!newShape.Move((0, -1), grid, floor))
                        {
                            foreach (var l in newShape.shape)
                                grid.Add(l);
                            stopped = true;
                        }
                        moveDown = false;
                    }
                    else
                    {
                        switch (movement[n])
                        {
                            case '<':
                                newShape.Move((-1, 0), grid, floor);
                                break;

                            case '>':
                                newShape.Move((1, 0), grid, floor);
                                break;

                            default:
                                break;

                        }
                        n++;
                        moveDown = true;
                    }

                    if (stopped)
                    {
                        curLowest = grid.Max(g => g.Item2);
                        /*if (i == 1715)
                        {
                            height += curLowest;
                            curLowest = 0;
                            firstSet = new HashSet<(int, long)>(grid);
                            grid.Clear();
                        }
                        if (i >= 1715 && i  % 1715 == 0)
                        {
                            bool b = true;
                            if (otherSet.Count > 0)
                            {
                                foreach(var l in otherSet)
                                    if (!grid.Contains(l))
                                            b = false;
                                foreach(var l in grid)
                                    if (!otherSet.Contains(l))
                                            b = false;

                                Console.WriteLine(b);
                                Console.WriteLine(curLowest);
                                Console.WriteLine();
                            }

                            otherSet = new HashSet<(int, long)>(grid);
                            height += curLowest;
                            curLowest = 0;
                            grid.Clear();
                            //i += 1714;
                        }*/
                        break;
                    }
                }
            }

            Console.WriteLine(height + curLowest);
            Console.ReadLine();
        }

        // First movement = 1715 steps with height 2733
        // n = 10033;
        // subsequent movement = 1715 steps with height 2711
        // 58309036 * 2711 + 2744 + 2438

        public class Shape
        {
            public HashSet<(int, long)> shape;

            public Shape(HashSet<(int, long)> shape)
            {
                this.shape = shape;
            }


            public bool Move((int, long) movement, HashSet<(int, long)> grid, long floor)
            {
                var newLoc = shape.Select(i => (i.Item1 + movement.Item1, i.Item2 + movement.Item2)).ToHashSet();
                if (newLoc.Any(l => l.Item1 <= 0 || l.Item1 >= 8 || l.Item2 <= floor || grid.Contains(l)))
                        return false;
                shape = newLoc;
                return true;
            }
        }

        public class GridComparer : IEqualityComparer<(int, long)>
        {
            public bool Equals((int, long) x, (int, long) y)
            {
                return x.Item1 == y.Item1;
            }

            public int GetHashCode((int, long) obj)
            {
                return obj.Item1.GetHashCode();
            }
        }
    }
}
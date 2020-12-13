using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace Advent_of_Code_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\input.txt");

            int width = data[0].Length;
            int height = data.Length;

            string[] grid = data;

            for (int i = 0; i < 1; i++)
            {
                string[] dynamicGrid = grid;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        if (SeatBecomesOccupied())
                        {
                            Console.WriteLine(dynamicGrid[y].Remove(x, 1).Insert(1, "#"));
                            dynamicGrid[y] = dynamicGrid[y].Remove(x, 1).Insert(1, "#");
                        }
                        else if (SeatIsLeft())
                        {
                            Console.WriteLine(x + " : " + y);
                            dynamicGrid[y] = dynamicGrid[y].Remove(x, 1).Insert(1, "L");
                        }
                        bool SeatBecomesOccupied()
                        {
                            // adjacentNotOccupiedSeatCount
                            int c = 0;
                            if (SeatExistsAndNotOccupied(x, y + 1))
                                c++;
                            if (SeatExistsAndNotOccupied(x + 1, y + 1))
                                c++;
                            if (SeatExistsAndNotOccupied(x + 1, y))
                                c++;
                            if (SeatExistsAndNotOccupied(x + 1, y - 1))
                                c++;
                            if (SeatExistsAndNotOccupied(x, y - 1))
                                c++;
                            if (SeatExistsAndNotOccupied(x - 1, y - 1))
                                c++;
                            if (SeatExistsAndNotOccupied(x - 1, y))
                                c++;
                            if (SeatExistsAndNotOccupied(x - 1, y + 1))
                                c++;
                            if (c == 0)
                                return true;
                            return false;
                        }
                        bool SeatIsLeft()
                        {
                            // adjacentOccupiedSeatCount
                            int c = 0;
                            if (SeatExistsAndOccupied(x, y + 1))
                                c++;
                            if (SeatExistsAndOccupied(x + 1, y + 1))
                                c++;
                            if (SeatExistsAndOccupied(x + 1, y))
                                c++;
                            if (SeatExistsAndOccupied(x + 1, y - 1))
                                c++;
                            if (SeatExistsAndOccupied(x, y - 1))
                                c++;
                            if (SeatExistsAndOccupied(x - 1, y - 1))
                                c++;
                            if (SeatExistsAndOccupied(x - 1, y))
                                c++;
                            if (SeatExistsAndOccupied(x - 1, y + 1))
                                c++;
                            if (c >= 4)
                                return true;
                            return false;
                        }
                    }
                }
                grid = dynamicGrid;

                /*
                int occupiedSeatCount = 0;
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

                foreach (string line in grid)
                {
                    Console.WriteLine(line);
                    foreach (char seat in line)
                    {
                        if (seat == '#')
                            occupiedSeatCount++;
                    }
                }
                Console.WriteLine("Occupied Seat Cout: " + occupiedSeatCount);
                */
            }




            bool SeatExists(int x, int y)
            {
                bool withinWidth = x < width && x > 0;
                bool withinHeight = y < height && y > 0;
                if (withinWidth && withinHeight)
                {
                    if (data[y][x] == 'L' || data[y][x] == '#')
                    {
                        return true;
                    }
                }
                return false;
            }
            bool SeatOccupied(int x, int y)
            {
                //Console.WriteLine(x);
                //Console.WriteLine(grid[y][x]);
                if (grid[y][x] == '#')
                    return true;
                return false;
            }
            bool SeatExistsAndNotOccupied(int x, int y)
            {
                if (SeatExists(x, y))
                    if (!SeatOccupied(x, y))
                    return true;
                return false;
            }
            bool SeatExistsAndOccupied(int x, int y)
            {
                if (SeatExists(x, y))
                {
                    if (SeatOccupied(x, y))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
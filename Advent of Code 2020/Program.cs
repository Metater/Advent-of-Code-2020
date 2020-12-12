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

            string[] previousGrid = new string[height];
            string[] grid = data;
            string[] dynamicGrid = new string[height];

            for (int i = 0; (previousGrid != grid); i++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (SeatBecomesOccupied() && SeatExists(x, y))
                            dynamicGrid[y] = dynamicGrid[y].Replace('L', '#');
                        else if (SeatIsLeft() && SeatExists(x, y))
                            dynamicGrid[y] = dynamicGrid[y].Replace('#', 'L');
                        bool SeatBecomesOccupied()
                        {
                            // adjacentNotOccupiedSeatCount
                            int c = 0;
                            if (SeatExistsAndNotOccupied(x, y+1))
                                c++;
                            if (SeatExistsAndNotOccupied(x+1, y+1))
                                c++;
                            if (SeatExistsAndNotOccupied(x+1, y))
                                c++;
                            if (SeatExistsAndNotOccupied(x+1, y-1))
                                c++;
                            if (SeatExistsAndNotOccupied(x, y-1))
                                c++;
                            if (SeatExistsAndNotOccupied(x-1, y-1))
                                c++;
                            if (SeatExistsAndNotOccupied(x-1, y))
                                c++;
                            if (SeatExistsAndNotOccupied(x-1, y+1))
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
                previousGrid = grid;
                grid = dynamicGrid;
            }


            int occupiedSeatCount = 0;

            foreach (string line in grid)
            {
                foreach (char seat in line)
                {
                    if (seat == '#')
                        occupiedSeatCount++;
                }
            }
            Console.WriteLine(occupiedSeatCount);




            bool SeatExists(int x, int y)
            {
                if (x > width-1 || x < 0)
                    return false;
                if (y > height-1 || y < 0)
                    return false;
                if (data[y][x] != 'L')
                    return false;
                return true;
            }
            bool SeatOccupied(int x, int y)
            {
                Console.WriteLine(x);
                Console.WriteLine(y);
                foreach (string line in grid)
                    Console.WriteLine(line);
                Console.WriteLine("------------------------------------------------");
                
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
                    if (SeatOccupied(x, y))
                        return true;
                return false;
            }
        }
    }
}
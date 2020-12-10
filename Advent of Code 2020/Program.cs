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
            string[] datam = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\pws.txt");
            for (int i = 0; i < datam.Length; i++)
            {
                string[] data = datam;

                if (data[i].Split(" ")[0] == "nop")
                {
                    Console.WriteLine("Replacing NOP with JMP");
                    string nl = "jmp " + data[i].Split(" ")[1];
                    data[i] = nl;
                    int accumulator = DoTheThing(data);
                    if (accumulator != -1)
                        Console.WriteLine(accumulator);
                }
                else if (data[i].Split(" ")[0] == "jmp")
                {
                    Console.WriteLine("Replacing JMP with NOP");
                    string nl = "nop " + data[i].Split(" ")[1];
                    data[i] = nl;
                    int accumulator = DoTheThing(data);
                    if (accumulator != -1)
                        Console.WriteLine(accumulator);
                }
                foreach(string a in data)
                {
                    //Console.WriteLine(i + a);
                }
            }
            /*
            int accumulator = DoTheThing(datam);
            Console.WriteLine(accumulator);
            */
        }
        static int DoTheThing(string[] data)
        {
            List<int> ranInstructions = new List<int>();
            int acc = 0;
            int pc = 0;
            int step = 1;
            for (pc = 0; step < 10;)
            {
                if (pc == data.Length)
                {
                    return acc;
                }
                if (step == 8)
                    return -1;
                string[] words = data[pc].Split();
                string operation = words[0];
                int argument = Int32.Parse(words[1]);
                switch (operation)
                {
                    case "acc":
                        Console.WriteLine("\tACC: " + step);
                        Console.WriteLine("\t\tPc: " + pc);
                        Console.WriteLine("\t\tAcc: " + acc);
                        Console.WriteLine("\t\tArg: " + argument);
                        ranInstructions.Add(pc);
                        acc += argument;
                        pc++;
                        step++;
                        Console.WriteLine("\tACC: " + step);
                        Console.WriteLine("\t\tPc: " + pc);
                        Console.WriteLine("\t\tAcc: " + acc);
                        Console.WriteLine("\t\tArg: " + argument);
                        break;
                    case "jmp":
                        Console.WriteLine("\tJMP: " + step);
                        Console.WriteLine("\t\tpc: " + pc);
                        Console.WriteLine("\t\tacc: " + acc);
                        Console.WriteLine("\t\tArg: " + argument);
                        ranInstructions.Add(pc);
                        pc += argument;
                        step++;
                        Console.WriteLine("\tJMP: " + step);
                        Console.WriteLine("\t\tpc: " + pc);
                        Console.WriteLine("\t\tacc: " + acc);
                        Console.WriteLine("\t\tArg: " + argument);
                        break;
                    case "nop":
                        Console.WriteLine("\tNOP: " + step);
                        Console.WriteLine("\t\tpc: " + pc);
                        Console.WriteLine("\t\tacc: " + acc);
                        Console.WriteLine("\t\tArg: " + argument);
                        ranInstructions.Add(pc);
                        pc++;
                        step++;
                        Console.WriteLine("\tNOP: " + step);
                        Console.WriteLine("\t\tpc: " + pc);
                        Console.WriteLine("\t\tacc: " + acc);
                        Console.WriteLine("\t\tArg: " + argument);
                        break;
                }
            }
            return acc;
        }
    }
}
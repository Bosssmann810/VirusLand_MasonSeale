using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace VirusLand_MasonSeale
{

    internal class Program
    {
        static char[,] map =
        {
            {'-', '-', '-', '-','^',},
            {'-', '-', '-', '~','-',},
            {'-', '-', '~', '-','-',},
            {'-', '-', '-', '-','-',},
            {'-', '-', '-', '-','-',}

        };
        static List<(int, int)> spots = new List<(int, int)>();
        static (int, int) position = (1, 2);
        static Random move = new Random();
        static Random infect = new Random();
        static List<(int, int)> nogozone = new List<(int, int)>();
        static void Main(string[] args)
        {
            spots.Add(position);
            nogozone.Add((0, 4));
            nogozone.Add((1, 3));
            nogozone.Add((2, 2));
            while (true)
            {
                boardsetting();
                Console.ReadKey(true);
                movement();
                Console.Clear();
            }
                
        }
        static void movement()
        {
            for (int i = 0; i < spots.Count; i++)
            {
                position = spots.ElementAt(i);
                int diditwork = infect.Next(1, 10);
                if (diditwork == 1)
                {
                    spots.Add((position.Item1, position.Item2));
                }
                else
                {
                    spots.Remove((position.Item1, position.Item2));
                }

                int whatwaywegoing = move.Next(1, 5);
                if (whatwaywegoing == 1)
                {
                    position.Item1++;
                    if (nogozone.Contains(((position.Item1, position.Item2))))
                    {
                        position.Item1--;
                    }
                    if (position.Item1 > 4)
                    {
                        position.Item1 = 4;

                    }
                    spots.Add((position.Item1, position.Item2));
                }
                else if (whatwaywegoing == 2)
                {
                    position.Item1--;
                    if (nogozone.Contains(((position.Item1, position.Item2))))
                    {
                        position.Item1++;
                    }
                    if (position.Item1 < 0)
                    {
                        position.Item1 = 0;
                    }
                    spots.Add((position.Item1, position.Item2));
                }
                else if (whatwaywegoing == 3)
                {
                    position.Item2++;
                    if (nogozone.Contains(((position.Item1, position.Item2))))
                    {
                        position.Item2--;
                    }
                    if (position.Item2 > 4)
                    {
                        position.Item2 = 4;
                    }
                    spots.Add((position.Item1, position.Item2));
                }
                else if (whatwaywegoing == 4)
                {
                    position.Item2--;
                    if (nogozone.Contains(((position.Item1, position.Item2))))
                    {
                        position.Item2++;
                    }
                    if (position.Item2 == 0)
                    {
                        position.Item2 = 0;
                    }
                    spots.Add((position.Item1, position.Item2));
                }
           }
    }
        static void boardsetting()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (nogozone.Contains((i, j)))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(map[i, j]);
                        continue;
                    }
                    if (spots.Contains((i, j)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write(map[i, j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(map[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }


    }
}

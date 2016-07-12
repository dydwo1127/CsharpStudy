using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[] circle = new int[n];
            for(int i = 0; i < n; i++)
            {
                circle[i] = i + 1;
            }
            int[] towerA = new int[n];
            int[] towerB = new int[n];
            int[] towerC = new int[n];

            towerA = circle;

            DrawHanoi(n, towerA, towerB, towerC);
        }

        static void DrawHanoi(int n, int[] towerA, int[] towerB, int[] towerC)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j <= 39; j++)
                {
                    if(j <= 6 - towerA[i])
                    {
                        Console.Write(" ");
                    }
                    if(j > 6 - towerA[i] && j <= 7 + towerA[i] && j != 7)
                    {
                        Console.Write("*");
                    }
                    if(j > 7 + towerA[i] && j <= 19 - towerB[i])
                    {
                        Console.Write(" ");
                    }
                    if(j > 19-towerB[i] && j <= 20 + towerB[i] && j != 20)
                    {
                        Console.Write("*");
                    }
                    if(j > 20+towerB[i] && j <= 32- towerC[i])
                    {
                        Console.Write(" ");
                    }
                    if(j > 32 - towerC[i] && j <=33+ towerC[i] && j !=33)
                    {
                        Console.Write("*");
                    }
                    if(j > 33+towerC[i] && j < 39)
                    {
                        Console.Write(" ");
                    }
                    if(j == 7 || j == 20 || j == 33)
                    {
                        Console.Write("|");
                    }
                    if(j == 39)
                    {
                        Console.WriteLine(" ");
                    }
                }
            }
        }
    }
}

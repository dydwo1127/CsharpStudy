﻿using System;
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
            Console.Write("원판의 갯수 : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] towerA = new int[n];
            int[] towerB = new int[n];
            int[] towerC = new int[n];
            for(int i = 0; i<n; i++)
            {
                towerA[i] = i + 1;
            }
            int move = 0 ;
            DrawHanoi(n, towerA, towerB, towerC);
            MoveDisk(n,n, towerA, towerB, towerC,towerA, towerB, towerC, ref move);
        }

        static void DrawHanoi(int n, int[] towerA, int[] towerB, int[] towerC)
        {
            for (int i = 0; i < n; i++)
            {
                DrawOneDisk(n, towerA[i]);
                DrawOneDisk(n, towerB[i]);
                DrawOneDisk(n, towerC[i]);
                Console.WriteLine("");
            }
        }
        
        static void DrawOneDisk(int maxdisknumber, int disktodraw)
        {
            for (int i = 0; i < 2 * maxdisknumber +3 ; i++)
            {
                if(i<maxdisknumber-disktodraw+1 || i > maxdisknumber + disktodraw +1)
                {
                    Console.Write(" ");
                }
                if(i>=maxdisknumber-disktodraw+1 && i<=maxdisknumber+disktodraw+1 && i != maxdisknumber+1)
                {
                    Console.Write("*");
                }
                if(i==maxdisknumber+1)
                {
                    Console.Write("|");
                }
            }
        }

        static int FindFirstNonzero(int[] tower)
        {
            int number = 0;
            for(int i = 0; i < tower.Length; i++)
            {
                if(tower[i] != 0)
                {
                    number = i;
                    break;
                }
            }
            return number;
        }

        static int FindLastZero(int[] tower)
        {
            int number = 0;
            for(int i = tower.Length-1; i >= 0; i--)
            {
                if(tower[i] == 0)
                {
                    number = i;
                    break;
                }
            }
            return number;
        }

        static void MoveDisk(int n, int disk, int[] from, int[] via, int[] to, int[] towerA, int[] towerB, int[] towerC, ref int move)
        {
            if(n==1)
            {
                to[FindLastZero(to)] = from[FindFirstNonzero(from)];
                from[FindFirstNonzero(from)] = 0;
                move++;
                Console.WriteLine(move);
                DrawHanoi(disk, towerA, towerB, towerC);
            }
            else
            {
                MoveDisk(n - 1,disk, from, to, via, towerA, towerB, towerC, ref move);
                to[FindLastZero(to)] = from[FindFirstNonzero(from)];
                from[FindFirstNonzero(from)] = 0;
                move++;
                Console.WriteLine(move);
                DrawHanoi(disk, towerA, towerB, towerC);
                MoveDisk(n - 1,disk, via, from, to,towerA, towerB, towerC, ref move);
            }
        }
    }
}

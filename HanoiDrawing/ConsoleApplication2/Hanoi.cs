using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Tower
    {
        private readonly int maxDisk;
        public int[] disks { get; private set; }
        public void InsertAll()
        {
            for (int i = 0; i < maxDisk; i++)
            {
                disks[i] = i + 1;
            }
        }
        public Tower(int maxDisk)
        {
            this.maxDisk = maxDisk;
            disks = new int[maxDisk];
        }
        public int RemoveDisk()
        {
            int temp = 0;
            for(int i = 0; i<maxDisk; i++)
            {
                if(disks[i] != 0)
                {
                    temp = disks[i];
                    disks[i] = 0;
                    break;
                }
            }
            return temp;
        }
        public void InsertDisk(int size)
        {
            for(int i = maxDisk -1; i >= 0; i--)
            {
                if(disks[i] == 0)
                {
                    disks[i] = size;
                    break;
                }
            }
        }
    }
    public class Hanoi
    {
        private Tower towerA;
        private Tower towerB;
        private Tower towerC;
        private int maxDiskNumber;
        private int move = 0;

        public Hanoi(int numofDisk)
        {
            towerA = new Tower(numofDisk);
            towerB = new Tower(numofDisk);
            towerC = new Tower(numofDisk);
            towerA.InsertAll();
            maxDiskNumber = numofDisk;
        }
        public void Run()
        {
            DrawHanoi(maxDiskNumber, towerA, towerB, towerC);
            MoveDisk(maxDiskNumber, maxDiskNumber, towerA,towerB,towerC,towerA,towerB,towerC);
        }

        private void DrawOneDisk(int maxdisknumber, int disktodraw)
        {
            for (int i = 0; i < 2 * maxdisknumber + 3; i++)
            {
                if (i < maxdisknumber - disktodraw + 1 || i > maxdisknumber + disktodraw + 1)
                {
                    Console.Write(" ");
                }
                if (i >= maxdisknumber - disktodraw + 1 && i <= maxdisknumber + disktodraw + 1 && i != maxdisknumber + 1)
                {
                    Console.Write("*");
                }
                if (i == maxdisknumber + 1)
                {
                    Console.Write("|");
                }
            }
        }

        private void DrawHanoi(int n, Tower towerA, Tower towerB, Tower towerC)
        {
            for (int i = 0; i < n; i++)
            {
                DrawOneDisk(n, towerA.disks[i]);
                DrawOneDisk(n, towerB.disks[i]);
                DrawOneDisk(n, towerC.disks[i]);
                Console.WriteLine("");
            }
        }
        private void MoveDisk(int n, int disk, Tower from, Tower via, Tower to, Tower towerA, Tower towerB, Tower towerC)
        {
            if (n == 1)
            {
                to.InsertDisk(from.RemoveDisk());
                move++;
                Console.WriteLine(move);
                DrawHanoi(disk, towerA, towerB, towerC);
            }
            else
            {
                MoveDisk(n - 1, disk, from, to, via, towerA, towerB, towerC);
                to.InsertDisk(from.RemoveDisk());
                move++;
                Console.WriteLine(move);
                DrawHanoi(disk, towerA, towerB, towerC);
                MoveDisk(n - 1, disk, via, from, to, towerA, towerB, towerC);
            }
        }
    }
    public class HanoiProgram
    {
        static void Main(string[] args)
        {
            Console.Write("원판의 갯수 : ");
            int n = Convert.ToInt32(Console.ReadLine());
            Hanoi hanoi = new Hanoi(n);
            hanoi.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _2_programa
{
    class Program
    {
        static List<FriendsPresents> var = new List<FriendsPresents>();
        static int operationsCount = 0;
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            int[] presentsPrice = { 10, 20, 40, 11, 5, 6, 119, 54, 25, 65, 77, 88, 215, 456, 200, 69, 41, 56, 12, 4, 898, 444, 11 };
            List<int> frA = new List<int>();
            List<int> frB = new List<int>();
            int k = 0;
            FriendsPresents all = new FriendsPresents(presentsPrice, frA, frB, k);
            timer.Start();
            Split(all, presentsPrice.Length, -1);
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            timer.Reset();
            List<string> seq = Sequences();
            Console.WriteLine("Operacijų kiekis: " + operationsCount);
            Console.WriteLine("Dinaminis programavimas užtruko: " + time);
            Console.WriteLine("Atlikta");
        }
        public static void Split(FriendsPresents presents, int n, int m)
        {
            operationsCount++;
            FriendsPresents frA = presents.Give(n, m);
            FriendsPresents frB = frA.CloneFriendA();
            Share(frA, n - 1, 0);
            Share(frB, n - 1, 1);
        }
        public static void Share(FriendsPresents presents, int n, int m)
        {
            if (n == 0)
            {
                presents.Give(n, m);
                var.Add(presents);
                return;
            }
            Split(presents, n, m);
        }
        public static List<string> Sequences()
        {
            List<string> seq = new List<string>();
            int ind = GetMinIndexes();
            for (int i = 0; i < var.Count; i++)
            {
                if (var[i].getSubstraction() == var[ind].getSubstraction())
                {
                    seq.Add(var[i].subSeq(i));                
                }
                if((var[i].getSubstraction() == var[ind].getSubstraction()) && var[ind].getSubstraction() > 0)
                {
                    seq.Add(var[i].subSeqq(i));
                }
            }
            Console.WriteLine("Mažiausia reikšmė: " + Math.Abs(var[GetMinIndexes()].getSubstraction()));
            foreach (string item in seq)
            {
                Console.WriteLine(item);
            }
            return seq;
        }
        public static int GetMinIndexes()
        {
            int min = var[0].getSubstraction();
            int ind = 0;
            for (int i = 0; i < var.Count; i++)
            {
                if (Math.Abs(var[i].getSubstraction()) < min)
                {
                    min = Math.Abs(var[i].getSubstraction());
                    ind = i;
                }
            }
            return ind;
        }
    }
}

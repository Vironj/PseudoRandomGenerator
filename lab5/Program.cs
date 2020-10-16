using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int[] mass = new int[1000];
            for(int i = 0; i < 1000; i++)
            {
                mass[i] = PseudoRandom.next();
            }
            TimeSpan ts1 = stopWatch.Elapsed;
            string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts1.Hours, ts1.Minutes, ts1.Seconds, ts1.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime1);
        }
    }
    class PseudoRandom
    {
        private static long multiplier = 0x5DEECE66DL;
        private static long addend = 0xBL;
        private static long mask = (1L << 48) - 1;
        private static long seedUniquifier = 8682522807148012L;

        private static long SeedUniquifier()
        {
            long current = seedUniquifier;
            long next = current * 1181783497276652981L;
            return next;
        }
        private static long oldseed = SeedUniquifier() ^ nanoTime();
        public static int next()
        {
            long nextseed;
            nextseed = (oldseed * multiplier + addend) & mask;
            oldseed = nextseed;
            return (int)(nextseed >> (16));
        }
        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
    }
}
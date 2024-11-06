using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class Speed
{
    static public double[] SpeedOfSortingInt(int length, params Func<int[], int[]>[] SortMethods)
    {
        double[] sum = new double[SortMethods.Length];
        for (int i = 0; i < 20; i++)
        {
            int[] array = Generate.Int(length);
            try
            {
                int[] sortedArray = null;
                int index = 0;
                foreach (Func<int[], int[]> Method in SortMethods)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    sortedArray = Method((int[])array.Clone());
                    timer.Stop();
                    sum[index] += timer.ElapsedMilliseconds;
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            };
        }

        return sum;
    }

    static public double[] SpeedOfSortingDouble(int length, params Func<double[], double[]>[] SortMethods)
    {
        double[] sum = new double[SortMethods.Length];
        for (int i = 0; i < 20; i++)
        {
            double[] array = Generate.Double(length);
            try
            {
                double[] sortedArray = null;
                int index = 0;
                foreach (Func<double[], double[]> Method in SortMethods)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    sortedArray = Method((double[])array.Clone());
                    timer.Stop();
                    sum[index] += timer.ElapsedMilliseconds;
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            };
        }

        return sum;
    }

    static public double[] SpeedOfSortingChar(int length, params Func<char[], char[]>[] SortMethods)
    {
        double[] sum = new double[SortMethods.Length];
        for (int i = 0; i < 20; i++)
        {
            char[] array = Generate.Char(length);
            try
            {
                char[] sortedArray = null;
                int index = 0;
                foreach (Func<char[], char[]> Method in SortMethods)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    sortedArray = Method((char[])array.Clone());
                    timer.Stop();
                    sum[index] += timer.ElapsedMilliseconds;
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            };
        }

        return sum;
    }

    static public double[] SpeedOfSortingString(int length, params Func<string[], string[]>[] SortMethods)
    {
        double[] sum = new double[SortMethods.Length];
        for (int i = 0; i < 20; i++)
        {
            string[] array = Generate.String(length);
            try
            {
                string[] sortedArray = null;
                int index = 0;
                foreach (Func<string[], string[]> Method in SortMethods)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    sortedArray = Method((string[])array.Clone());
                    timer.Stop();
                    sum[index] += timer.ElapsedMilliseconds;
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            };
        }

        return sum;
    }
}

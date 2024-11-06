using System;

internal static class Generate
{
    public static int[] Int(int length)
    {
        int[] array = new int[length];
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(0, 1000);
        }
        return array;
    }
    public static double[] Double(int length)
    {
        double[] array = new double[length];
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            array[i] = (double)random.Next(1, 100) / 100;
        }
        return array;
    }

    public static char[] Char(int length)
    {
        char[] array = new char[length];
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            array[i] = (char)random.Next(1, 100);
        }
        return array;
    }

    public static string[] String(int length)
    {
        string[] array = new string[length];
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            string result = "";
            int size = random.Next(1, 10);
            for (int j = 0; j < size; j++) result += chars[random.Next(0, chars.Length)];
            array[i] = result;
        }
        return array;
    }
}

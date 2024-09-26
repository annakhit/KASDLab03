using System;

internal static class Generate
{
    public static int[] Random(int length)
    {
        int[] array = new int[length];
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(0, 1000);
        }
        return array;
    }
    public static double[] RandomDouble(int length)
    {
        double[] array = new double[length];
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            array[i] = (double)random.Next(1, 100) / 100;
        }
        return array;
    }
    public static int[] ArrayOfArrays(int size)
    {
        Random random = new Random();
        int length = Convert.ToString(size).Length;
        int[] array = new int[size];
        int offset = 0;

        while (size > 0)
        {
            int amount = (int)Math.Pow(10, random.Next(1, length));

            int mul = random.Next(1, 1000);

            for (int index = 0; index < amount; index++)
            {
                array[index + offset] = mul * (index + 1);
            }

            offset += amount;
            size -= amount;
            length = Convert.ToString(size).Length;
        }

        return array;
    }

    public static int[] ArraySwap(int length)
    {
        int[] array = new int[length];
        for (int i = 0; i < length; i++) array[i] = i;

        Random random = new Random();
        int countOfSwap = random.Next(0, length / 4);
        for (int i = 0; i < countOfSwap; i++)
        {
            int firstIndex = random.Next(0, array.Length - 1);
            int secondIndex = random.Next(0, array.Length - 1);
            (array[secondIndex], array[firstIndex]) = (array[firstIndex], array[secondIndex]);
        }
        return array;
    }

    public static int[] ArrayRepeat(int length, int percent)
    {
        Random random = new Random();
        int value = random.Next(1, 10000);
        int[] array = new int[length];
        for (int i = 0; i < length; i++) array[i] = random.Next(0, 100) <= percent ? value : i; //рандом в среднем выбирает разные числа 
        return array;
    }
}

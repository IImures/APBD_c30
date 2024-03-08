
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine(GetMax([1,2,3,4,5,6,7,8,9,10]));
Console.WriteLine(GetAvg([1,2,3,4,5,6,7,8,9,10]));

static double GetAvg(int[] arr)
{
    int sum = 0;
    foreach (var num in arr)
    {
        sum += num;
    }

    return (double)sum / arr.Length;
}

static int GetMax(int[] arr)
{
    int max = 0;
    foreach (var num in arr)
    {
        if (num > max)
        {
            // Modifying from main branch
            //My comment
            max = num;
        }
    }

    return max;
}
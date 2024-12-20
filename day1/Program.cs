﻿class Program
{
    static void Main()
    {
        string filepath = "input.txt";
        List<int> list1 = new();
        List<int> list2 = new();

        foreach (var line in File.ReadAllLines(filepath))
        {
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        }

        list1.Sort();
        list2.Sort();

        int totalDiff = 0;

        //Switch these two for(each) loops out with each other for the awnser for task 1 or 2
        //for (int i = 0; i < list1.Count; i++)
        //{
        //    int diff = Math.Abs(list1[i] - list2[i]);

        //    totalDiff += (int)Math.Ceiling((double)diff);
        //}

        foreach (int num in list1)
        {
            int count = list2.Count(x => x == num);

            totalDiff += (int)Math.Ceiling((double)(num * count));
        }

        Console.WriteLine(totalDiff);

    }
}
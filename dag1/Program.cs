class Program
{
    static void Main()
    {
        string filepath = "input.txt";
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();


        foreach (var line in File.ReadAllLines(filepath))
        {
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            _ = int.TryParse(parts[0], out int first);
            _ = int.TryParse(parts[1], out int second);

            list1.Add(first);
            list2.Add(second);
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
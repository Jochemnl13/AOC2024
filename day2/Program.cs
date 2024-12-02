using System.Collections.Generic;

namespace day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = "input.txt";
            int numberSafe = 0;

            foreach (var line in File.ReadAllLines(filepath))
            {
                var numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                if (IsSafe(numbers))
                {
                    numberSafe++;
                    continue;
                }

                //Remove this loop to get the awnser for task 1
                for (int i = 0; i < numbers.Count; i++)
                {
                    var tinierList = numbers.Where((_, index) => index != i).ToList();
                    if (IsSafe(tinierList))
                    {
                        numberSafe++;
                        break;
                    }
                }
            }

            Console.WriteLine(numberSafe);
        }

        static bool IsSafe(List<int> numbers)
        {
            bool isIncreasing = numbers[1] > numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                int diff = numbers[i] - numbers[i-1];

                if (isIncreasing && (diff < 1 || diff > 3)) return false;
                if (!isIncreasing && (diff > -1 || diff < -3)) return false;
                if ((isIncreasing && diff < 0) || (!isIncreasing && diff > 0)) return false;
            }

            return true;
        }
    }
}
namespace Task01.Drills
{
    public class Drill05_MaximumAndMinimumFinder
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("-------------Maximum and Minimum Finder----------------");

            bool isParsed;
            List<int> Numbers = new List<int>();
            int num;
            do
            {
                Numbers.Clear();
                isParsed = true;
                Console.Write("Enter numbers separated by commas: ");
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    System.Console.WriteLine("Please Enter At Least One Number");
                    isParsed = false;
                    continue;
                }
                string[] splittedInput = input.Split(',');
                foreach (var item in splittedInput)
                {
                    isParsed = int.TryParse(item.Trim(), out num);
                    if (isParsed)
                    {
                        Numbers.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid Integers ");
                        break;
                    }
                }
            } while (!isParsed);

            int max = Numbers[0];
            int min = Numbers[0];
            for (int i = 1; i < Numbers.Count; i++)
            {
                if (Numbers[i] > max)
                    max = Numbers[i];
                if (Numbers[i] < min)
                    min = Numbers[i];
            }
            Console.WriteLine($"Max: {max} | Min:{min}");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
namespace Task01.Drills
{
    public class Drill11_DuplicateNumberDetector
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("-------------Duplicate Number Detector----------------");

            bool isParsed;
            List<int> Numbers = new List<int>();
            int num;
            do
            {
                Numbers.Clear();
                isParsed = true;
                Console.Write("Enter list of integers separated by commas: ");
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    System.Console.WriteLine("list Can not be Empty");
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
            HashSet<int>Seen = new ();
            HashSet<int>duplicates = new ();
            foreach (var item in Numbers)
            {
                if(Seen.Contains(item))
                {
                    duplicates.Add(item);

                }
                else
                {
                    Seen.Add(item);
                }
            }
            if (duplicates.Any())
            {
                Console.WriteLine($"Duplicates: {string.Join(", ",duplicates)}");
            }
             
            else
            {
                 Console.WriteLine("No duplicates found"); 
            }
        Console.WriteLine("-----------------------------------------------------------");    
        }
    }
}
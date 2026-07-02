namespace Task01.Drills
{
    public class Drill04_EvenOddAnalyzer
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Even/Odd Analyzer-----------");

            bool isParsed;
            int Count;
            do
            {
                Console.WriteLine("How Many Numbers Will be entered ? :");
                isParsed = int.TryParse(Console.ReadLine(), out Count);

                if (!isParsed)
                    Console.WriteLine("Please Enter a Valid Number");
                else if (Count <= 0)
                    Console.WriteLine("The Count Must be Positive");
            } while (!isParsed || Count <= 0);

            List<int> even = new List<int>();
            List<int> odd = new List<int>();
            int num;
            for (int i = 0; i < Count; i++)
            {
                do
                {
                    Console.Write($"Enter Number {i + 1}: ");
                    isParsed = int.TryParse(Console.ReadLine(), out num);
                    if (!isParsed)
                    {
                        Console.WriteLine("Invalid Number");
                    }
                } while (!isParsed);
                if (num % 2 == 0)
                    even.Add(num);
                else
                    odd.Add(num);
            }
            Console.WriteLine();
            Console.Write($"Even: {string.Join(", ", even)}");
            Console.Write($" | Odd: {string.Join(", ", odd)}");

            Console.WriteLine("");
            Console.WriteLine($"Even Count: {even.Count}");
            Console.WriteLine($"Odd Count: {odd.Count}");
            Console.WriteLine("---------------------------------------------------");




        }
    }
}
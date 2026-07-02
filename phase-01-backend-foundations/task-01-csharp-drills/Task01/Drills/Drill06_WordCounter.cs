namespace Task01.Drills
{
    public class Drill06_WordCounter
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Word Counter-----------");
            bool valid;
            string? input;
            do
            {
                valid = true;
                Console.WriteLine("Enter Sentence: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    valid = false;
                    Console.WriteLine("Sentence cannot be empty.");
                }

            } while (!valid);
            input = input!.Trim();
            string[] splittedInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Word count: {splittedInput.Length}");
            Console.WriteLine("-------------------------------------------------");


        }
    }
}
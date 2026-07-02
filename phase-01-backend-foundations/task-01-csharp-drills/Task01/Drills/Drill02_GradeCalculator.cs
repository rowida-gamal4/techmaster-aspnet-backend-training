namespace Task01.Drills
{
    public class Drill02_GradeCalculator
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Grade Calculator-----------");
            bool isParsed;
            int score;
            do
            {
                Console.WriteLine("Enter a Score from 0 to 100");
                isParsed = int.TryParse(Console.ReadLine(), out score);
                if (!isParsed)
                    Console.WriteLine("Invalid Please Enter a Number");
                if (score < 0 || score > 100)
                    Console.WriteLine("Score must be between 0 and 100");
            } while (!isParsed || score < 0 || score > 100);
            string Grade;
            if (score >= 90)
                Grade = "A";
            else if (score >= 80)
                Grade = "B";
            else if (score >= 70)
                Grade = "C";
            else if (score >= 60)
                Grade = "D";
            else
                Grade = "F";
            Console.WriteLine($"Grade: {Grade}");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
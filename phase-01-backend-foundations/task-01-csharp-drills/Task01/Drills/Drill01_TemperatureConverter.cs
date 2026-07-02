namespace Task01.Drills
{
    public class Drill01_TemperatureConverter
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Temperature Converter-----------");
            bool isParsed;
            double celsiusValue;
            do
            {
                Console.WriteLine("Enter a Celsius Value Temperature");
                isParsed = double.TryParse(Console.ReadLine(), out celsiusValue);
                if (!isParsed)
                {
                    Console.WriteLine("Invalid temperature value.");
                }
            } while (!isParsed);
            double fahrenheitValue = (celsiusValue * 9 / 5) + 32;
            Console.WriteLine($"{celsiusValue}'C = {fahrenheitValue:F2}'F");
            Console.WriteLine("--------------------------------------");
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Name
{
    public class Drill18_NumberStatistics
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("-------------Number Statistics----------------");

            // Read and validate the number of elements (Count)
            bool isParsed;
            int count;
            do
            {
                Console.Write("Enter list size: ");
                isParsed = int.TryParse(Console.ReadLine(), out count);

                if (!isParsed)
                    Console.WriteLine("Enter a valid integer.");
                else if (count <= 0)
                    Console.WriteLine("list size must be > 0");
                // Ensure that list size is greater than zero   
            } while (!isParsed || count <= 0);

            List<int> numbers = new();
            int num;

            for (int i = 0; i < count; i++)
            {
                // loop throug count to read list from the user 
                do
                {
                    Console.Write($"Enter element {i + 1}: ");
                    isParsed = int.TryParse(Console.ReadLine(), out num);
                    // validate each number is a valid integer    

                    if (!isParsed)
                        Console.WriteLine("Enter a valid integer ");

                } while (!isParsed);

                // store each number in the list   
                numbers.Add(num);
            }
            // Initialize accumulators
            int sum = 0;
            decimal avg = 0;
            int positiveCount = 0;
            int negativeCount = 0;
            int totalCount = 0;
            int max = numbers[0];
            int min = numbers[0];


            //Calculate the required statistics
            foreach (var item in numbers)
            {
                sum += item;
                if (item >= 0)
                {
                    positiveCount++;
                }
                else
                {
                    negativeCount++;
                }
                if (item > max)
                {
                    max = item;
                }
                if (item < min)
                {
                    min = item;
                }


            }
            //Calculate the total count 
            totalCount = numbers.Count;
            //Calculate the average.
            avg = (decimal)sum / totalCount;

            //Print the final results.
            System.Console.WriteLine($"Count: {totalCount}, Sum: {sum}, Average: {avg}, Positive: {positiveCount}, Negative: {negativeCount}, Max: {max}, Min:{min}");
        }
    }
}
/*
Approach :
- Read and validate the number of elements.
- Read each number from the user and store it in a list.
- Initialize accumulators used to calculate statistics.
- Loop through the list to calculate the sum, count positive ,negative numbers ,maximum and minimum values.
- Calculate the average using the total sum and number count.
- Display all calculated statistics.
*/
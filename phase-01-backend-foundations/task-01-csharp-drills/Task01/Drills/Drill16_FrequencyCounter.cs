namespace Task01
{
   public class Drill16_FrequencyCounter
   {
      public void Run()
      {
         Console.Clear();
         Console.WriteLine("-------------Array Rotation----------------");

         //1-Read and validate the number of elements (Count)
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
            //2- Ensure that list size is greater than zero   
         } while (!isParsed || count <= 0);

         List<int> numbers = new();
         int num;

         for (int i = 0; i < count; i++)
         {
            //3- loop throug count to read list from the user 
            do
            {
               Console.Write($"Enter element {i + 1}: ");
               isParsed = int.TryParse(Console.ReadLine(), out num);
               //4- validate each number is a valid integer    

               if (!isParsed)
                  Console.WriteLine("Enter a valid integer ");

            } while (!isParsed);

            //5- store each number in the list   
            numbers.Add(num);
         }

         Dictionary<int, int> freq = new();
         //6-Count the frequency of each number.
         for (int i = 0; i < numbers.Count; i++)
         {
            //7 - chcek if number exists   
            if (freq.ContainsKey(numbers[i]))
               freq[numbers[i]]++;
            //8 -increase its count if number exist  
            else
               freq.Add(numbers[i], 1);
            //9- Add number if not exist with initial count 1

         }
         //10 - printing list of count
         foreach (var item in freq)
         {
            Console.WriteLine($"{item.Key} => {item.Value}");
         }
      }
   }
}
/*
Approach :
- Read and validate the list size.
- Read all numbers from the user and store them in a list.
- Count how many times each number appears using a dictionary.
- If a number already exists, increment its frequency.
- If not exists add it with a count of 1.
- Print each number with its frequency.
*/
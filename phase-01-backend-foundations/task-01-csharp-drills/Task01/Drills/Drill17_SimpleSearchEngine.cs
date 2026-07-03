namespace Task01.Drills
{
    public class Drill17_SimpleSearchEngine
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Simple Search Engine----------");

            //Create list of names to search 
            List<string> names = new()
            {
                "Ali Hassan",
                "Khaled ali",
                "Sara Ali",
                "Arwa Mahmoud",
                "Nour Ali"
            };
            string? keyword;
            // Read and validate the search keyword
            do
            {
                Console.Write("Enter keyword to search: ");
                keyword = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    Console.WriteLine("Keyword can not be empty.");
                }

            } while (string.IsNullOrWhiteSpace(keyword));
            // Search keyword with case insensitive
            List<string> results = names.Where(name => name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            if (results.Any())
            {
                // print Matching Names 
                Console.WriteLine("\nMatching names:");

                foreach (string name in results)
                {
                    Console.WriteLine(name);
                }
            }
            else
            {
                //Print No result founf it no matching names 
                Console.WriteLine("No results found");
            }

            Console.WriteLine("-------------------------------------------------");
        }
    }
}
/*
Approach :
-Create list of names to search 
-Read and validate the keyword.
-Make a case-insensitive search using where 
-Display the results.
*/
namespace Task01.Drills
{
    public class Drill07_NameFormatter
    {

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Name Formatter-----------");
            bool valid;
            string? name;
            do
            {
                valid = true;
                Console.WriteLine("Enter Full Name: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    valid = false;
                    Console.WriteLine("Name cannot be empty.");
                }

            } while (!valid);
            name = name!.Trim();
            string[] splittedName = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splittedName.Length; i++)
            {
                splittedName[i] = splittedName[i].ToLower();
                splittedName[i] = char.ToUpper(splittedName[i][0]) + splittedName[i].Substring(1);
            }
            string formattedName = string.Join(" ", splittedName);
            Console.WriteLine($"Name: {formattedName}");

            Console.WriteLine("-------------------------------------------------");


        }
    }
}
namespace Task01.Drills
{
    public class Drill13_PalindromeChecker
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Palindrome Checker-----------");
            bool valid;
            string? text;
            do
            {
                valid = true;
                Console.WriteLine("Enter text: ");
                text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text))
                {
                    valid = false;
                    Console.WriteLine("Text cannot be empty.");
                }

            } while (!valid);
            text = text!.Trim().ToLower().Replace(" ", "");
            string reversed = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversed += text[i];
            }
            if (text == reversed)
            {
                Console.WriteLine("Palindrome");
            }
            else
            {
                Console.WriteLine("Not Palindrome");
            }

            Console.WriteLine("-------------------------------------------------");
        }
    }

}

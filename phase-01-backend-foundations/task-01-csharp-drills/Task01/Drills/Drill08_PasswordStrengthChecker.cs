namespace Task01.Drills
{
    public class Drill08_PasswordStrengthChecker
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Password Strength Checker-----------");




            string? password;
            do
            {

                Console.WriteLine("Enter Password");
                password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Password cannot be empty.");
                }

            } while (string.IsNullOrWhiteSpace(password));



            bool isUppercase = false;
            bool isValidLength = false;
            bool isLowercase = false;
            bool isDigit = false;
            bool isSpecialChar = false;

            if (password!.Length >= 8)
                isValidLength = true;
            foreach (var item in password)
            {

                if (char.IsUpper(item))
                    isUppercase = true;
                if (char.IsLower(item))
                    isLowercase = true;
                if (char.IsDigit(item))
                    isDigit = true;
                if (!char.IsLetter(item) && !char.IsDigit(item))
                    isSpecialChar = true;
            }
            List<string> missingRules = new List<string>();

            if (isUppercase && isLowercase && isValidLength && isDigit && isSpecialChar)
                Console.WriteLine("Strong");
            else
            {
                if (!isValidLength)
                    missingRules.Add("length");
                if (!isUppercase)
                    missingRules.Add("uppercase");

                if (!isLowercase)
                    missingRules.Add("lowercase");

                if (!isDigit)
                    missingRules.Add("digit");

                if (!isSpecialChar)
                    missingRules.Add("special character");
                Console.WriteLine($"Weak - missing {string.Join(", ", missingRules)}");

            }

            Console.WriteLine("-------------------------------------------------");
        }
    }
}
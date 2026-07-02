namespace Task01.Drills
{
    public class Drill03_SimpleLoginValidator
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Simple Login Validator-----------");

            const string UserName = "Admin";
            const string Password = "1234";
            int attempts = 3;



            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter User Name : ");
                string inputUserName = Console.ReadLine();
                bool nameEqual = string.Equals(UserName, inputUserName, StringComparison.OrdinalIgnoreCase);
                Console.Write("Enter Password : ");
                string inputPassword = Console.ReadLine();
                bool passwordEqual = Password == inputPassword;
                if (nameEqual && passwordEqual)
                {
                    Console.WriteLine("Login successful.");
                    Console.WriteLine("-------------------------------------------");
                    return;
                }
                else
                {
                    attempts--;
                    Console.WriteLine("Wrong UserName Or Password");
                    Console.WriteLine($"{attempts} Attempts Left");

                }


            }
            if (attempts == 0)
            {
                Console.WriteLine("Account locked. Too many failed attempts.");
            }
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
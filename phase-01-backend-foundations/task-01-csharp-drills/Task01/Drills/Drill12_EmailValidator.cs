using System.Reflection.Metadata;

namespace Task01.Drills
{
    public class Drill12_EmailValidator
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Email Validator-----------");




            string? email;
            do
            {

                Console.WriteLine("Enter Email");
                email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Email can not be empty.");
                }

            } while (string.IsNullOrWhiteSpace(email));



            bool containDot = false;
            bool containAt = false;
            bool startwithAt = false;
            bool endWithAt = false;
            bool containSpaces = false;
            bool multipleAt = false;
            int atCount;

            atCount = email.Count(c => c == '@');

            if (email.Contains('@'))
                containAt = true;
            if (atCount > 1)
                multipleAt = true;
            if (email.Contains('.'))
                containDot = true;
            if (email.Contains(" "))
                containSpaces = true;
            if (email.StartsWith("@"))
                startwithAt = true;
            if (email.EndsWith("@"))
                endWithAt = true;





            if (containDot && containAt && !startwithAt && !endWithAt && !containSpaces && !multipleAt)
                Console.WriteLine("Valid email");
            else
            {
                Console.WriteLine("Invalid email :");
                if (!containDot)
                {
                    Console.WriteLine(" you require dot");
                }
                if (!containAt)
                {
                    Console.WriteLine(" you require @");
                }
                if (startwithAt)
                    Console.WriteLine(" can not start with @");

                if (endWithAt)
                    Console.WriteLine(" can not end with @");

                if (containSpaces)
                    Console.WriteLine(" can not contain spaces");

                if (multipleAt)
                    Console.WriteLine(" can not contain more than one @");

            }

            Console.WriteLine("-------------------------------------------------");
        }
    }
}
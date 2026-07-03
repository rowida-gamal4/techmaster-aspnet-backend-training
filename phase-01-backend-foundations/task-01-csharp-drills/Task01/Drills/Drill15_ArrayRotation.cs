namespace Task01.Drills
{
    public class Drill15_ArrayRotation
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("-------------Array Rotation----------------");

            bool isParsed;
            int count;
            do
            {
                Console.Write("Enter array size: ");
                isParsed = int.TryParse(Console.ReadLine(), out count);

                if (!isParsed)
                    Console.WriteLine("Enter a valid number.");
                else if (count <= 0)
                    Console.WriteLine("Array size must be > 0");

            } while (!isParsed || count <= 0);

            int[] arr = new int[count];

            for (int i = 0; i < count; i++)
            {
                do
                {
                    Console.Write($"Enter element {i + 1}: ");
                    isParsed = int.TryParse(Console.ReadLine(), out arr[i]);

                    if (!isParsed)
                        Console.WriteLine("Enter a valid integer ");

                } while (!isParsed);
            }

            if (arr.Length > 1)
            {
                int temp = arr[arr.Length - 1];
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[0] = temp;
            }
            Console.WriteLine($"Rotated Array: [{string.Join(", ", arr)}]");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}

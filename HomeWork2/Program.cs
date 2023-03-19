namespace HomeWork2
{
    internal class Program
    {
        static void Main ()
        {
            int length = InputHandler.HandleLengthInput();
            int[] numbers = InputHandler.HandleNumbersInput(length);
            WritePreMaxValue(numbers);
        }

        static void WritePreMaxValue (int[] numbers)
        {
            Array.Sort(numbers);
            int max = numbers[numbers.Length - 1];
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] < max)
                {
                    Console.WriteLine($"Второе наибольшее число в массиве: {numbers[i]}");
                    return;
                }
            }
            Console.WriteLine("Массив, состоящий только из равных чисел, не имет второго большего числа.");
        }
    }
}
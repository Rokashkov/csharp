using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    internal class InputHandler
    {
        public static int HandleLengthInput()
        {
            try
            {
                Console.Write("Введите длину массива: ");
                return Validator.ValidateLengthInput(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return HandleLengthInput();
            }

        }

        public static int[] HandleNumbersInput(int length)
        {
            int[] numbers = new int[length];
            for (int i = 0; i < length; i++)
            {
                int number = HandleNumberInput(i);
                numbers[i] = number;
            }
            return numbers;
        }

        public static int HandleNumberInput(int index)
        {
            try
            {
                Console.Write($"Введите int[{ index }]: ");
                return Validator.ValidateNumberInput(Console.ReadLine(), index);
            }
            catch (NumberException ex)
            {
                Console.WriteLine(ex.Message);
                return HandleNumberInput(index);
            }

        }
    }
}

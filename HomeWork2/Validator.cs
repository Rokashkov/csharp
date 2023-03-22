using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    internal class Validator
    {
        public static int ValidateLengthInput (string input)
        {
            try
            {
                if (input == "")
                {
                    throw (new Exception("Пустое значение для длины массива недопустимо."));
                }
                int length = Int32.Parse(input);
                if (length == 0)
                {
                    throw (new Exception("Нулевое значение для длины массива недопустимо."));
                }
                else if (length < 0)
                {
                    throw (new Exception("Отрицательное значение для длины массива недопустимо."));
                }
                else if (length == 1)
                {
                    throw (new Exception("Массив не может иметь только один элемент."));
                }

                return length;
            }
            catch (FormatException ex)
            {
                throw new Exception("Недопустимое значение для длины массива.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int ValidateNumberInput(string input, int index)
        {
            try
            {
                return Int32.Parse(input);
            }
            catch (FormatException ex)
            {
                throw new NumberException("Недопустимое значение для элемента массива.", index);
            }
        }
    }
}

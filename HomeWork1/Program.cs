namespace HomeWork1
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Как вас зовут?");
                Console.Write("Введите ваше имя: ");
                string input = Console.ReadLine()!;
                if (input == "" || input == "Владимир")
                {
                    throw new Exception(input);
                }
                else
                {
                    Console.WriteLine($"Здравствуйте, {input}!");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Я уверен, что имени \"{ex.Message}\" не существует... Попробуем заново.");
                Main();
            }
        }
    }
}
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace HomeWork5
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Handler.Handle(() => {
                //Различные переменные

                var currentDirectory = Directory.GetCurrentDirectory();
                var zipFilePath = Path.Combine(currentDirectory, "example.zip");
                var targetDirectoryPath = Path.Combine(currentDirectory, "example");
                var appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var txtFilePath = Path.Combine(appDataFolderPath, "Lesson5Homework.txt");

                //Чтения пути до файла записей

                string csvFilePath;

                using (StreamReader stream = new StreamReader(txtFilePath, true))
                {
                    csvFilePath = stream.ReadLine();
                }

                //Чтение записей

                string text;

                using (StreamReader stream = new StreamReader(csvFilePath, true))
                {
                    text = stream.ReadToEnd();
                }

                var records = Parser.ParseTextToRecords(text);

                //Сортировка записей под дате

                var sortedRecords = from record in records
                                    orderby record.UpdatedAt
                                    select record;

                //Выведение записей

                foreach (var record in sortedRecords)
                {
                    Console.WriteLine(Parser.ConvertRecordToString(record));
                }

                //Удаление файла записей

                File.Delete(txtFilePath);
            });
        }
    }
}
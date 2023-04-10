using System.IO;
using System.IO.Compression;
using System.Security;
using System.Xml.Linq;

namespace HomeWork5
{
    internal class Program1
    {
        static void Main1(string[] args)
        {
            Handler.Handle(() =>
            {
                //Различные переменные

                var currentDirectory = Directory.GetCurrentDirectory();
                var zipFilePath = Path.Combine(currentDirectory, "example.zip");
                var targetDirectoryPath = Path.Combine(currentDirectory, "example");
                var csvFilePath = Path.Combine(currentDirectory, "records.csv");
                var appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var txtFilePath = Path.Combine(appDataFolderPath, "Lesson5Homework.txt");

                //Разархивирование

                ZipFile.ExtractToDirectory(zipFilePath, targetDirectoryPath);

                //Запись

                var records = Parser.ParseDirectoryToStrings(targetDirectoryPath);

                using (StreamWriter stream = new StreamWriter(csvFilePath, true))
                {
                    foreach (var record in records)
                    {
                        stream.WriteLine(record);
                    }
                }

                //Удаление папки

                Directory.Delete(targetDirectoryPath, true);

                //Запись в AppData

                using (StreamWriter stream = new StreamWriter(txtFilePath, false))
                {
                    stream.WriteLine(csvFilePath);
                }
            });
        }
    }
}
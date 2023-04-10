using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    internal class Parser
    {
        public static List<Record> ParseDirectoryToRecords(string dirPath)
        {
            /*
                Хотел сделать здесь рекурсивный метод, чтобы парсить вложенные папки,
                но не смог решить, какой возвращаемый тип указать.
                List<Record || List<Record || и т.д>>, но как это записать?
                Да и в List не могут храниться разные типы данных.
                В итоге просто реализовал парсинг директории.
            */

            var records = new List<Record>();

            var dirs = Directory.GetDirectories(dirPath);

            foreach (var dir in dirs)
            {
                records.Add(ConvertPathToRecord(dir));
            }

            var files = Directory.GetFiles(dirPath);
            
            foreach (var file in files)
            {
                records.Add(ConvertPathToRecord(file));
            }

            return records;
        }

        public static List<string> ParseDirectoryToStrings(string dirPath)
        {
            var records = new List<string>();

            var dirs = Directory.GetDirectories(dirPath);

            foreach (var dir in dirs)
            {
                records.Add(ConvertPathToString(dir));
            }

            var files = Directory.GetFiles(dirPath);

            foreach (var file in files)
            {
                records.Add(ConvertPathToString(file));
            }

            return records;
        }

        public static Record ConvertPathToRecord(string path)
        {
            string ext;
            string name;
            DateTime updatedAt;

            if (File.Exists(path))
            {
                ext = Path.GetExtension(path);
            }
            else if (Directory.Exists(path))
            {
                ext = "folder";
            }
            else
            {
                throw new FileNotFoundException();
            }

            name = Path.GetFileName(path);
            updatedAt = Directory.GetLastWriteTime(path);

            var record = new Record(ext, name, updatedAt);    

            return record;
        }

        public static string ConvertPathToString(string path)
        {
            string ext;
            string name;
            DateTime updatedAt;

            if (File.Exists(path))
            {
                ext = Path.GetExtension(path);
            }
            else if (Directory.Exists(path))
            {
                ext = "folder";
            }
            else
            {
                throw new FileNotFoundException();
            }

            name = Path.GetFileName(path);
            updatedAt = Directory.GetLastWriteTime(path);

            var value = ext + "\t" + name + "\t" + updatedAt;

            return value;
        }

        public static Record ConvertStringToRecord(string value)
        {
            var values = value.Trim().Split("\t");

            if (values.Length != 3)
            {
                throw new ArgumentException("Неверный формат записи о файле");
            }
            if (values[0] == "")
            {
                throw new ArgumentException("Неверный формат записи о файле");
            }
            else if (values[2] == "")
            {
                throw new ArgumentException("Неверный формат записи о файле");
            }

            try
            {
                DateTime.Parse(values[2]);
            }
            catch
            {
                throw new ArgumentException("Неверный формат записи о файле");
            }

            var record = new Record(values[0], values[1], DateTime.Parse(values[2]));

            return record;
        }

        public static string ConvertRecordToString(Record record)
        {
            var value = record.Ext + "\t" + record.Name + "\t" + record.UpdatedAt;

            return value;
        }

        public static List<Record> ParseTextToRecords(string text)
        {
            var values = text.Split("\n");
            values = values.Where(s => s.Trim().Length > 0).ToArray();

            List<Record> records = new List<Record>();

            foreach (var value in values)
            {
                records.Add(ConvertStringToRecord(value));
            }

            return records;
        }
    }
}

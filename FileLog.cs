using System;
using System.IO;


namespace Lab1
{
    class FileLog
    {
        private const string c_LogFilePath = "logs.txt";

        public static void ToFile(string text)
        {
            File.AppendAllText(c_LogFilePath, text + "\n");
        }

        public static void PathCheck() // проверка существования файла по указанному пути
        {
            string text;
            Logger logger = new Logger();

            try
            {
                StreamReader streamReader = new StreamReader(c_LogFilePath);
            }
            catch (NullReferenceException ex)
            {
                text = "Не найден файл для хранения логов: ";
                logger.Error(text + ex.Message);
                throw ex;
            }
        }
    }
}

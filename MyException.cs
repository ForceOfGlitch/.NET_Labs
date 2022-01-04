using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class InvalidConfigFileException : Exception
    {
        string exMessage = "Некорректно введены данные в файл конфигурации";

        public string GetExMessage() // метод получения сообщения ошибки
        {
            return exMessage;
        }
        public InvalidConfigFileException(string message) : base(message) // конструктор класса ошибки
        {
            exMessage = message;
        }
    }
}

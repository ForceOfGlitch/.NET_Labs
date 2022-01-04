using System;

namespace Lab1
{
    class Logger
    {
        public event Action<string> SomeEvent;

        public Logger()
        {
            SomeEvent += FileLog.ToFile;
            SomeEvent += ConsoleLog.ToConsole;
        }
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            SomeEvent?.Invoke($"(INFO) {message} {DateTime.Now}");
            Console.ResetColor();
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            SomeEvent?.Invoke($"(ERROR) {message} {DateTime.Now}");
            Console.ResetColor();
        }

        public void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            SomeEvent?.Invoke($"(WARNING) {message} {DateTime.Now}");
            Console.ResetColor();
        }
    }
}

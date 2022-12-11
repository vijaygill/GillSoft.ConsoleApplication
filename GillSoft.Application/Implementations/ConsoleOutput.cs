using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application.Implementations
{
    internal class ConsoleOutput : IOutput
    {
        public void WriteError(string message)
        {
            WriteLine(message, ConsoleColor.Red, Console.BackgroundColor);
        }

        public void WriteLine(string message)
        {
            WriteLine(message, ConsoleColor.Gray, Console.BackgroundColor);
        }

        public void WriteWarning(string message)
        {
            WriteLine(message, ConsoleColor.Yellow, Console.BackgroundColor);
        }

        private void WriteLine(string message, ConsoleColor foreground, ConsoleColor background)
        {
            this.Write(message, foreground, background);
            this.Write(Environment.NewLine, foreground, background);
        }
        private void Write(string message, ConsoleColor foreground, ConsoleColor background)
        {
            var foregroundSave = Console.ForegroundColor;
            var backgroundSave = Console.BackgroundColor;
            try
            {
                Console.ForegroundColor = foreground;
                Console.BackgroundColor = background;
                Console.Write(message);
            }
            finally
            {
                Console.ForegroundColor = foregroundSave;
                Console.BackgroundColor = backgroundSave;
            }
        }
    }
}

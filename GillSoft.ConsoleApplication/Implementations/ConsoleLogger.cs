using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication.Implementations
{
    internal class ConsoleLogger : ILogger
    {
        private readonly IOutput output;

        public ConsoleLogger(IOutput output)
        {
            this.output = output;
        }

        public void Debug(string message)
        {
            output.WriteLine(message);
        }

        public void Error(string message)
        {
            output.WriteError(message);
        }

        public void Error(Exception exception)
        {
            output.WriteError(exception.ToString());
        }

        public void Error(string message, Exception exception)
        {
            output.WriteError(message);
            output.WriteError(exception.ToString());
        }

        public void Info(string message)
        {
            output.WriteLine(message);
        }

        public void Warn(string message)
        {
            output.WriteWarning(message);
        }
    }
}

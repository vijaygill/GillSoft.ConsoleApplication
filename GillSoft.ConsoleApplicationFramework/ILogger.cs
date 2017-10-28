using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplicationFramework
{
    /// <summary>
    /// Interface implemented by logging class
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log an error message and and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Error(string message, Exception exception);

        /// <summary>
        /// Log an error message.
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        /// <summary>
        /// log an exception.
        /// </summary>
        /// <param name="exception"></param>
        void Error(Exception exception);

        /// <summary>
        /// Log informational message.
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);

        /// <summary>
        /// Logs debug message.
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message"></param>
        void Warn(string message);
    }
}

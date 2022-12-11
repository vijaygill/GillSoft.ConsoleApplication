using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application
{
    /// <summary>
    /// Interface implemented by a class that supports output.
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Write a message in normal mode.
        /// </summary>
        /// <param name="message"></param>
        void WriteLine(string message);

        /// <summary>
        /// Write a message in error mode.
        /// </summary>
        /// <param name="message"></param>
        void WriteError(string message);

        /// <summary>
        /// Write a message in warning mode.
        /// </summary>
        /// <param name="message"></param>
        void WriteWarning(string message);
    }
}

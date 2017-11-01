using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication
{
    /// <summary>
    /// Interface implemented by Application class
    /// </summary>
    public interface IApplication : IContainer
    {
        /// <summary>
        /// Entry point to the application.
        /// </summary>
        /// <param name="callback"></param>
        void Run(Action<ILogger, IApplication> callback);

        /// <summary>
        /// Sets exit code if user-code needs to return some status to OS.
        /// </summary>
        /// <param name="exitCode"></param>
        void SetExitCode(int exitCode);
    }
}

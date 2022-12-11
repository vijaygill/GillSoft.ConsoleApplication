using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application
{
    /// <summary>
    /// Interface implemented by commandline arguments parser.
    /// </summary>
    public interface ICommandlineArguments
    {
        /// <summary>
        /// Show help about command line parameters.
        /// </summary>
        bool Help { get; }

        /// <summary>
        /// Show diagnostic messages.
        /// </summary>
        bool Verbose { get; }

        /// <summary>
        /// Show even more diagnostic messages. Mostly debug messages are shown this way.
        /// </summary>
        bool Verbose2 { get; }

        /// <summary>
        /// Displays the help.
        /// </summary>
        void ShowHelp();

        /// <summary>
        /// Displays the error messages raised from validation of command-line parameters.
        /// </summary>
        void ShowErrors();
    }
}

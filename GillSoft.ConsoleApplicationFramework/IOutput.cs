using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplicationFramework
{
    /// <summary>
    /// Interface implemented by a class that supports output.
    /// </summary>
    public interface IOutput
    {
        void WriteLine(string message);
        void WriteError(string message);
        void WriteWarning(string message);
    }
}

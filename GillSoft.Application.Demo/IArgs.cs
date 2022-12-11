using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application.Demo
{

    public interface IArgs : ICommandlineArguments
    {
        string InFile { get; }
        string OutFile { get; }
    }
}

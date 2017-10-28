using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplicationFramework.Implementations
{
    internal class CommandlineArguments : CommandlineArgumentsBase
    {

        public CommandlineArguments(ILogger logger)
            : base(logger)
        {

        }

        protected override Type GetHelpClassType()
        {
            return typeof(CommandlineArgumentsBase.ParameterNames);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication.Implementations
{
    internal class CommandlineArguments : CommandlineArgumentsBase
    {

        public CommandlineArguments(ILogger logger, IOutput output)
            : base(logger, output)
        {

        }

        protected override Type GetHelpClassType()
        {
            return typeof(CommandlineArgumentsBase.ParameterNames);
        }
    }
}

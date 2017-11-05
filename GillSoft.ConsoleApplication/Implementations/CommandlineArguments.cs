using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication.Implementations
{
    internal class CommandlineArguments : CommandlineArgumentsBase
    {

        public CommandlineArguments(IApplication application)
            : base(application)
        {

        }

        protected override Type GetHelpClassType()
        {
            return typeof(CommandlineArgumentsBase.ParameterNames);
        }
    }
}

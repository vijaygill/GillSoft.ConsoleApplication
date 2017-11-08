using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication.Demo
{

    internal class Args : CommandlineArgumentsBase, IArgs
    {
        public Args(IApplication application)
            : base(application)
        {

        }

        public string InFile { get { return base.Get(ParameterNames.InFile, string.Empty); } }

        public string OutFile
        {
            get { return base.Get(ParameterNames.OutFile, "DefaultOut.txt"); }
        }

        protected override Type GetHelpClassType()
        {
            return typeof(ParameterNames);
        }

        private static class ParameterNames
        {
            [Description("Input file to be processed.")]
            public static readonly string InFile = "i";
            [Description("Outout file to be created.")]
            public static readonly string OutFile = "o";
        }
    }
}

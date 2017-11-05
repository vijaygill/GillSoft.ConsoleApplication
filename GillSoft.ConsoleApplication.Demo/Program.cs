using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication.Demo
{
    static class Program
    {
        static void Main(string[] args)
        {
            var app = ApplicationFactory.Create();

            app.RegisterType<IArgs, Args>();

            app.Run(Callback);
        }

        private static void Callback(ILogger logger, IApplication application)
        {
            logger.Debug("My application - DEBUG");
            logger.Info("My application - INFO");
            logger.Warn("My application - WARN");
            logger.Error("My application - ERROR");

            var appconfig = application.Resolve<IApplicationConfiguration>();
            logger.Info("format: " + appconfig.Get("format", "word"));
            logger.Info("sendmail: " + appconfig.Get("sendmail", "false"));

            var cmdArgs = application.Resolve<IArgs>();
            logger.Warn("Input file : " + cmdArgs.InFile);
            logger.Warn("Output file: " + cmdArgs.OutFile);

            application.Resolve<IArgs>().ShowHelp();

            new[]
            {
                new{ FirstName = "John", LastName = "Smith"},
                new{ FirstName = "Jane", LastName = "Doe"},
                new{ FirstName = "Vijay", LastName = "Gill"},
            }.AsTableFormatter(application.Resolve<IOutput>())
            .Column("First Name", 30, a => a.FirstName)
            .Column("Surname", 30, a => a.LastName)
            .Print("People",
            "This is header 1",
            "This is header 2"
            );
        }

        public interface IArgs : ICommandlineArguments
        {
            string InFile { get; }
            string OutFile { get; }
        }

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
}

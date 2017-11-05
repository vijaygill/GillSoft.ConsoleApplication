using System;
using System.Collections.Generic;
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
            app.Run(Callback);
        }

        private static void Callback(ILogger logger, IApplication application)
        {
            logger.Debug("My application");
            logger.Error("My application");
            logger.Info("My application");
            logger.Warn("My application");

            var appconfig = application.Resolve<IApplicationConfiguration>();
            logger.Info("format: " + appconfig.Get("format", "word"));
            logger.Info("sendmail: " + appconfig.Get("sendmail", "false"));

            application.Resolve<ICommandlineArguments>().ShowHelp();

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

        public interface IArgs
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

            public string InFile { get { return ParameterNames.InFile; } }

            public string OutFile
            {
                get { return ParameterNames.OutFile; }
            }

            protected override Type GetHelpClassType()
            {
                return typeof(ParameterNames);
            }

            private static class ParameterNames
            {
                public static readonly string InFile = "i";
                public static readonly string OutFile = "o";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GillSoft.Application;

namespace GillSoft.Application.Demo
{

    public class Worker : IWorker
    {
        private readonly ILogger logger;
        private readonly IOutput output;
        private readonly IApplicationConfiguration applicationConfiguration;
        private readonly IArgs cmdArgs;

        public Worker(ILogger logger, IOutput output,
            IApplicationConfiguration applicationConfiguration,
            IArgs cmdArgs)
        {
            this.logger = logger;
            this.output = output;
            this.applicationConfiguration = applicationConfiguration;
            this.cmdArgs = cmdArgs;
        }

        public void DoSomeWork()
        {
            output.WriteLine("Hello world");

            logger.Debug("My application - DEBUG");
            logger.Info("My application - INFO");
            logger.Warn("My application - WARN");
            logger.Error("My application - ERROR");

            logger.Info("format: " + applicationConfiguration.Get("format", "word"));
            logger.Info("sendmail: " + applicationConfiguration.Get("sendmail", "false"));

            logger.Warn("Input file : " + cmdArgs.InFile);
            logger.Warn("Output file: " + cmdArgs.OutFile);

            cmdArgs.ShowHelp();

            new[]
            {
                    new{ FirstName = "John", LastName = "Smith"},
                    new{ FirstName = "Jane", LastName = "Doe"},
                    new{ FirstName = "Vijay", LastName = "Gill"},
                    }.AsTableFormatter(output)
                .Column("First Name", 30, a => a.FirstName)
                .Column("Surname", 30, a => a.LastName)
                .Print("People",
                "This is header 1",
                "This is header 2"
            );
        }
    }
}

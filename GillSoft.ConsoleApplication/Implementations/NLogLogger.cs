using NLog;
using NLog.Conditions;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication.Implementations
{
    internal class NLogLogger : ILogger
    {
        private ICommandlineArguments commandlineArguments;
        private readonly Logger logger;

        public NLogLogger(ICommandlineArguments commandlineArguments)
        {
            this.commandlineArguments = commandlineArguments;

            var entryAssembly = Assembly.GetEntryAssembly();

            var configFilePath = entryAssembly == null ? string.Empty : Path.Combine(Path.GetDirectoryName(entryAssembly.Location), Common.NLogConfigurationFile);

            if (!string.IsNullOrWhiteSpace(configFilePath) && File.Exists(configFilePath))
            {
                LogManager.Configuration = new XmlLoggingConfiguration(configFilePath);
            }
            else
            {
                var configuration = new LoggingConfiguration();
                var consoleTarget = new ColoredConsoleTarget();
                configuration.AddTarget("console", consoleTarget);

                consoleTarget.Layout = @"${date:format=yyyy-MM-dd HH\:mm\:ss} ${level:uppercase=true} ${message} ${exception:format=toString,Data:maxInnerExceptionLevel=10}";

                var logLevel = commandlineArguments.Verbose ? LogLevel.Info
                    : commandlineArguments.Verbose2 ? LogLevel.Debug
                    : LogLevel.Warn;

                var rule = new LoggingRule("*", logLevel, consoleTarget);
                configuration.LoggingRules.Add(rule);

                consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule
                {
                    Condition = ConditionParser.ParseExpression("level == LogLevel." + LogLevel.Debug),
                    ForegroundColor = ConsoleOutputColor.Gray,
                });

                consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule
                {
                    Condition = ConditionParser.ParseExpression("level == LogLevel." + LogLevel.Info),
                    ForegroundColor = ConsoleOutputColor.Gray,
                });

                consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule
                {
                    Condition = ConditionParser.ParseExpression("level == LogLevel." + LogLevel.Warn),
                    ForegroundColor = ConsoleOutputColor.Yellow,
                });

                consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule
                {
                    Condition = ConditionParser.ParseExpression("level == LogLevel." + LogLevel.Error),
                    ForegroundColor = ConsoleOutputColor.Red,
                });

                LogManager.Configuration = configuration;
            }

            this.logger = LogManager.GetCurrentClassLogger();
        }

        void ILogger.Debug(string message)
        {
            logger.Debug(message);
        }

        void ILogger.Error(string message, Exception exception)
        {
            logger.Error(exception, message);
        }

        void ILogger.Error(string message)
        {
            logger.Error(message);
        }

        void ILogger.Error(Exception exception)
        {
            logger.Error(exception);
        }

        void ILogger.Info(string message)
        {
            logger.Info(message);
        }

        void ILogger.Warn(string message)
        {
            logger.Warn(message);
        }
    }
}

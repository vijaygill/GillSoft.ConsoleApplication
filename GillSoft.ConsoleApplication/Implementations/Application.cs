using GillSoft.ConsoleApplication;
using GillSoft.ConsoleApplication.Implementations;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GillSoft.ConsoleApplication.Implementations
{
    /// <summary>
    /// Concrete Application class.
    /// </summary>
    internal class Application : IApplication
    {
        private readonly IUnityContainer container;
        private readonly ILogger logger;

        private int? exitCode;

        void IApplication.Run(Action<ILogger, IApplication> callback)
        {
            var exitCodeToReturn = Common.DefaultExitCodeWithSuccess;
            try
            {
                var commandlineArguments = container.Resolve<ICommandlineArguments>();

                if (commandlineArguments.Help)
                {
                    commandlineArguments.ShowHelp();
                }
                else
                {
                    callback(logger, this);
                }
            }
            catch (Exception ex)
            {
                exitCodeToReturn = Common.DefaultExitCodeWithError;
                logger.Error("Exception in Run", ex);
            }
            finally
            {
                exitCodeToReturn = exitCode.HasValue ? exitCode.Value : exitCodeToReturn;
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.Write("Press RETURN to close (This messages apppears only while debugging)...");
                    Console.ReadLine();
                }
            }
            Environment.Exit(exitCodeToReturn);
        }

        internal Application()
        {
            this.container = new UnityContainer();

            RegisterTypes();

            this.logger = container.Resolve<ILogger>();
        }

        private void RegisterTypes()
        {
            container.RegisterInstance<IApplication>(this);

            if (!container.IsRegistered<IOutput>())
            {
                container.RegisterType<IOutput, ConsoleOutput>();
            }

            if (!container.IsRegistered<ILogger>())
            {
                container.RegisterType<ILogger, ConsoleLogger>();
            }

            if (!container.IsRegistered<IApplicationConfiguration>())
            {
                container.RegisterType<IApplicationConfiguration, ApplicationConfigurationBase>();
            }

            if (!container.IsRegistered<IApplicationConfiguration>())
            {
                container.RegisterType<IApplicationConfiguration, ApplicationConfigurationBase>();
            }

            if (!container.IsRegistered<ICommandlineArguments>())
            {
                container.RegisterType<ICommandlineArguments, CommandlineArguments>();
            }

        }

        void IApplication.SetExitCode(int exitCode)
        {
            this.exitCode = exitCode;
        }

        bool IApplication.IsRegistered<T>()
        {
            var res = container.IsRegistered<T>();
            return res;
        }

        void IApplication.RegisterInstance<TInterface>(TInterface instance)
        {
            this.container.RegisterInstance<TInterface>(instance);
        }

        T IApplication.Resolve<T>()
        {
            var res = this.container.Resolve<T>();
            return res;
        }

        void IApplication.RegisterType<TFrom, TTo>()
        {
            this.container.RegisterType<TFrom, TTo>();
        }


    }
}

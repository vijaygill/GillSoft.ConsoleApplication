using GillSoft.ConsoleApplicationFramework;
using GillSoft.ConsoleApplicationFramework.Implementations;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplicationFramework
{
    /// <summary>
    /// Concrete Application class.
    /// </summary>
    public sealed class Application : IApplication
    {
        private readonly IUnityContainer container;
        private ILogger logger;
        private readonly IApplication app;

        void IApplication.Run(Action<ILogger, IApplication> callback)
        {
            try
            {
                var commandlineArguments = app.Resolve<ICommandlineArguments>();

                if(commandlineArguments.Help)
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
                logger.Error("Exception in Run", ex);
            }
            finally
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.Write("Press RETURN to close (This messages apppears only while debugging)...");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Creates an instance of Application
        /// </summary>
        /// <returns></returns>
        public static IApplication Create()
        {
            var res = new Application();
            return res;
        }

        private Application()
        {
            this.container = new UnityContainer();

            this.app = this as IApplication;

            RegisterTypes();
        }

        private void RegisterTypes()
        {
            app.RegisterInstance<IApplication>(this);

            if (!app.IsRegistered<IOutput>())
            {
                app.RegisterType<IOutput, ConsoleOutput>();
            }

            if (!app.IsRegistered<ILogger>())
            {
                app.RegisterType<ILogger, ConsoleLogger>();
            }

            if (!app.IsRegistered<IApplicationConfiguration>())
            {
                app.RegisterType<IApplicationConfiguration, ApplicationConfigurationBase>();
            }

            if (!app.IsRegistered<IApplicationConfiguration>())
            {
                app.RegisterType<IApplicationConfiguration, ApplicationConfigurationBase>();
            }

            if (!app.IsRegistered<ICommandlineArguments>())
            {
                app.RegisterType<ICommandlineArguments, CommandlineArguments>();
            }

            this.logger = app.Resolve<ILogger>();
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

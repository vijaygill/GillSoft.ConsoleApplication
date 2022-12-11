﻿using GillSoft.Application;
using GillSoft.Application.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace GillSoft.Application.Implementations
{
    /// <summary>
    /// Concrete Application class.
    /// </summary>
    internal class Application : IApplication
    {
        private readonly IUnityContainer container;
        private readonly ILogger logger;

        private readonly IApplication app;

        private int? exitCode;

        void IApplication.Run(Action<ILogger, IApplication> callback)
        {
            var exitCodeToReturn = Common.DefaultExitCodeWithSuccess;
            try
            {
                var commandlineArguments = GetCommandLineArgumentsInstance();

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

        private ICommandlineArguments GetCommandLineArgumentsInstance()
        {
            var overriddenType = container.Registrations
                .Where(reg => typeof(ICommandlineArguments).IsAssignableFrom(reg.MappedToType)
                && typeof(ICommandlineArguments).Assembly != reg.RegisteredType.Assembly)
                .Select(a => a.RegisteredType)
                .FirstOrDefault();

            var res = overriddenType == null
                ? container.Resolve<ICommandlineArguments>()
                : container.Resolve(overriddenType) as ICommandlineArguments;

            return res;
        }

        internal Application()
        {
            this.app = this;

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
                container.RegisterType<ILogger, NLogLogger>();
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
            app.RegisterType<TFrom, TTo>(InstanceScope.Transient);
        }

        void IApplication.RegisterType<TFrom, TTo>(InstanceScope instanceScope)
        {
            var lifetimeManager = lifetimeManagers[instanceScope]();
            container.RegisterType<TFrom, TTo>(lifetimeManager);
        }

        private readonly Dictionary<InstanceScope, Func<ITypeLifetimeManager>> lifetimeManagers
             = new Dictionary<InstanceScope, Func<ITypeLifetimeManager>>
             {
                 { InstanceScope.Singleton, () => new ContainerControlledLifetimeManager() },
                 { InstanceScope.PerResolve,() =>  new PerResolveLifetimeManager() },
                 { InstanceScope.Transient, () => new TransientLifetimeManager() },
             };

        void IApplication.Run<T>(Action<T> callback)
        {
            var exitCodeToReturn = Common.DefaultExitCodeWithSuccess;
            try
            {
                var commandlineArguments = GetCommandLineArgumentsInstance();

                if (commandlineArguments.Help)
                {
                    commandlineArguments.ShowHelp();
                }
                else
                {
                    var instance = this.container.Resolve<T>();
                    callback(instance);
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

    }
}

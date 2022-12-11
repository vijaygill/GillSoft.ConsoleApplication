using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application
{
    /// <summary>
    /// Interface implemented by Application class
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// Entry point to the application.
        /// </summary>
        /// <param name="callback"></param>
        [Obsolete("Use Run<T>(Action<T> callabck)")]
        void Run(Action<ILogger, IApplication> callback);

        /// <summary>
        /// Resolves a type and calls the callback
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callback"></param>
        void Run<T>(Action<T> callback);


        /// <summary>
        /// Sets exit code if user-code needs to return some status to OS.
        /// </summary>
        /// <param name="exitCode"></param>
        void SetExitCode(int exitCode);

        /// <summary>
        /// Registers an interface and the concrete class with DI container.
        /// </summary>
        /// <typeparam name="TFrom">Interface</typeparam>
        /// <typeparam name="TTo">Concrete class</typeparam>
        void RegisterType<TFrom, TTo>() where TTo : TFrom;

        /// <summary>
        /// Registers an interface and the concrete class with DI container.
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="instanceScope"><see cref="InstanceScope"/></param>
        void RegisterType<TFrom, TTo>(InstanceScope instanceScope) where TTo : TFrom;

        /// <summary>
        /// Registers an interface and an instance of a concrete class  with DI container.
        /// </summary>
        /// <typeparam name="TInterface">Interface</typeparam>
        /// <param name="instance">Instance of the class that implements TInterface</param>
        void RegisterInstance<TInterface>(TInterface instance);

        /// <summary>
        /// Checks if a type is registered with DI container.
        /// </summary>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns></returns>
        bool IsRegistered<T>();

        /// <summary>
        /// Returns a resolved instance of a type with all dependencies injected,
        /// </summary>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns></returns>
        T Resolve<T>();
    }
}

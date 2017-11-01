using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GillSoft.ConsoleApplication.Implementations
{
    internal class Container : IContainer
    {
        private readonly IUnityContainer container;

        public Container()
        {
            this.container = new UnityContainer();
        }

        bool IContainer.IsRegistered<T>()
        {
            var res = container.IsRegistered<T>();
            return res;
        }

        void IContainer.RegisterInstance<TInterface>(TInterface instance)
        {
            this.container.RegisterInstance<TInterface>(instance);
        }

        T IContainer.Resolve<T>()
        {
            var res = this.container.Resolve<T>();
            return res;
        }

        void IContainer.RegisterType<TFrom, TTo>()
        {
            this.container.RegisterType<TFrom, TTo>();
        }
    }
}

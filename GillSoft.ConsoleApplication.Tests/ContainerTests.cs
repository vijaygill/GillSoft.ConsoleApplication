using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GillSoft.ConsoleApplication.Tests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void Default_Transient()
        {
            //arrange
            var maxInstances = 100;
            var app = ApplicationFactory.Create();
            app.RegisterType<ICommon, Common>();
            app.RegisterType<IUser1, User1>();
            app.RegisterType<IUser2, User2>();

            //act
            var count = Enumerable.Range(0, maxInstances)
                .Select(x => app.Resolve<IUser2>())
                .SelectMany(x => new[] { x.Common.Id, x.User1.Common.Id })
                .Distinct()
                .Count();

            //assert

            Assert.AreEqual(2 * maxInstances, count);
        }

        [TestMethod]
        public void Singleton()
        {
            //arrange
            var maxInstances = 100;
            var app = ApplicationFactory.Create();
            app.RegisterType<ICommon, Common>(InstanceScope.Singleton);
            app.RegisterType<IUser1, User1>();
            app.RegisterType<IUser2, User2>();

            //act
            var count = Enumerable.Range(0, maxInstances)
                .Select(x => app.Resolve<IUser2>())
                .SelectMany( x => new[] { x.Common.Id, x.User1.Common.Id })
                .Distinct()
                .Count();

            //assert

            Assert.AreEqual(1, count);

        }

        [TestMethod]
        public void Transient()
        {
            //arrange
            var maxInstances = 100;
            var app = ApplicationFactory.Create();
            app.RegisterType<ICommon, Common>();
            app.RegisterType<IUser1, User1>();
            app.RegisterType<IUser2, User2>();

            //act
            var count = Enumerable.Range(0, maxInstances)
                .Select(x => app.Resolve<IUser2>())
                .SelectMany(x => new[] { x.Common.Id, x.User1.Common.Id })
                .Distinct()
                .Count();

            //assert

            Assert.AreEqual(2 * maxInstances, count);
        }

        [TestMethod]
        public void PerResolve()
        {
            //arrange
            var maxInstances = 100;
            var app = ApplicationFactory.Create();
            app.RegisterType<ICommon, Common>(InstanceScope.PerResolve);
            app.RegisterType<IUser1, User1>();
            app.RegisterType<IUser2, User2>();

            //act
            var count = Enumerable.Range(0, maxInstances)
                .Select(x => app.Resolve<IUser2>())
                .SelectMany(x => new[] { x.Common.Id, x.User1.Common.Id })
                .Distinct()
                .Count();

            //assert

            Assert.AreEqual(maxInstances, count);
        }

        #region test classes

        internal interface ICommon
        {
            Guid Id { get; }
        }

        internal class Common : ICommon
        {
            public Guid Id { get; private set; }

            public Common()
            {
                this.Id = Guid.NewGuid();
            }
        }

        internal interface IUser1
        {
            ICommon Common { get; }
        }

        internal class User1 : IUser1
        {
            public ICommon Common { get; private set; }

            public User1(ICommon common)
            {
                this.Common = common;
            }
        }

        internal interface IUser2
        {
            ICommon Common { get; }

            IUser1 User1 { get; }
    }

        internal class User2 : IUser2
        {
            public ICommon Common { get; private set; }
            public IUser1 User1 { get; private set; }

            public User2(ICommon common, IUser1 user1)
            {
                this.Common = common;
                this.User1 = user1;
            }
        }

        #endregion test classes
    }
}

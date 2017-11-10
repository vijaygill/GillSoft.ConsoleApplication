using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication.Demo
{
    static partial class Program
    {
        static void Main(string[] args)
        {
            var app = ApplicationFactory.Create();
            app.RegisterType<IArgs, Args>();
            app.RegisterType<IWorker, Worker>();
            app.Run<IWorker>(w => w.DoSomeWork());

        }
    }
}

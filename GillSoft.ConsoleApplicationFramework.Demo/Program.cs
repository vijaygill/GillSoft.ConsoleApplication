using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplicationFramework.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = Application.Create();
            app.Run(Callback);
        }

        private static void Callback(ILogger logger, IApplication application)
        {
            logger.Debug("My application");
            logger.Error("My application");
            logger.Info("My application");
            logger.Warn("My application");
        }
    }
}

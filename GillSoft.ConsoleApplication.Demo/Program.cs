﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication.Demo
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

            var appconfig = application.Resolve<IApplicationConfiguration>();
            logger.Info("format: " + appconfig.Get("format", "word"));
            logger.Info("sendmail: " + appconfig.Get("sendmail", "false"));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if NET
using Microsoft.Extensions.Configuration;
#endif


namespace GillSoft.Application
{
    /// <summary>
    /// Base class for reading App.Config if you do not want to create your own.
    /// </summary>
    public class ApplicationConfigurationBase : IApplicationConfiguration
    {
#if NETFRAMEWORK
        private static NameValueCollection appSettings = ConfigurationManager.AppSettings;
#else
        private static IConfiguration appSettings;

        static ApplicationConfigurationBase()
        {
            appSettings = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
#endif


        /// <summary>
        /// Returns value of a given key in app.config
        /// </summary>
        /// <param name="key">Key name</param>
        /// <param name="defaultValue">Default value if key is not prsent in app.config</param>
        /// <returns></returns>
        public string Get(string key, string defaultValue)
        {
            var res = appSettings[key];
            if (string.IsNullOrWhiteSpace(res))
            {
                res = defaultValue;
            }
            return res;
        }
    }
}
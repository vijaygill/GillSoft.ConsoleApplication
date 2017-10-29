using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication
{
    /// <summary>
    /// Base class for reading App.Config if you do not want to create your own.
    /// </summary>
    public class ApplicationConfigurationBase : IApplicationConfiguration
    {
        /// <summary>
        /// Returns value of a given key in app.config
        /// </summary>
        /// <param name="key">Key name</param>
        /// <param name="defaultValue">Default value if key is not prsent in app.config</param>
        /// <returns></returns>
        public string Get(string key, string defaultValue)
        {
            var res = System.Configuration.ConfigurationManager.AppSettings[key];
            if(string.IsNullOrWhiteSpace(res))
            {
                res = defaultValue;
            }

            return res;
        }
    }
}

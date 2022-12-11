using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application
{
    /// <summary>
    /// Interface to implemented by App.config reader class.
    /// </summary>
    public interface IApplicationConfiguration
    {
        /// <summary>
        /// Returns value of a given key in app.config
        /// </summary>
        /// <param name="key">Key name</param>
        /// <param name="defaultValue">Default value if key is not prsent in app.config</param>
        /// <returns></returns>
        string Get(string key, string defaultValue);
    }
}

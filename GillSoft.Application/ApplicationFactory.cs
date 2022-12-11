using GillSoft.Application.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application
{
    /// <summary>
    /// Factory for creating IApplication instances
    /// </summary>
    public static class ApplicationFactory
    {
        /// <summary>
        /// Creates an instance of Application which uses built-in DI/IOC container.
        /// </summary>
        /// <returns></returns>
        public static IApplication Create()
        {
            var res = new GillSoft.Application.Implementations.Application();
            return res;
        }
    }
}

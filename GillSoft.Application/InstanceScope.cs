using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application
{
    /// <summary>
    /// Controls how a type is resolved.
    /// </summary>
    public enum InstanceScope
    {
        /// <summary>
        /// A new instance is created every time.
        /// An object graph resolved will have multiple instances of same dependency.
        /// </summary>
        Transient,
        /// <summary>
        /// As the name suggests, same instance will be used all the times.
        /// </summary>
        Singleton,
        /// <summary>
        /// One instance will be used while resolving a graph.
        /// </summary>
        PerResolve
    }
}

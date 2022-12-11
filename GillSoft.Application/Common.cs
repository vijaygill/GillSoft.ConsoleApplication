using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application
{
    /// <summary>
    /// String Justify
    /// </summary>
    public enum StringJustify
    {
        /// <summary>
        /// Left
        /// </summary>
        Left,

        /// <summary>
        /// Right
        /// </summary>
        Right,

        /// <summary>
        /// Center
        /// </summary>
        Center,
    }
    /// <summary>
    /// Place for all common values
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Default exit code if all goes well
        /// </summary>
        public static readonly int DefaultExitCodeWithSuccess = 0;

        /// <summary>
        /// Default exit code if user-code does not handle exit properly in case or error.
        /// </summary>
        public static readonly int DefaultExitCodeWithError = byte.MaxValue;

        /// <summary>
        /// Log file expected by built-in logger based on NLog.
        /// </summary>
        public static readonly string NLogConfigurationFile = @"NLog.config";
    }
}

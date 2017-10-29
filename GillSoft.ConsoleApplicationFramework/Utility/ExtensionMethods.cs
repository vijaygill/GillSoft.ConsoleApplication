using GillSoft.ConsoleApplication.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication
{
    /// <summary>
    /// extension methods class
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Helper for printing a typed collection in table format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static ITableFormattedPrintableList<T> AsTableFormatter<T>(this IEnumerable<T> collection)
        {
            var res = new TableFormatter<T>(collection);
            return res;
        }
    }
}

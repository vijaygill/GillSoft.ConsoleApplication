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
        /// <param name="output"></param>
        /// <returns></returns>
        public static ITableFormattedPrintableList<T> AsTableFormatter<T>(this IEnumerable<T> collection, IOutput output)
        {
            var res = new TableFormatter<T>(output, collection);
            return res;
        }

        /// <summary>
        /// Returns a string justified left/right/center within a given width
        /// </summary>
        /// <param name="value"></param>
        /// <param name="stringJustify"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Justify(this string value, StringJustify stringJustify, int length)
        {
            var res = value;
            if (value != null && length > value.Length)
            {
                switch (stringJustify)
                {
                    case StringJustify.Left:
                        {
                            var padLength = (length - value.Length) / 2;
                            var pad = padLength > 0 ? new string(' ', padLength) : string.Empty;
                            res = value + pad;
                            break;
                        }
                    case StringJustify.Right:
                        {
                            var padLength = (length - value.Length) / 2;
                            var pad = padLength > 0 ? new string(' ', padLength) : string.Empty;
                            res = pad + value;
                            break;
                        }
                    case StringJustify.Center:
                        {
                            var padLength = (length - value.Length) / 2;
                            var pad = padLength > 0 ? new string(' ', padLength) : string.Empty;
                            res = pad + value;
                            break;
                        }
                }
            }

            return res;
        }
    }
}

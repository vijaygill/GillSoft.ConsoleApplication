using System;

namespace GillSoft.ConsoleApplication
{
    /// <summary>
    /// Interface implemented by wrapper around table foratted list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITableFormattedPrintableList<T>
    {
        /// <summary>
        /// Define a column
        /// </summary>
        /// <param name="columnHeader">Text shown as header of the column</param>
        /// <param name="maxWidth">Maximum width of the column</param>
        /// <param name="valueGetter">Lambda expression to get value for a cell in the given column</param>
        /// <returns></returns>
        ITableFormattedPrintableList<T> Column(string columnHeader, int maxWidth, Func<T, string> valueGetter);

        /// <summary>
        /// Prints the passed list in table format.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="title"></param>
        /// <param name="indent"></param>
        /// <param name="headers"></param>
        void Print(IOutput output, string title, int indent = 0, params string[] headers);
    }
}

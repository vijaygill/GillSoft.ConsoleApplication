using System;

namespace GillSoft.ConsoleApplication
{
    /// <summary>
    /// Interface implemented by a list that can be printed in table format.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITableFormattedPrintableList<T>
    {
        /// <summary>
        /// Define a column
        /// </summary>
        /// <param name="columnHeader">Text shown as header of the column</param>
        /// <param name="maxwidth">Maximum width of the column</param>
        /// <param name="valueGetter">Lambda expression to get value for a cell in the given column</param>
        /// <returns></returns>
        ITableFormattedPrintableList<T> Column(string columnHeader, int maxwidth, Func<T, string> valueGetter);

        /// <summary>
        /// Prints the list in table format.
        /// </summary>
        void Print();
    }
}

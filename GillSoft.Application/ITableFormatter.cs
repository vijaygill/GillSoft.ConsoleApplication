﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application
{
    /// <summary>
    /// Interface implemented by class that can print a list in table format.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITableFormatter<T>
    {
        /// <summary>
        /// Define a column
        /// </summary>
        /// <param name="columnHeader">Text shown as header of the column</param>
        /// <param name="maxWidth">Maximum width of the column</param>
        /// <param name="valueGetter">Lambda expression to get value for a cell in the given column</param>
        /// <returns></returns>
        ITableFormatter<T> Column(string columnHeader, int maxWidth, Func<T, string> valueGetter);

        /// <summary>
        /// Prints the passed list in table format.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="title"></param>
        /// <param name="headers"></param>
        void Print(IEnumerable<T> collection, string title, params string[] headers);

        /// <summary>
        /// Sets indent from left side of the screen.
        /// </summary>
        /// <param name="indent"></param>
        ITableFormatter<T> SetIndent(int indent);

    }
}

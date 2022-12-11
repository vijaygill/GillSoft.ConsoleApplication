using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.Application.Implementations
{
    internal class TableFormatter<T> : ITableFormatter<T>, ITableFormattedPrintableList<T>
    {
        private readonly IOutput output;
        private readonly IEnumerable<T> collection;

        private readonly List<Colummn> columns = new List<Colummn>();

        private int indent = 0;

        public TableFormatter(IOutput output, IEnumerable<T> collection)
        {
            this.output = output;
            this.collection = collection;
        }

        private class Colummn
        {
            public string ColumnHeader { get; private set; }
            public int MaxWidth { get; private set; }
            public Func<T, string> ValueGetter { get; private set; }

            public Colummn(string columnHeader, int maxWidth, Func<T, string> valueGetter)
            {
                this.ColumnHeader = columnHeader;
                this.MaxWidth = maxWidth;
                this.ValueGetter = valueGetter;
            }
        }

        private void Column(string columnHeader, int maxWidth, Func<T, string> valueGetter)
        {
            var column = new Colummn(columnHeader, maxWidth, valueGetter);
            this.columns.Add(column);
        }


        ITableFormatter<T> ITableFormatter<T>.Column(string columnHeader, int maxWidth, Func<T, string> valueGetter)
        {
            this.Column(columnHeader, maxWidth, valueGetter);
            return this;
        }

        void ITableFormatter<T>.Print(IEnumerable<T> collection, string title, params string[] headers)
        {
            this.Print(collection, title, headers);
        }

        private void Print(IEnumerable<T> collection, string title, params string[] headers)
        {
            if (!columns.Any())
            {
                return;
            }
            var dash = '-';
            var sep = '|';
            var space = ' ';
            var plus = "+";
            var headerPrefix = "* ";
            var titlePrefix = "[ ";
            var titleSuffix = " ]";

            var indentStr = indent > 0 ? new string(space, indent) : string.Empty;

            var totalLength = columns.Sum(a => a.MaxWidth) + (columns.Count - 1);

            var tableTitle = titlePrefix + title + titleSuffix;

            var titleDashLengthLeft = (totalLength - tableTitle.Length) / 2;
            var titleDashLengthRight = (totalLength - tableTitle.Length) / 2 + totalLength % 2;

            var lineWithSeparators = string.Join(plus, columns.Select(c => new string(dash, c.MaxWidth)));

            var titleDashLeft = new string(dash, titleDashLengthLeft);
            var titleDashRight = new string(dash, titleDashLengthRight);

            //header
            output.WriteLine(indentStr + string.Format("{0}{1}{2}", titleDashLeft, tableTitle, titleDashRight));
            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    output.WriteLine(indentStr + headerPrefix + header);
                }
                output.WriteLine(indentStr + lineWithSeparators);
            }
            var columnHeaders = string.Join(sep.ToString(), columns.Select(c => string.Format("{0,-" + c.MaxWidth + "}", c.ColumnHeader.Justify(StringJustify.Center, c.MaxWidth))));
            output.WriteLine(indentStr + columnHeaders);
            output.WriteLine(indentStr + lineWithSeparators);

            var format = string.Join(plus, columns.Select((c, index) => "{" + (index) + "," + c.MaxWidth + "}"));

            if (collection.Any())
            {
                foreach (var item in collection)
                {
                    var values = string.Join(sep.ToString(), columns.Select(c => string.Format("{0,-" + c.MaxWidth + "}", c.ValueGetter(item))));
                    output.WriteLine(indentStr + values);
                }
            }

            //footer
            output.WriteLine(indentStr + lineWithSeparators);

        }

        ITableFormattedPrintableList<T> ITableFormattedPrintableList<T>.Column(string columnHeader, int maxWidth, Func<T, string> valueGetter)
        {
            this.Column(columnHeader, maxWidth, valueGetter);
            return this;
        }

        void ITableFormattedPrintableList<T>.Print(string title, params string[] headers)
        {
            this.Print(this.collection, title, headers);
        }

        ITableFormatter<T> ITableFormatter<T>.SetIndent(int indent)
        {
            this.indent = indent;
            return this;
        }

        ITableFormattedPrintableList<T> ITableFormattedPrintableList<T>.SetIndent(int indent)
        {
            this.indent = indent;
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplication.Implementations
{
    internal class TableFormatter<T> : ITableFormatter<T>, ITableFormattedPrintableList<T>
    {
        private IEnumerable<T> collection;

        public TableFormatter(IEnumerable<T> collection)
        {
            this.collection = collection;
        }

        ITableFormatter<T> ITableFormatter<T>.Column(string columnHeader, int maxwidth, Func<T, string> valueGetter)
        {
            throw new NotImplementedException();
        }

        ITableFormattedPrintableList<T> ITableFormattedPrintableList<T>.Column(string columnHeader, int maxwidth, Func<T, string> valueGetter)
        {
            throw new NotImplementedException();
        }

        void ITableFormatter<T>.Print(IEnumerable<T> collection)
        {
            this.Print(collection);
        }

        private void Print(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        void ITableFormattedPrintableList<T>.Print()
        {
            Print(this.collection);
        }
    }
}

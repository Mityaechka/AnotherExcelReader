using AnotherExcelReader.Core.CellParsers;
using System;
using System.Linq.Expressions;

namespace AnotherExcelReader.Core.ColumnDetails
{
    public class ColumnDetails<TModel, TValue>
    {
        public Expression<Func<TModel, TValue>> Propperty { get; private set; }
        public CellParser<TValue> Parser { get; private set; }
        public int Index { get; private set; }

        public ColumnDetails(Expression<Func<TModel, TValue>> propperty, CellParser<TValue> parser, int index)
        {
            Propperty = propperty;
            Parser = parser;
            Index = index;
        }
    }
}

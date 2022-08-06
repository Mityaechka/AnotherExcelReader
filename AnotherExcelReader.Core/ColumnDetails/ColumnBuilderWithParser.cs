using AnotherExcelReader.Core.CellParsers;
using System;
using System.Linq.Expressions;

namespace AnotherExcelReader.Core.ColumnDetails
{
    public class ColumnBuilderWithParser<TModel, TValue>
    {
        private readonly int _index;
        private readonly Expression<Func<TModel, TValue>> _propperty;
        private readonly CellParser<TValue> _wrapper;

        public ColumnBuilderWithParser(int index, Expression<Func<TModel, TValue>> expression, CellParser<TValue> wrapper)
        {
            _index = index;
            _propperty = expression;
            _wrapper = wrapper;
        }

        public ColumnDetails<TModel, TValue> Build()
        {
            return new(_propperty, _wrapper, _index);
        }
    }
}

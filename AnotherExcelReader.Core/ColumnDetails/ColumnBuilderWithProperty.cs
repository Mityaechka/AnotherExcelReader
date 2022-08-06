using AnotherExcelReader.Core.CellParsers;
using System;
using System.Linq.Expressions;

namespace AnotherExcelReader.Core.ColumnDetails
{
    public class ColumnBuilderWithProperty<TModel, TValue>
    {
        private readonly int _index;
        private readonly Expression<Func<TModel, TValue>> _property;

        public ColumnBuilderWithProperty(int index, Expression<Func<TModel, TValue>> expression)
        {
            _index = index;
            _property = expression;
        }

        public ColumnBuilderWithParser<TModel, TValue> AddParser(CellParser<TValue> wrapper)
        {
            return new(_index, _property, wrapper);
        }
    }
}

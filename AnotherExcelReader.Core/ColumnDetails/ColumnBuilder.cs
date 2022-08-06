using System;
using System.Linq.Expressions;

namespace AnotherExcelReader.Core.ColumnDetails
{
    public class ColumnBuilder<TModel>
    {
        private int _index;

        private ColumnBuilder()
        {

        }

        public static ColumnBuilder<TModel> Init()
        {
            return new();
        }

        public ColumnBuilder<TModel> AddIndex(int index)
        {
            _index = index;
            return this;
        }

        public ColumnBuilderWithProperty<TModel, TValue> AddProperty<TValue>(Expression<Func<TModel, TValue>> propperty)
        {
            return new(_index, propperty);
        }
    }
}

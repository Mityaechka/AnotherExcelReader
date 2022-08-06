using AnotherExcelReader.Core.ColumnDetails;
using AnotherExcelReader.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AnotherExcelReader.Core.Binder
{
    public class BinderConfiguration<TModel>
    {
        private readonly List<BindedColumn> _columns = new List<BindedColumn>();

        public IEnumerable<BindedColumn> Columns => _columns.AsEnumerable();

        public BinderConfiguration<TModel> AddColum<TValue>(Func<ColumnBuilder<TModel>, ColumnBuilderWithParser<TModel, TValue>> func)
        {
            ColumnBuilder<TModel> builder = ColumnBuilder<TModel>.Init();

            ColumnBuilderWithParser<TModel, TValue> finalBuilder = func(builder);

            ColumnDetails<TModel, TValue> column = finalBuilder.Build();

            PropertyInfo property = PropertyHelpers<TModel>.GetProperty(column.Propperty);

            BindedColumn bindedColumn = new BindedColumn(property, column.Parser, column.Index);

            _columns.Add(bindedColumn);

            return this;
        }

        public static BinderConfiguration<TModel> Init(Action<BinderConfiguration<TModel>> options)
        {
            BinderConfiguration<TModel> constructor = new BinderConfiguration<TModel>();

            options(constructor);

            return constructor;
        }
    }
}

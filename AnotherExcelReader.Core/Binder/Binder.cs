using AnotherExcelReader.Core.CellParsers;
using AnotherExcelReader.Core.ExcelParser;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AnotherExcelReader.Core.Binder
{
    public class Binder<TModel>
    {
        private readonly BinderConfiguration<TModel> _configuration;
        private readonly IExcelParser _excelParser;

        public Binder(BinderConfiguration<TModel> configuration, IExcelParser excelParser)
        {
            _configuration = configuration;
            _excelParser = excelParser;
        }

        public IEnumerable<TModel> Bind(Source source)
        {
            RawData rawData = _excelParser.Parse(source);

            List<TModel> result = new List<TModel>();

            foreach (Row row in rawData)
            {
                TModel t = Activator.CreateInstance<TModel>();

                BindRow(row, t);

                result.Add(t);

            }

            return result;
        }

        private void BindRow(Row row, TModel t)
        {
            foreach (BindedColumn column in _configuration.Columns)
            {
                object value = row[column.Index];
                PropertyInfo property = column.Property;
                CellParser parser = column.Parser;

                object parsed = parser.Parse(value);

                property.SetValue(t, parsed);

            }
        }
    }
}

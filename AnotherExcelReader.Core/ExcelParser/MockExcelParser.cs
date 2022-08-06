using AnotherExcelReader.Core.Binder;
using System.Collections;
using System.Collections.Generic;

namespace AnotherExcelReader.Core.ExcelParser
{
    public class MockExcelParser : IExcelParser, IEnumerable<Row>
    {
        private readonly RawData _data;
        public MockExcelParser()
        {
            _data = new RawData();

        }

        public MockExcelParser(RawData data)
        {
            _data = data;
        }

        public void Add(Row row)
        {
            _data.Add(row);
        }

        public IEnumerator<Row> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public RawData Parse(Source source)
        {
            return _data;
        }
    }
}

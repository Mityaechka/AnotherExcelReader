using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AnotherExcelReader.Core.Binder
{
    public class RawData : IEnumerable<Row>
    {
        private List<Row> _data { get; set; }

        public RawData()
        {
            _data = new List<Row>();
        }

        public RawData(List<Row> data)
        {
            _data = data;
        }

        public void Add(Row row)
        {
            _data.Add(row);
        }

        public IEnumerable<Row> Data => _data.AsEnumerable();

        public IEnumerator<Row> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}

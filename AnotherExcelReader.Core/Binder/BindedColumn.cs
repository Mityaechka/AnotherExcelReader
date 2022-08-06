using AnotherExcelReader.Core.CellParsers;
using System.Reflection;

namespace AnotherExcelReader.Core.Binder
{
    public class BindedColumn
    {
        public PropertyInfo Property { get; private set; }
        public CellParser Parser { get; private set; }
        public int Index { get; private set; }

        public BindedColumn(PropertyInfo property, CellParser parser, int index)
        {
            Property = property;
            Parser = parser;
            Index = index;
        }
    }
}

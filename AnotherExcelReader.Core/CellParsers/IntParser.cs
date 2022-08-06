using System;

namespace AnotherExcelReader.Core.CellParsers
{
    public class IntParser : CellParser<int>
    {
        public override object Parse(object raw)
        {
            return Convert.ToInt32(raw);
        }
    }
}

namespace AnotherExcelReader.Core.CellParsers
{
    public class StringParser : CellParser<string>
    {
        public override object Parse(object raw)
        {
            return raw.ToString();
        }
    }
}

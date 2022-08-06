namespace AnotherExcelReader.Core.CellParsers
{
    public abstract class CellParser
    {
        public abstract object Parse(object raw);


        public static IntParser Int => new ();
        public static StringParser String => new ();
    }

    public abstract class CellParser<T> : CellParser
    {

    }
}

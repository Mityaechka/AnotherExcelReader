using AnotherExcelReader.Core.Binder;

namespace AnotherExcelReader.Core.ExcelParser
{
    public class Source
    {

    }
    public interface IExcelParser
    {
        public RawData Parse(Source source);
    }
}

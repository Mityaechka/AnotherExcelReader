using AnotherExcelReader.Core.Binder;
using AnotherExcelReader.Core.CellParsers;
using AnotherExcelReader.Core.ExcelParser;
using AnotherExcelReader.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnotherExcelReader.Tests.Tests
{
    public class BinderTests
    {
        [Fact]
        public void ModelBindedCorrectly()
        {
            IExcelParser parser = new MockExcelParser
            {
                new Row
                {
                    {0, 1 },
                    {1, "test 1" },
                },
                new Row
                {
                    {0, "2" },
                    {1, "test 2" },
                }
            };

            BinderConfiguration<SimpleModel> configuration = BinderConfiguration<SimpleModel>.Init(options =>
            {
                options.AddColum(builder => builder.AddIndex(0).AddProperty(m => m.Int).AddParser(CellParser.Int));

                options.AddColum(builder => builder.AddIndex(1).AddProperty(m => m.String).AddParser(CellParser.String));
            });

            Source source = new Source();

            Binder<SimpleModel> binder = new Binder<SimpleModel>(configuration, parser);


            IEnumerable<SimpleModel> bindResult = binder.Bind(source);


            IEnumerable<SimpleModel> correctResult = new List<SimpleModel>
            {
                new SimpleModel {Int = 1, String = "test 1"},
                new SimpleModel {Int = 2, String = "test 2"},
            };

            Assert.Equal(bindResult, correctResult);
        }
    }
}

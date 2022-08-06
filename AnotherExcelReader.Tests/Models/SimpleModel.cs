using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherExcelReader.Tests.Models
{
    public class SimpleModel
    {
        public int Int { get; set; }
        public string String { get; set; }

        public override bool Equals(object obj)
        {
            if(obj == null) return false;
            if(obj is not SimpleModel) return false;

            var model = obj as SimpleModel;

            return model.Int == this.Int && model.String == this.String;
        }
    }
}

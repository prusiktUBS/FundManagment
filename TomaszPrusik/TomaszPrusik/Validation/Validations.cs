using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TomaszPrusik.Validation
{
    public class Validations
    {
        public bool Validate(string value1, string value2)
        {
            switch ("Double")
            {
                case "Double":
                    double doubleVal = 0;
                    var canConvert1 = double.TryParse(value1, out doubleVal);
                    var canConvert2 = double.TryParse(value2, out doubleVal);
                    if (canConvert1 && canConvert2)
                        return true;
                    return false;
            }
        }
    }
}

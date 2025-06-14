using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium.Core
{
    internal class Data
    {
        /*
         * "(" = "%28"
         * ")" = "%29"
         * " " = "%20"
         * "|" = "%7C"
         */
        List<string> quality = new List<string>
        {
            "Factory-New",
            "Minimal-Wear",
            "Field-Tested",
            "Well-Worn",
            "Battle-Scarred"
        };
    }
}

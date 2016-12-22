using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHelper
{
    public class Checker
    {
        public static bool MatchesNameFormat(string name)=>
            name != string.Empty &&
            char.IsLetter(name[0]) &&
            char.IsUpper(name[0]);
    }
}

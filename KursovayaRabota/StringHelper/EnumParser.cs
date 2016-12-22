using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHelper
{
    public class EnumParser
    {
        public static T[] GetEnums<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new Exception("Such type wasnt expecte, expected ENUM");

            var array = Enum.GetValues(typeof(T));
            int lenght = array.Length;
            T[] values = new T[lenght];
            int i = 0;
            foreach (var temp in array)
            {
                values[i] = (T)temp;
                i++;
            }
            return values;
        }
    }
}

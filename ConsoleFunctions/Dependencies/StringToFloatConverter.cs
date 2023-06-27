using ConsoleFunctions.Dependencies.Interfaces;
using static ConsoleFunctions.Console_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFunctions.Dependencies
{
    public class StringToFloatConverter : ConverterBase<float>, IConverter<float, string>
    {
        

        #region Ctor

        public StringToFloatConverter(Func<float,bool> addCondition = null) : base(addCondition)
        {            
        }

        #endregion

        public bool Convert(string input, out float output)
        {
            var r =  float.TryParse(input, out output);

            if (!r)
            {
                PrintMessage("Wrong Input! Input float number", ConsoleColor.Red);
            }

            r = m_addCondition?.Invoke(output) ?? r;

            return r;
        }
    }
}

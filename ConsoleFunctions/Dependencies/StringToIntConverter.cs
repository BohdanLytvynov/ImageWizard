using ConsoleFunctions.Dependencies.Interfaces;
using static ConsoleFunctions.Console_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFunctions.Dependencies
{
    public class StringToIntConverter : ConverterBase<int>, IConverter<int, string>
    {
        #region Ctor
        public StringToIntConverter(Func<int, bool> addCondition = null):base(addCondition)
        {

        }
        #endregion

        public bool Convert(string input, out int output)
        {
            var r = int.TryParse(input, out output);

            if (!r)
            {
                PrintMessage("Wrong Input!!", ConsoleColor.Red);
            }

            r = m_addCondition?.Invoke(output) ?? r;

            return r;
        }
    }
}

using System;
using static ConsoleFunctions.Console_Functions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleFunctions.Dependencies.Interfaces;

namespace ConsoleFunctions.Dependencies
{
    public class StringToByteConverter : ConverterBase<byte>, IConverter<byte, string>
    {
        public StringToByteConverter(Func<byte, bool> addCondition = null) : base(addCondition)
        {
        }

        public bool Convert(string input, out byte output)
        {
            var r = byte.TryParse(input, out output);

            if (!r)
            {
                PrintMessage("Wrong Input! Input float number", ConsoleColor.Red);
            }

            r = m_addCondition?.Invoke(output) ?? r;

            return r;
        }
    }
}

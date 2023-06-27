using ConsoleFunctions.Dependencies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFunctions.Dependencies
{
    public class StringToBoolConverter : IConverter<bool?, string>
    {
        public bool? Convert(string input)
        {
            if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (input.Equals("N", StringComparison.OrdinalIgnoreCase))
                return true;

            else
                return null;
        }
    }
}

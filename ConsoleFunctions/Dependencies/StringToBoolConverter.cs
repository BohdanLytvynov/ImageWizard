using ConsoleFunctions.Dependencies.Interfaces;
using static ConsoleFunctions.Console_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFunctions.Dependencies
{
    public class StringToBoolConverter : IConverter<bool, string>
    {
        public bool Convert(string input, out bool output)
        {
            output = false;

            if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                output = true;
                return true;
            }
            else if (input.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                output= false;
                return true;
            }
            else
            {
                PrintMessage("Wrong Input!!! Write N or Y!", ConsoleColor.Red);
            }
            
            return false; 
           
        }
    }
}

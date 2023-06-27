using ConsoleFunctions.Dependencies.Interfaces;
using static ConsoleFunctions.Console_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFunctions.Dependencies
{
    public class NullableBoolValidator : IValidator<bool?>
    {
        public bool Validate(bool? Tin)
        {
            if (Tin == null)
            {
                PrintMessage("Wrong Input!!!", ConsoleColor.Red);

                return false;                
            }
            else
            {
                return true;
            }
        }       
    }
}

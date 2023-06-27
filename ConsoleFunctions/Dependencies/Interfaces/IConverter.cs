using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFunctions.Dependencies.Interfaces
{
    public interface IConverter<Tout, Tin>
    {
        bool Convert(Tin input, out Tout output);
    }
}

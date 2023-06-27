using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFunctions.Dependencies
{
    public class ConverterBase<TiN>
    {
        #region Fields
        protected Func<TiN, bool> m_addCondition;
        #endregion

        #region Ctor

        public ConverterBase(Func<TiN, bool> addCondition = null)
        {
            m_addCondition = addCondition;
        }

        #endregion
    }
}

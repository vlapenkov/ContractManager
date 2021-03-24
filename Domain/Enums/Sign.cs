using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enums
{
    /// <summary>
    /// ЗнакВхождения
    /// </summary>
    public enum Sign
    {
        [Description("-")]
        Minus = -1,

        [Description("+")]
        Plus = 1
    }
}

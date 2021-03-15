using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public interface IPeriodEntity
    {
        DateTime SDate { get;  }
        DateTime? EDate { get;  }
    }
}

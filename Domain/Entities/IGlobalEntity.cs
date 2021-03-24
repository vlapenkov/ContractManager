using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Для всех обмениваемых в рамках микросервисов сущностей guid один
    /// </summary>
   public interface IGlobalEntity
    {
         Guid Guid { get;  }
    }
}

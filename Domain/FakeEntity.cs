using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// Сущность нужна для проверки работы Domain Events
    /// </summary>
   public class FakeEntity: BaseEntity
    {
        public string Name { get; set; }

        public int ContractId { get; set; }
    }
}

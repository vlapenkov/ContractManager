using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Регион (надо не создавать а синхронизировать с другими системами)
    /// </summary>
   public class RfSubject: BaseEntity
    {
        public string Name { get; private set; }

        /// <summary>
        /// Код АТС
        /// </summary>
        public string Code { get; private set; }

        private RfSubject() {}
        public RfSubject(int id,string name, string code):this(name,code) {
            this.Id = id;            
        }
        public RfSubject(string name, string code) {
            this.Name = name;
            this.Code = code;
        }

    }
}

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
        /// Код региона из классификатора
        /// </summary>
        public string Code { get; private set; }
        /// <summary>
        /// Код АТС
        /// </summary>
        public string CodeAts { get; private set; }

        private RfSubject() {}
        public RfSubject(int id,string name, string code, string codeAts):this(name,code,codeAts) {
            this.Id = id;            
        }
        public RfSubject(string name, string code, string codeAts) {
            this.Name = name;
            this.Code = code;
            this.CodeAts = codeAts;
        }

    }
}

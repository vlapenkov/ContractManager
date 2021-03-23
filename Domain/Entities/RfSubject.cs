using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Регион (внешняя сущность из другой TarifManager)
    /// </summary>
   public class RfSubject: BaseEntity , IGlobalEntity
    {
        [Required]
        public string Name { get; private set; }

        /// <summary>
        /// Код региона из классификатора
        /// </summary>
        [Required]
        public string Code { get; private set; }
        /// <summary>
        /// Код АТС
        /// </summary>
        /// 
        
        [Required]
        public string CodeAts { get; private set; }

        public Guid Guid { get; private set; }

        private RfSubject() {}

        public RfSubject(Guid guid,string name, string code, string codeAts) {
            this.Guid = guid;
            this.Name = name;
            this.Code = code;
            this.CodeAts = codeAts;
        }
        public RfSubject(int id, Guid guid, string name, string code, string codeAts): this (guid, name, code, codeAts) {
            this.Id = id;
        }

    }
}

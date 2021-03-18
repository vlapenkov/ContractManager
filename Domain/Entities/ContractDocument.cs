using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public abstract class ContractDocument: BaseEntity
    {
        protected ContractDocument() { }
        public ContractDocument(string documentNumber, DateTime signDate, DateTime sActionDate)
        {
            this.DocumentNumber = documentNumber;
            this.SignDate = signDate;
            this.SActionDate = sActionDate;
            this.CreatedAt = DateTime.Now;
        }
        public DateTime CreatedAt { get; protected set; }
        public string CreatedBy { get; protected set; }
        public string DocumentNumber { get; private set; }
        public DateTime SignDate { get; protected set; }
        public DateTime SActionDate { get; protected set; }
        public DateTime? EActionDate { get; protected set; }
    

    }
}

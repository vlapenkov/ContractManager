using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SubContract: ContractDocument
    {        
        public int ContractDocumentId { get;  }
        public Contract Contract { get; }


        protected SubContract() { }
        public SubContract(int contractDocumentId, string documentNumber, DateTime signDate, DateTime sActionDate)
            : base(documentNumber, signDate, sActionDate)
        {
            ContractDocumentId = contractDocumentId;
        }

    }
}

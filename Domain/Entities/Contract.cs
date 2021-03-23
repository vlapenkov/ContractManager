using Domain.Entities;
using Domain.Enums;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Contract : ContractDocument
    {
        public ContractKind ContractKind { get; private set; } = ContractKind.EnergySupply;

        // todo: реализовать наименование договора и тип договора
         public string ContractName { get;  }
         public ContractType ContractType { get;}

        public virtual ICollection<BillObject> BillObjects { get; private set; } = new HashSet<BillObject>();
        public virtual ICollection<ContractParticipant> ContractParticipants { get; private set; } = new HashSet<ContractParticipant>();

        public virtual ICollection<SubContract> SubContracts { get; private set; } = new HashSet<SubContract>();


        private Contract() { }
        public Contract(string documentNumber, DateTime signDate, DateTime sActionDate, ContractKind contractKind, List<ContractParticipant> contractParticipants)
            :base(documentNumber, signDate, sActionDate)
        {
            if (contractParticipants.Count() != 2) throw new Exception("В договоре должны быть 2 стороны");            
            ContractKind = contractKind;
            ContractParticipants = contractParticipants;
        }


        public BillObject AddBillObject(BillObject billObject)
        {
            if (BillObjects.Any(a => a.Id == billObject.Id))
            {
                throw new ArgumentException("Cannot add duplicate appointment to schedule.", "appointment");
            }
            BillObjects.Add(billObject);
          
            return billObject;
        }




    }

}

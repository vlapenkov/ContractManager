using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Contract : BaseEntity
    {
        public ContractKind ContractKind { get; private set; }
        public DateTime SDate { get; private set; }
        
        // public DateTime ContractName { get; private set; }


        private readonly List<BillObject> _billObjects = new List<BillObject>();
        public virtual IReadOnlyCollection<BillObject> BillObjects => _billObjects;

        private readonly List<ContractParticipant> _participants = new List<ContractParticipant>();
        public virtual IReadOnlyCollection<ContractParticipant> ContractParticipants => _participants;

        protected Contract()
        {
            _billObjects = new List<BillObject>();

        }

        public Contract(DateTime sDate, ContractKind contractKind, List<ContractParticipant> participants):this()
        {
            if (participants.Count() != 2) throw new Exception("В договоре должны быть 2 стороны");
            SDate = sDate;
            ContractKind = contractKind;
            _participants = participants;
        }


        public BillObject AddBillObject(BillObject billObject)
        {
            if (_billObjects.Any(a => a.Id == billObject.Id))
            {
                throw new ArgumentException("Cannot add duplicate appointment to schedule.", "appointment");
            }
            _billObjects.Add(billObject);
            AddDomainEvent(new BillObjectAddedEvent(billObject,this));

            return billObject;
        }




    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class ContractParticipant : BaseEntity
    {
        public ParticipantType ParticipantType { get; private set; }

        public Organization Organization { get; private set; }

        public int ContractId { get; private set; }


        private ContractParticipant() { 
        }
        public ContractParticipant(ParticipantType participantType, Organization organization)
        {
            ParticipantType = participantType;
            Organization = organization;
        }
    }
}

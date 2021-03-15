using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
   public class BillObjectAddedEvent    
         : INotification
    {
        public BillObject BillObject { get; private set; }

        public Contract Contract { get; private set; }

        public BillObjectAddedEvent(BillObject billObject, Contract contract)
        {
            BillObject = billObject;
            Contract = contract;
        }
    }
}


using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class BillObject :BaseEntity
    {

        private BillObject() { }
        public string Name { get; private set; }
        public int ContractId { get; private set; }

        public RfSubject RfSubject { get; private set; }
        
        public int RfSubjectId { get; }

        public BillObject( string name, RfSubject rfSubject)
        {          
            Name = name;
            RfSubject = rfSubject;
        }

        private readonly List<BillObjectToEnergyLinkObject> _billObjectsToEnergyLinkObjects = new List<BillObjectToEnergyLinkObject>();
        public virtual IReadOnlyCollection<BillObjectToEnergyLinkObject> BillObjectsToEnergyLinkObjects => _billObjectsToEnergyLinkObjects;

        public void AddEnergyLinkObject(EnergyLinkObject elo, DateTime sDate, DateTime? eDate=null)
        {
            var link = new BillObjectToEnergyLinkObject(this, elo, sDate, eDate);
            _billObjectsToEnergyLinkObjects.Add(link);
        }

        public void DisableEnergyLinkObject(int eloId, DateTime eDate)
        {
           var link= this.BillObjectsToEnergyLinkObjects.First(bo => bo.BillObjectId == this.Id && bo.EnergyLinkObjectId == eloId);
            link.SetEDate( eDate);
            //var link = new BillObjectToEnergyLinkObject(this, elo, sDate, eDate);
            //_billObjectsToEnergyLinkObjects.Add(link);
        }


    }
}

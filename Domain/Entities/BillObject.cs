using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// Объект расчета
    /// </summary>
   public class BillObject :BaseEntity , IGlobalEntity
    {

        private BillObject() { }

        [Required]
        public string Name { get; private set; }
        public int ContractId { get; private set; }

        public RfSubject RfSubject { get; private set; }
        
        public int RfSubjectId { get; }

        /// <summary>
        /// Объект расчета относится к изолированной территории
        /// </summary>
        public bool IsIsolation { get; }

        public Guid Guid { get; private set; }

        public BillObject( string name, RfSubject rfSubject)
        {
            Guid = Guid.NewGuid();
            Name = name;
            RfSubject = rfSubject;            
        }

        //private readonly List<BillObjectToEnergyLinkObject> _billObjectsToEnergyLinkObjects = new List<BillObjectToEnergyLinkObject>();
        public virtual ICollection<BillObjectToEnergyLinkObject> BillObjectsToEnergyLinkObjects { get; private set; } = new HashSet<BillObjectToEnergyLinkObject>();

        public void AddEnergyLinkObject(EnergyLinkObject elo, DateTime sDate, DateTime? eDate=null)
        {
            var link = new BillObjectToEnergyLinkObject(this, elo, sDate, eDate);
            BillObjectsToEnergyLinkObjects.Add(link);
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

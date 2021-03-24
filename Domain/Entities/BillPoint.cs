using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BillPoint:BaseEntity , IGlobalEntity
    {
        private BillPoint() { }

        
        public string Name { get; private set; }
        public Guid Guid { get; private set; }

        public BillPoint(Guid guid,  string name)
        {
            Guid = guid;
            Name = name;            
        }

        public BillPoint(int id, Guid guid, string name): this(guid, name)
        {
            Id = id;
        }

        
        public virtual IReadOnlyCollection<EnergyLinkObjectToBillPoint> EnergyLinkObjectsToBillPoints { get; private set; }  = new HashSet<EnergyLinkObjectToBillPoint>();

        public virtual IReadOnlyCollection<BillSideToBillPoint> BillSideToBillPoints { get; private set; } = new HashSet<BillSideToBillPoint>();

        
    }
}

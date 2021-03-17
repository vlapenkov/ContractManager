using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BillPoint:BaseEntity
    {
        private BillPoint() { }
        public string Name { get; private set; }

        public int  TnePointId { get; private set; }

        public BillPoint(int id, string name, int tneId)
        {
            Id = id;
            Name = name;
            TnePointId = tneId;
        }

        //private readonly List<EnergyLinkObjectToBillPoint> _energyLinkObjectsToBillPoints = new List<EnergyLinkObjectToBillPoint>();
        public virtual IReadOnlyCollection<EnergyLinkObjectToBillPoint> EnergyLinkObjectsToBillPoints { get; set; }  = new List<EnergyLinkObjectToBillPoint>();

        public virtual IReadOnlyCollection<BillSideToBillPoint> BillSideToBillPoints { get; set; } = new List<BillSideToBillPoint>();
    }
}

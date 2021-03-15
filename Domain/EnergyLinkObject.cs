using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class EnergyLinkObject : BaseEntity
    {
        private EnergyLinkObject() { }
        public string Name { get; private set; }
        public EnergyLinkObject( string name)
        {          
            Name = name;
        }

        private readonly List<BillObjectToEnergyLinkObject> _billObjectsToEnergyLinkObjects = new List<BillObjectToEnergyLinkObject>();
        public virtual IReadOnlyCollection<BillObjectToEnergyLinkObject> BillObjectsToEnergyLinkObjects => _billObjectsToEnergyLinkObjects;

        private readonly List<EnergyLinkObjectToBillPoint> _energyLinkObjectsToBillPoints = new List<EnergyLinkObjectToBillPoint>();
        public virtual IReadOnlyCollection<EnergyLinkObjectToBillPoint> EnergyLinkObjectsToBillPoints => _energyLinkObjectsToBillPoints;


        public void AddBillPoint(int billPointId, DateTime sDate, DateTime? eDate = null)
        {
            var link = new EnergyLinkObjectToBillPoint(billPointId, this, sDate, eDate);
            _energyLinkObjectsToBillPoints.Add(link);
        }

        public void AddParameter(int billPointId, BillParamType paramType, int value)
        {
            var link1 = EnergyLinkObjectsToBillPoints.FirstOrDefault(link => link.BillPointId == billPointId /*&& link.EnergyLinkObjectId == this.Id*/);

            if (link1 == null) throw new Exception("Не найдена связь");
            link1.BillParams.Add(new BillParam(paramType, value));
        }

        
        //public void DisableEnergyLinkObject(int eloId, DateTime eDate)
        //{
        //    var link = this.EnergyLinkObjectsToBillPoints.First(bo => bo. == this.Id && bo.EnergyLinkObjectId == this.Id);
        //    link.SetEDate(eDate);
        //    //var link = new BillObjectToEnergyLinkObject(this, elo, sDate, eDate);
        //    //_billObjectsToEnergyLinkObjects.Add(link);
        //}
        
    }
}

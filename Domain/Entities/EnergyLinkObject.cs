using Domain.Entities;
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

        /// <summary>
        /// Добавляет ссылку к точке поставки с определенной даты
        /// </summary>
        /// <param name="billPointId">id точки поставки</param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        public void AddBillPoint(int billPointId, DateTime sDate, DateTime? eDate = null)
        {
            var link = new EnergyLinkObjectToBillPoint(billPointId, this, sDate, eDate);
            _energyLinkObjectsToBillPoints.Add(link);
        }

        /// <summary>
        /// Удаляет ссылку к точке поставки с определенной даты
        /// </summary>
        /// <param name="billPointId">id точки поставки</param>
        /// <param name="eDate"></param>
        public void DisableLink(int billPointId, DateTime eDate)
        {
            var link1 = EnergyLinkObjectsToBillPoints.FirstOrDefault(link => link.BillPointId == billPointId);
            link1.SetEDate(eDate);

        }

        public void AddParameter(int billPointId, int paramType, int value)
        {
            var link1 = EnergyLinkObjectsToBillPoints.FirstOrDefault(link => link.BillPointId == billPointId );

            if (link1 == null) throw new Exception("Не найдена связь");
            link1.BillParams.Add(new BillParam(paramType, value));
        }


        

    }
}

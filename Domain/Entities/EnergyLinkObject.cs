using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Domain
{
    public class EnergyLinkObject : BaseEntity
    {
        

        [Required]
        [StringLength(255)]
        public string Name { get; private set; }

        private EnergyLinkObject() { }
        public EnergyLinkObject( string name)
        {          
            Name = name;
        }

        
        public virtual ICollection<BillObjectToEnergyLinkObject> BillObjectsToEnergyLinkObjects { get; private set; } = new List<BillObjectToEnergyLinkObject>();
        public virtual ICollection<EnergyLinkObjectToBillPoint> EnergyLinkObjectsToBillPoints { get; private set; } = new List<EnergyLinkObjectToBillPoint>();
        public virtual ICollection<BillSideToBillPoint> BillSideToBillPoints { get; private set; } = new List<BillSideToBillPoint>();

        /// <summary>
        /// Добавляет ссылку к точке поставки с определенной даты
        /// </summary>
        /// <param name="billPointId">id точки поставки</param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        public void AddBillPoint(int billPointId, DateTime sDate, DateTime? eDate = null)
        {
            var link = new EnergyLinkObjectToBillPoint(billPointId, this, sDate, eDate);
            EnergyLinkObjectsToBillPoints.Add(link);
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


        public void AddParameter(int billPointId, BillParamType paramType, int value)
        {
            //
            var link = EnergyLinkObjectsToBillPoints.FirstOrDefault(elo2bp => elo2bp.BillPointId == billPointId );

            if (link == null) throw new Exception("Не найдена связь");

            if (link.BillParams.Any(x => x.BillParamType == paramType))
                throw new Exception($"Параметр {paramType} уже существует") ;

            link.BillParams.Add(new BillParam(paramType, value));
        }


        

    }
}

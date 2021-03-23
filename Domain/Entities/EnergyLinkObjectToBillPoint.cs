using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{

    /// <summary>
    ///  связь ообъекта электрической связи с точкой поставки
    /// </summary>
    public class EnergyLinkObjectToBillPoint :BaseEntity, IPeriodEntity
    {
        public BillPoint BillPoint { get; private set; }

        public EnergyLinkObject EnergyLinkObject { get; private set; }
    
        public virtual IList<BillParam> BillParams { get; private set; } = new List<BillParam>();


        public int EnergyLinkObjectId { get; private set; }
        public int BillPointId { get; private set; }

        public DateTime SDate { get; private set; }
        public DateTime? EDate { get; private set; }

        public void SetEDate(DateTime eDate) {
            this.EDate = eDate;
        }

        private EnergyLinkObjectToBillPoint() { }

        public EnergyLinkObjectToBillPoint(
            BillPoint billPoint,
            EnergyLinkObject energyLinkObject,
            DateTime sDate,
            DateTime? eDate)
        {
            BillPoint = billPoint;
            EnergyLinkObject = energyLinkObject;
            SDate = sDate;
            EDate = eDate;

        }

        public EnergyLinkObjectToBillPoint(
            int billPointId,
            EnergyLinkObject energyLinkObject,
            DateTime sDate,
            DateTime? eDate)
        {
            BillPointId = billPointId;
            EnergyLinkObject = energyLinkObject;
            SDate = sDate;
            EDate = eDate;
        }


    }
}

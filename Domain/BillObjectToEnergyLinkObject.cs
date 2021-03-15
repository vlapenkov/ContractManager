using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BillObjectToEnergyLinkObject
    {
        public BillObject BillObject { get; private set; }

        public EnergyLinkObject EnergyLinkObject { get; private set; }
        public int EnergyLinkObjectId { get; private set; }
        public int BillObjectId { get; private set; }

        public DateTime SDate { get; private set; }
        public DateTime? EDate { get; private set; }

        public void SetEDate(DateTime eDate) {
            this.EDate = eDate;
        }
        public BillObjectToEnergyLinkObject(
            int billObjectId, 
            int energyLinkObjectId, 
            DateTime sDate, 
            DateTime? eDate)
        {
            BillObjectId = billObjectId;
            EnergyLinkObjectId = energyLinkObjectId;
            SDate = sDate;
            EDate = eDate;

        }

        public BillObjectToEnergyLinkObject(
            BillObject billObject,
            EnergyLinkObject energyLinkObject,
            DateTime sDate,
            DateTime? eDate)
        {
            BillObject = billObject;
            EnergyLinkObject = energyLinkObject;
            SDate = sDate;
            EDate = eDate;

        }
    }
}

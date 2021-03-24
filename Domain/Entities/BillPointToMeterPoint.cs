using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class BillPointToMeterPoint
    {
        public BillPointToMeterPoint(int billPointId, int meterPointId, DateTime sDate, DateTime? eDate)
        {
            BillPointId = billPointId;
            MeterPointId = meterPointId;
            SDate = sDate;
            EDate = eDate;
        }

        public BillPoint BillPoint { get; private set; }

        public MeterPoint MeterPoint { get; private set; }
        public int BillPointId { get; private set; }
        public int MeterPointId { get; private set; }


        public DateTime SDate { get; private set; }
        public DateTime? EDate { get; private set; }

        public void SetEDate(DateTime eDate)
        {
            this.EDate = eDate;
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Связка региона и зоны (ценовая и неценовая)
    /// </summary>
    public class RfSubjectToOremZone : IPeriodEntity
    {
        public RfSubject RfSubject { get; private set; }

        public OremZone OremZone { get; private set; }
        public int RfSubjectId { get; private set; }
        public int OremZoneId { get; private set; }

        [DataType(DataType.Date)]
        public DateTime SDate { get; private set; }

        [DataType(DataType.Date)]
        public DateTime? EDate { get; private set; }

        public void SetEDate(DateTime eDate)
        {
            this.EDate = eDate;
        }
        public RfSubjectToOremZone(
            int rfSubjectId,
            int oremZoneId,
            DateTime sDate,
            DateTime? eDate)
        {
            RfSubjectId = rfSubjectId;
            OremZoneId = oremZoneId;
            SDate = sDate;
            EDate = eDate;

        }
    }
}

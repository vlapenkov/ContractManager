using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Определение, какая сторона рассчетная в конкретном периоде
    /// </summary>
   public class BillSideToBillPoint
    {
        public BillPoint BillPoint { get; private set; }

        public EnergyLinkObject EnergyLinkObject { get; private set; }

        public int EnergyLinkObjectId { get; private set; }
        public int BillPointId { get; private set; }        

        public DateTime SDate { get; private set; }
        public DateTime? EDate { get; private set; }

        public TypeSide TypeSide { get; private set; }
    }
}

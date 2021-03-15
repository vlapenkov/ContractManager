using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
  public class BillParam
    {
        public EnergyLinkObjectToBillPoint EnergyLinkObjectToBillPoint { get; private set; }

        public BillParamType BillParamType { get; private set; }
        public int EnergyLinkObjectToBillPointId { get; private set; }
        public int BillParamTypeId { get; private set; }

        public int Value { get; private set; }

        private BillParam() { }
        public BillParam(
         //   EnergyLinkObjectToBillPoint energyLinkObjectToBillPoint, 
            BillParamType billParamType, 
            int value)
        {
         //   EnergyLinkObjectToBillPoint = energyLinkObjectToBillPoint;
            BillParamType = billParamType;
            Value = value;
        }

    }
}

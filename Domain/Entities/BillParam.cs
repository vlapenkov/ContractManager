using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
  public class BillParam
    {
        public EnergyLinkObjectToBillPoint EnergyLinkObjectToBillPoint { get; private set; }

       // public BillParamType BillParamType { get; private set; }
        public int EnergyLinkObjectToBillPointId { get; private set; }
        public int BillParamTypeId { get; private set; }

        //public BillParamTypeEnum BillParamTypeEnum { get; private set; } = BillParamTypeEnum.PriceCategory;

        public int Value { get; private set; }

        private BillParam() { }
        public BillParam(
            //   EnergyLinkObjectToBillPoint energyLinkObjectToBillPoint, 
            
            int billParamTypeId, 
            int value)
        {
            //   EnergyLinkObjectToBillPoint = energyLinkObjectToBillPoint;
            BillParamTypeId = billParamTypeId;
               Value = value;
        }

    }
}

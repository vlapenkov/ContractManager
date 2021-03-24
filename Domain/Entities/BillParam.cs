using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// Параметры связи точки поставки и точки измерения по периоду
    /// </summary>
  public class BillParam
    {
        public EnergyLinkObjectToBillPoint EnergyLinkObjectToBillPoint { get; private set; }
       
        public int EnergyLinkObjectToBillPointId { get; private set; }
        
        public BillParamType BillParamType { get; private set; }
        public int Value { get; private set; }

        private BillParam() { }
        public BillParam(
        
            BillParamType billParamType, 
            int value)
        {        
            BillParamType = billParamType;
            Value = value;
        }

    }
}

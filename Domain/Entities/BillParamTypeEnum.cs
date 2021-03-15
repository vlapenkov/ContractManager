using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BillParamTypeEnum
        : Enumeration
    {
        public static BillParamTypeEnum PriceCategory => new BillParamTypeEnum(1,"Ценовая категория");
        public static BillParamTypeEnum VoltageTarifLevel => new BillParamTypeEnum(2, "Тарифный уровень напряжения");
        public static BillParamTypeEnum Sign => new BillParamTypeEnum(3,"Знак вхождения");
        public static BillParamTypeEnum VolumeCategory => new BillParamTypeEnum(4,"Категория мощности");

        public BillParamTypeEnum(int id, string name)
            : base(id, name)
        {
        }
    }
}

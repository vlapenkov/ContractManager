using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Entities
{
   /// <summary>
   /// Параметры типов связи объекта эл. связи и ТП
   /// </summary>
    public enum BillParamType
    {
        [Description("Ценовая категория")]
        PriceCategory=1,

        [Description("Тарифный уровень напряжения")]
        VoltageTarifLevel,

        [Description("Знак вхождения")]
        Sign,

        [Description("Категория мощности")]
        VolumeCategory
    }
}

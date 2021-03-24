using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enums
{
    public enum ContractKind
    {
        [Description("Договор энергоснабжения")]
        EnergySupply = 1,

        [Description("Договор купли продажи электроэнергии")]
        Sale,

        [Description("Договор оказания услуг по передаче электроэнергии")]
        EnergyTransfer,

        [Description("Договор купли продажи в целях компенсации потерь")]
        LossCompensation,

        [Description("Розничная генерация")]
        RetailGeneration
    }
}

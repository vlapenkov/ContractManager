using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enums
{
    public enum ParticipantType
    {
        [Description("Продавец электроэнергии")]
        Supplier = 1,
        [Description("Покупатель электроэнергии")]
        Customer,
        [Description("Население")]
        Population,
        [Description("Организация, оказывающая услуги по передаче")]
        Network

    }
}

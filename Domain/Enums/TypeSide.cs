using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Enums
{
    /// <summary>
    /// Тип стороны ОИП/РИП
    /// </summary>
    [JsonConverter (typeof(StringEnumConverter))]
   public enum TypeSide
    {
        [EnumMember(Value ="ОИП")]
        OIP = 1,

        [EnumMember(Value = "РИП")]
        RIP = 2
    }
}

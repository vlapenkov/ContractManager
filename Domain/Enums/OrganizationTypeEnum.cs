using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    [Flags]
    public enum OrganizationTypeEnum
    {
        /// <summary>
        /// не является ни одной из нижеперечисленных
        /// </summary>
        
        None = 0x0,
        /// <summary>
        /// Сбытовая
        /// </summary>
        SalesService = 0x1,

        /// <summary>
        /// Сетевая
        /// </summary>
        WireService =0x2,

        /// <summary>
        /// Потребитель
        /// </summary>
        Consumer =0x4,

        /// <summary>
        /// ГТП
        /// </summary>
        GTP = 0x8
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Зоны ценовые и неценовые (управляется в TariffManager)
    /// </summary>
    public class OremZone : BaseEntity, IGlobalEntity
    {
        public Guid Guid { get; private set; }

        [Required]
        [StringLength(255)]
        public string Name { get; private set; }

        public int TimeOffset { get; private set; }
        /// <summary>
        /// Ценовая или нет
        /// </summary>
        public bool IsRate { get; private set; }

        /// <summary>
        /// Изолированная или нет (Сахалин/Калининград)
        /// </summary>
        public bool IsIsolated { get; private set; }
    }
}

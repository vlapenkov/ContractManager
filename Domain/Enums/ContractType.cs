using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enums
{
    /// <summary>
    /// Тип договора
    /// </summary>
   public enum ContractType
    {
        /// <summary>
        /// Неизвестный
        /// </summary>
        [Description("Неизвестный")]
        Unknown =0,

        /// <summary>
        /// Доходный
        /// </summary>
        [Description("Доходный")]
        Income = 1,

        /// <summary>
        /// Расходный
        /// </summary>
        [Description("Расходный")]
        Expense = 2,

        /// <summary>
        /// Контроллируемый
        /// </summary>
        [Description("Контроллируемый")]
        Controlled
    }
}

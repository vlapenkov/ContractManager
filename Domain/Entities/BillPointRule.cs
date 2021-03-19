using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Правило вхождения точки поставки
    /// </summary>
   public class BillPointRule :BaseEntity
    {
        public string Description { get; private set; }

        /// <summary>
        /// Тип договора (контроллируемый/доходный/расходный)
        /// </summary>
        public ContractType ContractType { get; private set; }

        /// <summary>
        /// Вид договора
        /// </summary>
        public ContractKind ContractKind { get; private set; }

        /// <summary>
        /// Тип стороны 1 в договоре 
        /// </summary>
        public OrganizationTypeEnum OrganizationTypeSide1 { get; private set; }

        /// <summary>
        /// Тип стороны 2 в договоре
        /// </summary>
        public OrganizationTypeEnum OrganizationTypeSide2 { get; private set; }

        public Sign EntrySign { get; private set; }

        private BillPointRule() { }
       

        public BillPointRule(
            string description, 
            ContractType contractType, 
            ContractKind contractKind, 
            OrganizationTypeEnum organizationTypeSide1, 
            OrganizationTypeEnum organizationTypeSide2, 
            Sign entrySign)
        {
            Description = description;
            ContractType = contractType;
            ContractKind = contractKind;
            OrganizationTypeSide1 = organizationTypeSide1;
            OrganizationTypeSide2 = organizationTypeSide2;
            EntrySign = entrySign;
        }
    }
}

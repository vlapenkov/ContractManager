using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    /// <summary>
    /// Организация - внешняя сущность для ContractManager
    /// </summary>
    public class Organization : BaseEntity, IGlobalEntity
    {
        private Organization() { }

        [Required]
        [StringLength(255)]
        public string ShortName { get; private set; }

        [Required]
        [StringLength(1024)]
        public string LongName { get; private set; }
        public int? AcsId { get; private set; }

        public OrganizationTypeEnum OrganizationType {get; private set;}

        public Organization ParentOrganization { get; private set; }
        public int? ParentOrganizationId { get; private set; }
        public Guid Guid { get;  private set; }

        public ICollection<Organization> ChildOrganizations { get; private set; } = new HashSet<Organization>();

        public Organization( Guid guid, string shortName, string longName, OrganizationTypeEnum organizationType)
        {          
            Guid = guid;
            ShortName = shortName;
            LongName = longName;
            OrganizationType = organizationType;
        }
        public Organization(int id ,Guid guid, string shortName, string longName, OrganizationTypeEnum organizationType):this
            ( guid,  shortName,  longName,  organizationType)
        {
            Id = id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    /// <summary>gdjey
    /// Точка измерения (не хранится)
    /// </summary>
    public class MeterPoint : BaseEntity, IGlobalEntity
    {
        public MeterPoint(string name, Guid guid)
        {
            Name = name;
            Guid = guid;
        }

        public MeterPoint(int id, Guid guid, string name )
        {
            Id = id;
            Name = name;
            Guid = guid;
        }

        [Required]
        public string Name { get; private set; }
        public Guid Guid { get; private set; }
    }
}

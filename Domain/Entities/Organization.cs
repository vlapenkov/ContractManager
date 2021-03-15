using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Organization :BaseEntity
    {
        private Organization() { }
        public string Name { get; private set; }
        public Organization(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

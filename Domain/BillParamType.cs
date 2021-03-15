using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class BillParamType:BaseEntity
    {
        private BillParamType() { }
        public string Name { get; private set; }
        public BillParamType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

﻿using System.Collections.Generic;

namespace Contracts
{
    public class EnergyLinkObjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<int> BillPoints { get; set; }
    }
}
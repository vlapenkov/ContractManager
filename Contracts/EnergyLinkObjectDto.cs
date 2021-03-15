using System.Collections.Generic;

namespace Contracts
{
    public class EnergyLinkObjectDto
    {
        public string Name { get; set; }

        public ICollection<BillPointDto> BillPoints { get; set; }
    }
}
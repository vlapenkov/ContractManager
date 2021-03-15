using System.Collections.Generic;

namespace Contracts
{
    public class BillObjectDto
    {
        public string Name { get; set; }
        public ICollection<EnergyLinkObjectDto> EnergyLinkObjects { get; set; }
    }
}
using System.Collections.Generic;

namespace Contracts
{
    public class BillObjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EnergyLinkObjectDto> EnergyLinkObjects { get; set; }
    }
}
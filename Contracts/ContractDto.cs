using System;
using System.Collections.Generic;

namespace Contracts
{
    public class ContractDto
    {
        public ICollection<BillObjectDto> BillObjects { get; set; }
        public string Side1 { get; set; }
        public string Side2 { get; set; }
    }
}

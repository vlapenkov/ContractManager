using System;
using System.Collections.Generic;

namespace Contracts
{
    public class ContractDto
    {
        public ICollection<BillObjectDto> BillObjects { get; set; }
        public string Side1 { get; set; }
        public string Side2 { get; set; }

        public ICollection<SubContractDto> SubContracts { get; set; }
    }

    public class SubContractDto
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public DateTime SDate { get; set; }

    }
}

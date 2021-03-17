using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
  public  class ContractRepository
    {
        ContractsDbContext _db;

        public ContractRepository(ContractsDbContext db)
        {
            _db = db;
        }

        
        public Contract GetContract(int id)
        {

            var result = _db.Contracts
               //.Include(contract => contract.ContractKind)
                .Include(contract => contract.ContractParticipants)
                   // .ThenInclude(cp => cp.ParticipantType)
                .Include(cp => cp.ContractParticipants)
                    .ThenInclude(cp => cp.Organization)
                .Include(contract => contract.BillObjects)
                 .ThenInclude(bo => bo.BillObjectsToEnergyLinkObjects)
                 .ThenInclude(bo2elo => bo2elo.EnergyLinkObject)
                 .ThenInclude(bo2elo => bo2elo.EnergyLinkObjectsToBillPoints)
                 .ThenInclude(elotbp => elotbp.BillParams)
                // .ThenInclude(bp => bp.BillParamType)
                 .FirstOrDefault(x => x.Id == id);
            
            return result;
        }
    }
}

using Contracts;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsDataController : ControllerBase
    {
        ContractsDbContext _db;
        public ContractsDataController(ContractsDbContext db)
        {
            _db = db;
        }
       
        // GET api/<ContractsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DateTime curDate = DateTime.Now;
            var contract = _db.Contracts
                .Include(contract => contract.ContractKind)
                .Include(contract => contract.ContractParticipants)
                    .ThenInclude(cp => cp.ParticipantType)
                .Include(cp => cp.ContractParticipants)
                    .ThenInclude(cp => cp.Organization)                
                .Include(contract => contract.BillObjects)
                 .ThenInclude(bo => bo.BillObjectsToEnergyLinkObjects)
                 .ThenInclude(bo2elo => bo2elo.EnergyLinkObject)
                 .ThenInclude(bo2elo => bo2elo.EnergyLinkObjectsToBillPoints)
                 .ThenInclude(bo2elo => bo2elo.BillPoint)
                .FirstOrDefault(x => x.Id == id);


            var type1 = _db.ParticipantTypes.Find(1);
            var type2 = _db.ParticipantTypes.Find(2);

           var result = new ContractDto
            {

                Side1 = contract.ContractParticipants.Where(cp => cp.ParticipantType == type1).FirstOrDefault()?.Organization?.Name,
                Side2 = contract.ContractParticipants.Where(cp => cp.ParticipantType == type2).FirstOrDefault()?.Organization?.Name,
                BillObjects = contract.BillObjects.Select(bo => new BillObjectDto
                {Name = bo.Name,
                    EnergyLinkObjects =  bo.BillObjectsToEnergyLinkObjects
                  .Where(bo2Elo => bo2Elo.SDate <= curDate && (bo2Elo.EDate == null || bo2Elo.EDate > curDate))
                  .Select (elo=>new EnergyLinkObjectDto {
                      Name=elo.EnergyLinkObject.Name ,
                      BillPoints = elo.EnergyLinkObject.EnergyLinkObjectsToBillPoints.Where(bo2Elo => bo2Elo.SDate <= curDate && (bo2Elo.EDate == null || bo2Elo.EDate > curDate))
                  .Select(elo => new BillPointDto
                  {
                      Name = elo.BillPoint.Name
                  }).ToList()
                  }).ToList()
                }).ToList()
            };
            
            /*
            var boToElo = contract.BillObjects
                .SelectMany(bo => bo.BillObjectsToEnergyLinkObjects)
                .Where(bo2Elo => bo2Elo.SDate <= curDate && (bo2Elo.EDate == null || bo2Elo.EDate > curDate));
            */
            return Ok(result);
        }
    }
}

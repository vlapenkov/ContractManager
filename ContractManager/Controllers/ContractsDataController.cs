using Contracts;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContractManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsDataController : ControllerBase
    {
        ContractRepository _contractRepo;
        ContractsDbContext _db;
        public ContractsDataController(ContractsDbContext db, ContractRepository contractRepo)
        {
            _db = db;
            _contractRepo = contractRepo;
    }
       
        // GET api/<ContractsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DateTime curDate = DateTime.Now;
            var contract = _contractRepo.GetContract(1);
            //var contract = _db.Contracts
            //    .Include(contract => contract.ContractKind)
            //    .Include(contract => contract.ContractParticipants)
            //        .ThenInclude(cp => cp.ParticipantType)
            //    .Include(cp => cp.ContractParticipants)
            //        .ThenInclude(cp => cp.Organization)                
            //    .Include(contract => contract.BillObjects)
            //     .ThenInclude(bo => bo.BillObjectsToEnergyLinkObjects)
            //     .ThenInclude(bo2elo => bo2elo.EnergyLinkObject)
            //     .ThenInclude(bo2elo => bo2elo.EnergyLinkObjectsToBillPoints)
            //     .ThenInclude(bo2elo => bo2elo.BillPoint)
            //    .FirstOrDefault(x => x.Id == id);


            var type1 = _db.ParticipantTypes.Find(1);
            var type2 = _db.ParticipantTypes.Find(2);


            Expression<Func<IPeriodEntity, bool>> predicate = bo2Elo => bo2Elo.SDate <= curDate && (bo2Elo.EDate == null || bo2Elo.EDate > curDate);

           var result = new ContractDto
            {

                Side1 = contract.ContractParticipants.Where(cp => cp.ParticipantType == type1).FirstOrDefault()?.Organization?.Name,
                Side2 = contract.ContractParticipants.Where(cp => cp.ParticipantType == type2).FirstOrDefault()?.Organization?.Name,
                BillObjects = contract.BillObjects.Select(bo => new BillObjectDto
                {   Id= bo.Id,
                    Name = bo.Name,
                    EnergyLinkObjects =  bo.BillObjectsToEnergyLinkObjects
                .Where(bo2Elo =>/*true || */bo2Elo.SDate <= curDate && (bo2Elo.EDate == null || bo2Elo.EDate > curDate))
                .Select (elo=>new EnergyLinkObjectDto {
                    Id = elo.EnergyLinkObjectId,
                    Name =elo.EnergyLinkObject.Name ,
                    BillPoints = elo.EnergyLinkObject.EnergyLinkObjectsToBillPoints
                .Where(bo2Elo => /*true || */bo2Elo.SDate <= curDate && (bo2Elo.EDate == null || bo2Elo.EDate > curDate))
                .Select(elo=>elo.BillPointId)
                   .ToList()
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

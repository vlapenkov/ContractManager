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

            Expression<Func<IPeriodEntity, bool>> predicate = bo2Elo => bo2Elo.SDate <= curDate && (bo2Elo.EDate == null || bo2Elo.EDate > curDate);

            var result = new ContractDto
            {

                Side1 = contract.ContractParticipants.Where(cp => cp.ParticipantType == Domain.Enums.ParticipantType.Supplier).FirstOrDefault()?.Organization?.Name,
                Side2 = contract.ContractParticipants.Where(cp => cp.ParticipantType == Domain.Enums.ParticipantType.Customer).FirstOrDefault()?.Organization?.Name,
                BillObjects = contract.BillObjects.Select(bo => new BillObjectDto
                {
                    Id = bo.Id,
                    Name = bo.Name,
                    EnergyLinkObjects = bo.BillObjectsToEnergyLinkObjects
                .Where(bo2Elo =>/*true || */bo2Elo.SDate <= curDate && (bo2Elo.EDate == null || bo2Elo.EDate > curDate))
                .Select(elo => new EnergyLinkObjectDto
                {
                    Id = elo.EnergyLinkObjectId,
                    Name = elo.EnergyLinkObject.Name,
                    BillPoints = elo.EnergyLinkObject.EnergyLinkObjectsToBillPoints
               .Where(bo2Elo => /*true || */bo2Elo.SDate <= curDate && (bo2Elo.EDate == null || bo2Elo.EDate > curDate))
               .Select(elo => elo.BillPointId)
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
        //public IActionResult Get(int id)
        //{
        //    var request = from region in _db.RfSubjects
        //                  join bo in _db.BillObjects
        //                  on region.Id equals bo.b
        //}
}

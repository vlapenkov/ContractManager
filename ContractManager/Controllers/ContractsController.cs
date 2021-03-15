using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContractManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        ContractsDbContext _db;
        public ContractsController(ContractsDbContext db)
        {
            _db=db;
        }
        // GET: api/<ContractsController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _db.Contracts
                .Include(contract => contract.ContractKind)
                .Include(contract => contract.ContractParticipants)
                    .ThenInclude(cp=>cp.ParticipantType)
                .Include(cp => cp.ContractParticipants)
                    .ThenInclude(cp => cp.Organization)
                .Include(contract => contract.BillObjects)
                 .ThenInclude(bo => bo.BillObjectsToEnergyLinkObjects)
                 .ThenInclude(bo2elo => bo2elo.EnergyLinkObject);
            return Ok(result);
        }

        // GET api/<ContractsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DateTime curDate = DateTime.Now;
            var contract = _db.Contracts
                .Include(contract => contract.ContractKind)
                .Include(contract =>contract.BillObjects)
                 .ThenInclude(bo=>bo.BillObjectsToEnergyLinkObjects)
                 .ThenInclude(bo2elo=> bo2elo.EnergyLinkObject)
                .FirstOrDefault(x=>x.Id==id);

            var boToElo = contract.BillObjects
                .SelectMany(bo => bo.BillObjectsToEnergyLinkObjects)
                .Where(bo2Elo => bo2Elo.SDate <= curDate && (bo2Elo.EDate==null || bo2Elo.EDate > curDate));

            return Ok(new { Contract = contract, BO = boToElo });
        }

        /// <summary>
        /// Добавить новый договор
        /// </summary>
        [HttpPost("{organizationId1}/{organizationId2}")]
        public void Post( int organizationId1, int organizationId2)
        {
           var cKind1 = _db.ContractKinds.Find(1);
           var org1 = _db.Organizations.Find(organizationId1);
           var org2 = _db.Organizations.Find(organizationId2);
           var pt1 = _db.ParticipantTypes.Find(1);
            var pt2 = _db.ParticipantTypes.Find(2);

            var cp1 =new ContractParticipant(pt1, org1);
            var cp2 = new ContractParticipant(pt2, org2);

            List<ContractParticipant> participants = new List<ContractParticipant> { cp1, cp2 };
            var contract=  new Contract(DateTime.Now, cKind1, participants);
            _db.Contracts.Add(contract);
            _db.SaveChanges();
            
        }

        /// <summary>
        /// Добавить к договору только что созданный объект расчета
        /// </summary>
        /// <param name="contractId"></param>
        [HttpPut("createbo/{contractId}")]
        public async Task Put( int contractId )
        {

            var bo = new BillObject(DateTime.Now.ToString());
            _db.BillObjects.Add(bo);

            var contract = _db.Contracts
              //  .Include(contract => contract.ContractKind)
                .FirstOrDefault(x => x.Id == contractId);

            contract.AddBillObject(bo);
            await _db.SaveEntitiesAsync();
        }


        /// <summary>
        /// Добавить к договору предварительно созданный объект расчета
        /// </summary>
        /// <param name="id">id объекта</param>
        /// <param name="contractId">id договора</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] int contractId)
        {

            var bo = _db.BillObjects.Find(id);

            var contract = _db.Contracts
                .Include(contract => contract.ContractKind)
                .FirstOrDefault(x => x.Id == contractId);

            contract.AddBillObject(bo);
            _db.SaveChanges();
        }

        // DELETE api/<ContractsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContractManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        ContractsDbContext _db;
        ContractRepository _repo;
        public ContractsController(ContractsDbContext db, ContractRepository repo)
        {
            _db=db;
            _repo = repo;
        }
        

        // GET api/<ContractsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contract = _repo.GetContract(id);

            return Ok(contract);
        }

        /// <summary>
        /// Добавить новый договор
        /// </summary>
        [HttpPost("{organizationId1}/{organizationId2}")]
        public void Post(int organizationId1, int organizationId2)
        {
            //var cKind1 = _db.ContractKinds.Find(1);
            var org1 = _db.Organizations.Find(organizationId1);
            var org2 = _db.Organizations.Find(organizationId2);
            

            var cp1 = new ContractParticipant(ParticipantType.Supplier, org1);
            var cp2 = new ContractParticipant(ParticipantType.Customer, org2);

            List<ContractParticipant> participants = new List<ContractParticipant> { cp1, cp2 };
            var contract = new Contract("1",DateTime.Now.Date, DateTime.Now.Date, ContractKind.EnergySupply,  participants);
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
            var rf1 =_db.RfSubjects.Find(1);
            var bo = new BillObject(DateTime.Now.ToString(), rf1);
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

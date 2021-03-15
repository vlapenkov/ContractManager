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
    public class BillObjectController : ControllerBase
    {
        ContractsDbContext _db;
        ContractRepository _repo;
        public BillObjectController(ContractsDbContext db, ContractRepository repo)
        {
            _db=db;
            _repo = repo;
    }
        // GET: api/<ContractsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.BillObjects);
        }

        // GET api/<ContractsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contract = _db.BillObjects                
                .FirstOrDefault(x=>x.Id==id);
            return Ok(contract);
        }

        // POST api/<ContractsController>
        [HttpPost]
        public void Post()
        {
           
           var bo=  new BillObject("Новый объект расчета для договора #1");
            var elo1 = new EnergyLinkObject("elo1");
            bo.AddEnergyLinkObject(elo1, DateTime.Now.Date);
            _db.BillObjects.Add(bo);
           

          var contract= _db.Contracts.Find(1);

            contract.AddBillObject(bo);

            _db.SaveChanges();
            
        }

        // PUT api/<ContractsController>/5
        [HttpPut("bo/createElo/{id}")]
        public void Put(int id)
        {
            var bo = _db.BillObjects
                .Include(p => p.BillObjectsToEnergyLinkObjects)
                .ThenInclude(link => link.EnergyLinkObject)
                .FirstOrDefault(bo => bo.Id == 1);

            var elo2 = new EnergyLinkObject("elo2");            
            bo.AddEnergyLinkObject(elo2, DateTime.Now.Date);
            bo.DisableEnergyLinkObject(1, DateTime.Now.AddDays(1));

          //  _db.BillObjects.Add(bo);

             

            _db.SaveChanges();
        }


        [HttpPut("bo/createLinkEloTobp/{id}")]
        public void Put2(int id)
        {
           
            var elo2=_db.EnergyLinkObjects.Find(2);
            
            elo2.AddBillPoint(1, DateTime.Now);
            elo2.AddBillPoint(3, DateTime.Now);
            
            _db.SaveChanges();
        }


        [HttpPut("bo/createAll/{id}")]
        public void Put3(int id)
        {
            //
            var contract = _db.Contracts.Find(1); // Находим aggregate root
            var bo = new BillObject("Новый объект расчета для договора #2");
            var elo3 = new EnergyLinkObject("elo3");
            elo3.AddBillPoint(5, DateTime.Now.Date.AddDays(-1),DateTime.Now.Date.AddDays(1));
            bo.AddEnergyLinkObject(elo3, DateTime.Now.Date);
            contract.AddBillObject(bo);


            _db.SaveChanges();
        }



        [HttpPut("bo/createWithBillParam/{id}")]
        public void Put4(int id)
        { 

            string nameOfBillObject = "Новый объект расчета для договора #7";

            var contract =_repo.GetContract(1);

            BillObject billobject = contract.BillObjects.FirstOrDefault(x => x.Name == nameOfBillObject);

            if (billobject == null)
            {
                billobject = new BillObject(nameOfBillObject);
                contract.AddBillObject(billobject);
            }

            string nameOfEnergyLinkObject = "elo #7";

            EnergyLinkObject eloFound = billobject.BillObjectsToEnergyLinkObjects
                 .Select(p => p.EnergyLinkObject)
                 .FirstOrDefault(x => x.Name == nameOfEnergyLinkObject);
            if (eloFound == null)
            {
                eloFound = new EnergyLinkObject(nameOfEnergyLinkObject);
                billobject.AddEnergyLinkObject(eloFound, DateTime.Now.Date);
            }

            int numberOfBillPoint = 1005;
        //    eloFound.AddBillPoint(numberOfBillPoint, DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddDays(1));

            var param2  =_db.BillParamTypes.Find(3);
            eloFound.AddParameter(numberOfBillPoint, param2, 30);



            _db.SaveChanges();
        }
    }
}

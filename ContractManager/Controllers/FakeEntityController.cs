using Domain;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeEntityController : ControllerBase
    {
        ContractsDbContext _db;

        public FakeEntityController(ContractsDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public void Post()
        {
            var fe =_db.FakeEntities.Find(1);
            _db.FakeEntityLinks.Add(new FakeEntityLink(fe, BillParamTypeEnum2.VoltageTarifLevel));

            _db.SaveChanges();


            

        }
    }
}

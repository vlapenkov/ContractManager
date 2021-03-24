using Domain;
using Domain.Entities;
using Domain.Enums;
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

        
        [HttpGet("GetValue")]
        public IActionResult GetValue(TypeSide val)
        {
            return Ok(val);

        }

        [HttpGet("GetValues")]
        public IActionResult GetValues()
        {            
            return Ok(Enum.GetValues(typeof(TypeSide)));

        }
    }
}

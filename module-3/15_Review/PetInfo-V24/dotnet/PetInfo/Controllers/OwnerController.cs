using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetInfo.DAO;
using PetInfo.DAO.Interfaces;
using PetInfo.Models;
using PetInfoServer.Models;
using System.Collections.Generic;

namespace PetInfo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public IOwnerDao ownerDao;

        public OwnerController(IOwnerDao ownerDao)
        {
            this.ownerDao = ownerDao;
        }

        [HttpGet()]
        public ActionResult<List<Owner>> GetOwners()
        {
            return Ok(ownerDao.ListOwners());
        }

        [HttpPost()]
        public ActionResult<Owner> AddOwner(Owner newOwner)
        {
            Owner result = ownerDao.AddOwner(newOwner);

            if (result.Id == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}

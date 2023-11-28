using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetInfo.DAO;
using PetInfoServer.Models;
using System.Collections.Generic;

namespace PetInfo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        public IPetDao petDao;

        public PetController(IPetDao petDao)
        {
            this.petDao = petDao;
        }

        [HttpGet()]
        public ActionResult<List<Pet>> GetPets()
        {
            return Ok(petDao.ListPets());
        }

        [HttpPost()]
        public ActionResult<Pet> AddPet(Pet pet)
        {
            Pet newPet = petDao.AddAPet(pet);

            if (newPet == null || newPet.Id == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newPet);
            }
        }

        [HttpPut("{petId}")]
        public ActionResult<Pet> ChangePet(int petId, Pet changedPet)
        {
            Pet newPet = petDao.UpdatePet(changedPet);


            if (newPet == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newPet);
            }

        }


    }
}

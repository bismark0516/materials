using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetInfoServer.DAO;
using PetInfoServer.Models;
using System.Collections.Generic;

namespace PetInfoServer.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetDao dao;
        string connectionString = "Server=.\\SQLEXPRESS;Database=PetInfo;Trusted_Connection=True;";

        public PetController()
        {
            dao = new PetSqlDao(connectionString);
        }

        //GET /pet
        [HttpGet]
        public ActionResult<List<Pet>> GetPets()
        {
            return dao.ListPets();
        }

        //Delete /pet/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePet(int id)
        {
            if (dao.DeleteAPet(id) == true)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}


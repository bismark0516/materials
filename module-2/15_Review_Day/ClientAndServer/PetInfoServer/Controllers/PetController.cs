using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetInfoServer.DAL;
using PetInfoServer.DAL.Interfaces;
using PetInfoServer.Models;

namespace PetInfoServer.Controllers
{
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

        [HttpGet]
        public ActionResult<List<Pet>> GetPets()
        {
            return dao.ListPets();
        }

        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            bool delete = dao.DeleteAPet(id);
            if (delete == true)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

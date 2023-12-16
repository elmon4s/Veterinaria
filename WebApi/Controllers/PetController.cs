using ClassLibrary.Data.Implementation;
using ClassLibrary.Data.Interface;
using ClassLibrary.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetDao dao;
        public PetController()
        {
            dao = new PetDao();
        }
        [HttpGet("/types")]
        public IActionResult GetTypes()
        {
            try
            {
                return Ok(dao.GetAllTypes());
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpGet("/petsByCustomer")]
        public IActionResult GetPetByCustomer(int code)
        {
            try
            {
                return Ok(dao.GetByCustomer(code));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpGet("/pets")]
        public IActionResult GetPets(DateTime fromDate, DateTime toDate, string age, int code, int type, string petName, string customerName)
        {
            try
            {
                return Ok(dao.Get(fromDate, toDate, age, code, type, petName, customerName));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpPost("/pet")]
        public IActionResult PostPet(Pet p, Customer c)
        {
            try
            {
                return Ok(dao.Modify(p, c, true));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpPut("/pet")]
        public IActionResult PutPet(Pet p, Customer c)
        {
            try
            {
                return Ok(dao.Modify(p, c, false));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpPost("/type")]
        public IActionResult PostType(PetType type)
        {
            try
            {
                return Ok(dao.AddType(type));
            }
            catch
            {
                return Utils.Error();
            }
        }
    }
}

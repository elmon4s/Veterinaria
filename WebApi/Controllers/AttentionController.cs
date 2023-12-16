using ClassLibrary.Data.Implementation;
using ClassLibrary.Data.Interface;
using ClassLibrary.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttentionController : ControllerBase
    {
        private readonly IAttentionDao dao;
        public AttentionController()
        {
            dao = new AttentionDao();
        }
        [HttpGet("/attentions")]
        public IActionResult GetAttentions(DateTime fromDate, DateTime toDate, int code, decimal minAmount, decimal maxAmount, string customerName, string petName, string description)
        {
            try
            {
                return Ok(dao.Get(fromDate, toDate, code, minAmount, maxAmount, customerName, petName, description));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpGet("/attentionsByPet")]
        public IActionResult GetAttentionsByPet(int code)
        {
            try
            {
                return Ok(dao.GetByPet(code));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpGet("/attention")]
        public IActionResult GetAttention(int code)
        {
            try
            {
                return Ok(dao.Get(code));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpPost("/attentionToPet")]
        public IActionResult PostAttention(int petCode, Attention a)
        {
            try
            {
                return Ok(dao.Add(petCode, a));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpDelete("/attention")]
        public IActionResult DeleteAttention(int code)
        {
            try
            {
                return Ok(dao.Delete(code));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpPost("/attention")]
        public IActionResult PostAttention(Attention a)
        {
            try
            {
                return Ok(dao.Modify(a));
            }
            catch
            {
                return Utils.Error();
            }
        }
    }
}

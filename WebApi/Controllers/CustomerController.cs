using ClassLibrary.Data.Implementation;
using ClassLibrary.Data.Interface;
using ClassLibrary.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDao dao;
        public CustomerController()
        {
            dao = new CustomerDao();
        }
        [HttpGet("/customers")]
        public IActionResult GetCustomers()
        {
            try
            {
                return Ok(dao.GetAll());
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpGet("/customersFiltered")]
        public IActionResult GetCustomersFiltered(DateTime fromDate, DateTime toDate, int code, string name, bool? sex)
        {
            try
            {
                return Ok(dao.Get(fromDate, toDate, code, name, sex));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpGet("/customer")]
        public IActionResult GetCustomer(int code)
        {
            try
            {
                return Ok(dao.GetByCode(code));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpDelete("/customer")]
        public IActionResult DeleteCustomer(int code)
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
        [HttpPost("/customer")]
        public IActionResult PostCustomer(Customer c)
        {
            try
            {
                return Ok(dao.Modify(c, true));
            }
            catch
            {
                return Utils.Error();
            }
        }
        [HttpPut("/customer")]
        public IActionResult PutCustomer(Customer c)
        {
            try
            {
                return Ok(dao.Modify(c, false));
            }
            catch
            {
                return Utils.Error();
            }
        }
    }
}

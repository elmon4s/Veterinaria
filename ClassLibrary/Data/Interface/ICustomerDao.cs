using ClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data.Interface
{
    public interface ICustomerDao
    {
        public List<Customer> GetAll();
        public List<Customer> Get(DateTime fromDate, DateTime toDate, int code, string name, bool? sex);
        public Customer GetByCode(int code);
        public bool Delete(int code);
        public bool Modify(Customer c, bool newRecord);
    }
}

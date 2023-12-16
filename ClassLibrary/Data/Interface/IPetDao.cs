using ClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data.Interface
{
    public interface IPetDao
    {
        public List<PetType> GetAllTypes();
        public List<Pet> GetByCustomer(int code);
        public List<Pet> Get(DateTime fromDate, DateTime toDate, string age, int code, int type, string petName, string customerName);
        public bool Modify(Pet p, Customer c, bool newRecord);
        public bool AddType(PetType type);
    }
}

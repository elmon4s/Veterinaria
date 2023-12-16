using ClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data.Interface
{
    public interface IAttentionDao
    {
        public List<Attention> Get(DateTime fromDate, DateTime toDate, int code, decimal minAmount, decimal maxAmount, string customerName, string petName, string description);
        public List<Attention> GetByPet(int code);
        public Attention Get(int code);
        public bool Add(int petCode, Attention a);
        public bool Delete(int code);
        public bool Modify(Attention a);
    }
}

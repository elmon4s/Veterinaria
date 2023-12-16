using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Domain
{
    public class Attention
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Attention(int code, string description, decimal amount, DateTime date)
        {
            Code = code;
            Description = description;
            Amount = amount;
            Date = date;
        }

    }
}

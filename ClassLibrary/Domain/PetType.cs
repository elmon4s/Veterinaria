using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Domain
{
    public class PetType
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public PetType(int code, string name)
        {
            Code = code;
            Name = name;
        }
        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Domain
{
    public class Pet
    {
        public List<Attention> Attentions = new List<Attention>();
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public PetType Type { get; set; }
        public int Code { get; set; }

        public Pet(string name, PetType type, int code)
        {
            Name = name;
            Type = type;
            Code = code;
        }
        public Pet(string name, PetType type, int code, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
            Type = type;
            Code = code;
        }
        public int GetAge()
        {
            DateTime startDate = new DateTime(1, 1, 1);
            TimeSpan timeSpan = DateTime.Now - BirthDate;
            return (startDate + timeSpan).Year - 1;
        }
        public override string ToString()
        {
            return Code + " - " + Type.Name + " " + Name + " - " + GetAge() + " Años"; //TODO: Regionalizar
        }
    }
}

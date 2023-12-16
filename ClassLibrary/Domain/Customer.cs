using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Domain
{
    public class Customer
    {
        private List<Pet> pets = new List<Pet>();
        public string Name { get; set; }
        public bool Sex { get; set; }
        public int Code { get; set; }

        public Customer(string name, bool sex, int code)
        {
            Name = name;
            Sex = sex;
            Code = code;
        }

        public List<Pet> GetPets()
        {
            return pets;
        }

        public void AddPet(Pet pet)
        {
            pets.Add(pet);
        }
        public void ModifyCodePet(int oldCode, int newCode)
        {

            foreach (var p in pets)
            {
                if (p.Code == oldCode)
                {
                    p.Code = newCode; 
                    break;
                }
            }

        }
        public void AddPets(IEnumerable<Pet> petList)
        {
            pets.AddRange(petList);
        }
        public string SexString()
        {
            return Sex ? "Masculino" : "Femenino"; //TODO: Regionalizar
        }
        public override string ToString()
        {
            return Code + " - " + Name + " - " + SexString();
        }
    }
}

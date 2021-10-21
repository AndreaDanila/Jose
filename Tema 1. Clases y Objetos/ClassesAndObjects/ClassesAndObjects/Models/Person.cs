using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects.Models
{
    public class Person
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public Person(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public void SayHello(Person otraPersona)
        {
            var b = this.AmIOlder(otraPersona);

            var msg = "Hola "
                        + otraPersona.Name
                        + ", soy "
                        + this.Name + " "
                        + (b ? "Soy mayor que tú" : "Eres un viejales");

            Console.WriteLine(msg);
        }

        public bool AmIOlder(Person otraPersona)
        {
            return this.BirthDate > otraPersona.BirthDate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Student
    {
        public string Dni { get; set; }
        public string Name { get; set; }

        public Student Companion { get; set; }

        public void PrintAllMyData()
        {
            Console.WriteLine("El estudiante A1 se llama " + this.Name + " y su dni es " + this.Dni);
        }

        public Student Clone()
        {
            var output = new Student()
            {
                Name = this.Dni,
                Dni = this.Name
            };

            return output;
        }

        public bool AssignCompanion(string dniAmigo)
        {
            if (Program.StudentsRepository.ContainsKey(dniAmigo))
            {
                var amigo = Program.StudentsRepository[dniAmigo];
                Companion = amigo;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

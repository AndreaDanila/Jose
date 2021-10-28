using Entidades.DAL;
using Entidades.Models;
using System;
using System.Linq;

namespace Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            InitDataStudents();
            InitDataTeachers();

            var tch1 = TeachersRepository.FindByDni("A3");
            var std1 = StudentsRepository.FindByDni("A1");

            var result = tch1.AssignPupil(tch1.Id);

            if (result)
                Console.WriteLine("el nombre del pupilo es: " + tch1.Pupil.Name);
        }

        public static void InitDataStudents()
        {
            var std1 = new Student()
            {
                Id = Guid.NewGuid(),
                Name = "pepe",
                Email = "pepe@pepe.com",
                DNI = "A1"
            };
            var std2 = new Student()
            {
                Id = Guid.NewGuid(),
                Name = "lolo",
                Email = "lolo@lolo.com",
                DNI = "A2"
            };

            StudentsRepository.Items.Add(std1.Id, std1);
            StudentsRepository.Items.Add(std2.Id, std2);
        }

        public static void InitDataTeachers()
        {
            var tch1 = new Teacher()
            {
                Id = Guid.NewGuid(),
                Name = "maria",
                Email = "maria@maria.com",
                DNI = "A3"
            };
            var tch2 = new Teacher()
            {
                Id = Guid.NewGuid(),
                Name = "amparo",
                Email = "amparo@amparo.com",
                DNI = "A4"
            };

            TeachersRepository.Items.Add(tch1.Id, tch1);
            TeachersRepository.Items.Add(tch2.Id, tch2);
        }

        public static void SendGreetingsEmail(User user)
        {

        }
    }
}

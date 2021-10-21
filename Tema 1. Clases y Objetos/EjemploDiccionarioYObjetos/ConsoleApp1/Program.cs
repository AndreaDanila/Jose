using ConsoleApp1.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        public static Dictionary<string, Student> StudentsRepository { get; set; }

        static void Main(string[] args)
        {
            InitStudentsRepository();

            var dni = Console.ReadLine();

            if (StudentsRepository.ContainsKey(dni))
            {
                Console.WriteLine("asignar amigo, seleccione otro estudiante");
                var dniAmigo = Console.ReadLine();

                var st1 = StudentsRepository[dni];
                var resultadoAsignarAmigo = st1.AssignCompanion(dniAmigo);

                if (!resultadoAsignarAmigo)
                {
                    Console.WriteLine($"amigo with dni:{dniAmigo} was not found");
                }
            }
            else
            {
                Console.WriteLine($"student with dni:{dni} was not found");
            }

        }

        private static void InitStudentsRepository()
        {
            StudentsRepository = new Dictionary<string, Student>();

            var student1 = new Student()
            {
                Name = "lolo",
                Dni = "A1"
            };

            var student2 = new Student()
            {
                Name = "Pepa",
                Dni = "A2"
            };

            StudentsRepository.Add(student1.Dni, student1);
            StudentsRepository.Add(student2.Dni, student2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using EjemploCrud.Lib.Models;

namespace EjemploCrud.Lib.DAL
{
    public static class StudentsRepository
    {
        private static Dictionary<Guid, Student> Students = new Dictionary<Guid, Student>();

        public static List<Student> GetAll()
        {
            // opción 1: a pelo

            // creo un objeto de tipo List de Student
            // que vamos a devolver
            var output = new List<Student>();

            //recorremos cada par de key/value en el diccionario
            foreach (var item in Students)
            {
                // y sacamos su valor (objeto de tipo Student)
                // y lo metemos en la lista de salida
                var student = item.Value;
                output.Add(student);
            }

            // devolvemos la lista
            return output;

            // opción 2: short cut para lo de arriba
            //return Students.Values.ToList();

        }

        public static Student Get(Guid id)
        {
            // si existe un Student con es id en la DB me lo devuelve
            if (Students.ContainsKey(id))
                return Students[id];
            else
                // si no, me devuelve el Student por defecto, prob un null
                return default(Student);
        }

        public static Student GetByDni(string dni)
        {
            // todo:
            foreach (var item in Students)
            {
                var student = item.Value;
                if (student.Dni == dni)
                    return student;
            }

            return default(Student);
        }

        public static List<Student> GetByName(string name)
        {
            var output = new List<Student>();

            foreach (var item in Students)
            {
                var student = item.Value;

                if (student.Name == name)
                    output.Add(student);
            }

            // devolvemos la lista
            return output;
        }

        public static bool Add(Student student)
        {
            if (student.Id == default(Guid))
            {
                // todo bien porque no hay ningún Id
                student.Id = Guid.NewGuid();
                Students.Add(student.Id, student);

                return true;
            }
            else if (!Students.ContainsKey(student.Id))
            {
                // si student tiene un Id y no hay ninguno
                // en la base de datos con ese Id
                // lo permitimos, con lo cual sólo hay
                // que añadir el estudiante a la base de datos
                Students.Add(student.Id, student);

                return true;
            }

            // si el Id no estaba vacío y ya existía en la DB devolvmenos false
            return false;
        }
    }
}

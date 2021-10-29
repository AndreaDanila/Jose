using System;
using System.Collections.Generic;
using System.Linq;
using EjemploCrud.Lib.Models;

namespace EjemploCrud.Lib.DAL
{
    public static class StudentsRepository
    {
        private static Dictionary<Guid, Student> Students
        {
            get
            {
                // me miro el campo interno con el diccionario y si está vació
                if (_students == null)
                {
                    //entonces lo inicializo
                    _students = new Dictionary<Guid, Student>();

                    //creo students de prueba
                    var std1 = new Student()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pepe",
                        Email = "p@p.com",
                        Dni = "12345678a"
                    };
                    var std2 = new Student()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Marta",
                        Email = "m@m.com",
                        Dni = "12345678b"
                    };

                    // y lo meto en el campo interno
                    _students.Add(std1.Id, std1);
                    _students.Add(std2.Id, std2);
                }

                //devuelvo el campo interno
                return _students;
            }
        }
        static Dictionary<Guid, Student> _students;

        public static List<Student> StudentsList
        {
            get
            {
                return GetAll();
            }
        }

        public static List<Student> GetAll()
        {
            // opción 1: a pelo

            // creo un objeto de tipo List de Student
            // que vamos a devolver
            //var output = new List<Student>();

            ////recorremos cada par de key/value en el diccionario
            //foreach (var item in Students)
            //{
            //    // y sacamos su valor (objeto de tipo Student)
            //    // y lo metemos en la lista de salida
            //    var student = item.Value;
            //    output.Add(student);
            //}

            //// devolvemos la lista
            //return output;

            // opción 2: short cut para lo de arriba
            return Students.Values.ToList();
        }

        public static Student Get(Guid id)
        {
            // si existe un Student con es id en la DB me lo devuelve
            if (Students.ContainsKey(id))
                return Students[id];
            else
                // si no, me devuelve el Student por defecto,
                // prob un null
                return default(Student);
        }

        public static Student GetByDni(string dni)
        {
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

        public static StudentValidationsTypes Add(Student student)
        {
            if (student.Id != default(Guid))
            {
                // todo bien porque no hay ningún Id
                student.Id = Guid.NewGuid();

                return StudentValidationsTypes.IdNotEmpty;
            }
            else if (!Student.ValidateDniFormat(student.Dni))
            {
                //el dni está mal construido
                return StudentValidationsTypes.WrongDniFormat;
            }
            else
            {
                var stdWithSameDni = GetByDni(student.Dni);
                if (stdWithSameDni != null && student.Id != stdWithSameDni.Id)
                {
                    // hay dos estudiantes distintos con mismo dni
                    return StudentValidationsTypes.DniDuplicated;
                }
            }

            if (!Student.ValidateName(student.Name))
            {
                return StudentValidationsTypes.WrongNameFormat;
            }
            else if (!Students.ContainsKey(student.Id))
            {
                // si student tiene un Id y no hay ninguno
                // en la base de datos con ese Id
                // lo permitimos, con lo cual sólo hay
                // que añadir el estudiante a la base de datos
                Students.Add(student.Id, student);

                return StudentValidationsTypes.Ok;
            }

            // si el Id no estaba vacío y ya existía en la DB devolvmenos false
            return StudentValidationsTypes.IdDuplicated;
        }

        public static StudentValidationsTypes Update(Student student)
        {
            if (student.Id == default(Guid))
            {
                // no se puede actualizar un registro sin id
                return StudentValidationsTypes.IdEmpty;
            }
            if (!Students.ContainsKey(student.Id))
            {
                // no se puede actualizar un registro
                // que no exista en la DB
                return StudentValidationsTypes.StudentNotFound;
            }

            // comprobamos que el dni sea correcto
            if (!Student.ValidateDniFormat(student.Dni))
            {
                //el dni está mal construido
                return StudentValidationsTypes.WrongDniFormat;
            }


            // comprobamos que no haya otro alumno diferente
            // con el mismo dni

            var stdWithSameDni = GetByDni(student.Dni);
            if (stdWithSameDni != null && student.Id != stdWithSameDni.Id)
            {
                // hay dos estudiantes distintos con mismo dni
                return StudentValidationsTypes.DniDuplicated;
            }

            if (!Student.ValidateName(student.Name))
            {
                return StudentValidationsTypes.WrongNameFormat;
            }

            Students[student.Id] = student;

            return StudentValidationsTypes.Ok;
        }

        public static StudentValidationsTypes Delete(Guid id)
        {
            if (Students.ContainsKey(id))
            {
                Students.Remove(id);
                return StudentValidationsTypes.StudentNotFound;
            }
            else
                return StudentValidationsTypes.Ok;
        }
             
    }
}

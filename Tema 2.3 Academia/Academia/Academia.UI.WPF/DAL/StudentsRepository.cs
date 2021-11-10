using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Lib.Models;

namespace Academy.Lib.DAL
{
    public class StudentsRepository : IDisposable
    {
        public AcademyDbContext DbContext { get; set; }

        public List<Student> StudentsList
        {
            get
            {
                return GetAll();
            }
        }

        public StudentsRepository()
        {
            DbContext = new AcademyDbContext();
            LoadInitData();
        }

        public void LoadInitData()
        {
            if (DbContext.Students.Count() == 0)
            {
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
                DbContext.Students.Add(std1);
                DbContext.Students.Add(std2);

                DbContext.SaveChanges();
            }

        }

        public List<Student> GetAll()
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
            //return Students.Values.ToList(); antes
            return DbContext.Students.ToList();
        }

        public Student Get(Guid id)
        {
            // si existe un Student con es id en la DB me lo devuelve
            //var student = DbContext.Students.FirstOrDefault(x => x.Id == id);
            //para el id es mejor el find
            var output = DbContext.Students.Find(id);
            return output;
        }

        public Student GetByDni(string dni)
        {
            //foreach (var item in Students)
            //{
            //    var student = item.Value;
            //    if (student.Dni == dni)
            //        return student;
            //}

            //return default(Student);
            var output = DbContext.Students.FirstOrDefault(s => s.Dni == dni);
            return output;
        }

        public List<Student> GetByName(string name)
        {
            //var output = new List<Student>();

            //foreach (var item in Students)
            //{
            //    var student = item.Value;

            //    if (student.Name == name)
            //        output.Add(student);
            //}

            //// devolvemos la lista
            //return output;

            var output = DbContext.Students.Where(s => s.Name == name).ToList();
            return output;
        }

        public StudentValidationsTypes Add(Student student)
        {
            if (student.Id != default(Guid))
            {
                // todo bien porque no hay ningún Id
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
            //else if (!DbContext.Students.Any(s => s.Id == student.Id)) ineficiente
            else if (DbContext.Students.All(s => s.Id != student.Id)) // más eficiente
            {                
                student.Id = Guid.NewGuid();
                DbContext.Students.Add(student);
                DbContext.SaveChanges();

                return StudentValidationsTypes.Ok;
            }

            // si el Id no estaba vacío y ya existía en la DB devolvmenos false
            return StudentValidationsTypes.IdDuplicated;
        }

        public StudentValidationsTypes Update(Student student)
        {
            if (student.Id == default(Guid))
            {
                // no se puede actualizar un registro sin id
                return StudentValidationsTypes.IdEmpty;
            }
            if (DbContext.Students.All(s => s.Id != student.Id))
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

            DbContext.Students.Update(student);
            DbContext.SaveChanges();

            return StudentValidationsTypes.Ok;
        }

        public StudentValidationsTypes Delete(Guid id)
        {
            var student = DbContext.Students.Find(id);
            if (student == null)
            {
                return StudentValidationsTypes.StudentNotFound;
            }
            else
            {
                DbContext.Students.Remove(student);
                return StudentValidationsTypes.Ok;
            }
        }

        public void Dispose()
        {
        }
    }
}

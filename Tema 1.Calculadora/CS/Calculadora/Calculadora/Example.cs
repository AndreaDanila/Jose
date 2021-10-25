using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Student
    {        
        public string Name { get; set; }
        public string Dni { get; set; }

        public List<Exam> MyExams
        {
            get
            {
                // creamos una variable de salida
                var output = new List<Exam>();

                // por cada objeto exam en la base de datos
                foreach (var exam in Database.Exams)
                {
                    // comprobamos si el objeto estudiante dentro del examen tiene el mismo dni
                    // que el estuiante (this) actual
                    if (exam.Student.Dni == this.Dni)
                        //y si es cierto lo añadimos a la variable de salida
                        output.Add(exam);
                }

                // devolvemos la lista con las coincidencias
                return output;
            }
        }

        public Student()
        {

        }

        public void HacerExamen(double mark, string nombreMateria)
        {
            // encontramos el objeto correspondiente a ese nombre de materia
            var materia = Database.Materias[nombreMateria];

            // creaamos un objeto examen y le damos los datos que necesita
            // Student: el objeto estudiante actual o this
            // Subject: el objeto correspondiente a la materia
            // mark: la nota
            // Date: la fecha
            var exam = new Exam()
            {
                Student = this,
                Subject = materia,
                Mark = mark,
                Date = DateTime.Now
            };

            // añadimos el objeto exam a su repositorio
            Database.Exams.Add(exam);
        }

    }

    public class Subject
    {
        public string Name { get; set; }

    }

    public class Exam
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public double Mark { get; set; }

        public DateTime Date { get; set; }
    }

}

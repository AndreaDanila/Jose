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
                var output = new List<Exam>();

                foreach (var exam in Database.Exams)
                {
                    if (exam.Student.Dni == this.Dni)
                        output.Add(exam);
                }

                return output;
            }
        }

        public Student()
        {

        }

        public void HacerExamen(double mark, string nombreMateria)
        {
            var materia = Database.Materias[nombreMateria];

            var exam = new Exam()
            {
                Student = this,
                Subject = materia,
                Mark = mark,
                Date = DateTime.Now
            };

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

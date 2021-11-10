using System.Collections.Generic;

namespace School.Lib.Models
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }

        public virtual List<Enrollment> Enrollments { get; set; }

        public Student()
        {

        }
    }
}

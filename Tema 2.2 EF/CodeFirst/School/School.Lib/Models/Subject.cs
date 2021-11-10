using System.Collections.Generic;

namespace School.Lib.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual List<Enrollment> Enrollments { get; set; }

        public Subject()
        {

        }
    }
}

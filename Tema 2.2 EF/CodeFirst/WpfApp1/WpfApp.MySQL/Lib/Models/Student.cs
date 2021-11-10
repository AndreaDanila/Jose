using System.Collections.Generic;

namespace Academy.Lib.Models
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public string Dni { get; set; }

        public string Email { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

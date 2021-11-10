using System.Collections.Generic;

namespace Academy.Lib.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

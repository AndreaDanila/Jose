using System.Collections.Generic;
using Common.Lib.Core;

namespace Academy.Lib.Models
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

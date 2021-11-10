using System;

namespace School.Lib.Models
{
    public class Enrollment : Entity
    {
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public DateTime Date { get; set; }

        public Enrollment()
        {

        }
    }
}

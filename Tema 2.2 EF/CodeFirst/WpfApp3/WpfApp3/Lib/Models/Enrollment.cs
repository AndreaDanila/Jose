using System;

namespace Academy.Lib.Models
{
    public class Enrollment : Entity
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public DateTime Date { get; set; }
    }
}

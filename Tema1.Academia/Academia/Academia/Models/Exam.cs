using System;

namespace Academia.Models
{
    public class Exam : Entity
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public double Mark { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}

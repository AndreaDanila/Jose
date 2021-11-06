using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dni { get; set; }

        public string Email { get; set; }


        public ICollection<Subject> Subjects { get; set; }
    }
}

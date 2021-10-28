using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }

        public string Teacher { get; set; }
    }
}

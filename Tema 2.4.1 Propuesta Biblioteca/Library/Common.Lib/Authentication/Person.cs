using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.Authentication
{
    public class Person : User
    {
        public Guid MotherId { get; set; }

        public Guid FatherId { get; set; }
    }
}

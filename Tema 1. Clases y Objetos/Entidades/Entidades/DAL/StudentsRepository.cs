using System;
using System.Collections.Generic;
using System.Linq;
using Entidades.Models;

namespace Entidades.DAL
{
    public static class StudentsRepository
    {
        public static Dictionary<Guid, Student> Items = new Dictionary<Guid, Student>();

        public static Student FindByDni(string dni)
        {
            // con LINQ
            //return Items.Values.FirstOrDefault(x => x.DNI == dni);

            foreach (KeyValuePair<Guid, Student> entry in Items)
            {
                var student = entry.Value;

                if (student.DNI == dni)
                    return student;
            }

            return null;
        }
    }
}

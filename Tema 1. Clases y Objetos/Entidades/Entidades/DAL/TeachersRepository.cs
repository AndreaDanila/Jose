using System;
using System.Collections.Generic;
using Entidades.Models;

namespace Entidades.DAL
{
    public static class TeachersRepository
    {
        public static Dictionary<Guid, Teacher> Items 
            = new Dictionary<Guid, Teacher>();

        public static Teacher FindByDni(string dni)
        {
            // con LINQ
            //return Items.Values.FirstOrDefault(x => x.DNI == dni);

            foreach (KeyValuePair<Guid, Teacher> entry in Items)
            {
                var teacher = entry.Value;

                if (teacher.DNI == dni)
                    return teacher;
            }

            return null;
        }
    }
}

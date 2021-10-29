namespace EjemploCrud.Lib.Models
{
    public class Student : Entity
    {
        #region Static Validations

        public static bool ValidateDniFormat(string dni)
        {
            if (string.IsNullOrEmpty(dni))
                return false;
            else if (dni.Length != 9)
                return false;
            else
                return true;
        }

        public static bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
            {
                // si el nombre está vació o compuesto de espacios
                return false;
            }
            return true;
        }

        #endregion

        public string Dni { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Student()
        {
        }

        public Student Clone()
        {
            var output = new Student
            {
                Id = this.Id,
                Dni = this.Dni,
                Name = this.Name,
                Email = this.Email
            };

            return output;
        }
    }

    public enum StudentValidationsTypes
    {
        Ok,
        WrongDniFormat,
        DniDuplicated,
        WrongNameFormat,
        IdNotEmpty,
        IdDuplicated,
        IdEmpty,
        StudentNotFound
    }
}

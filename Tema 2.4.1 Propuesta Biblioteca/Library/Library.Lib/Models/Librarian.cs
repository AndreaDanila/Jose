using Common.Lib.Authentication;

namespace Library.Lib.Models
{
    public class Librarian : User
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
    }
    public enum LibrarianValidationsTypes
    {
        Ok,
        WrongNameFormat,
        IdNotEmpty,
        IdDuplicated,
        IdEmpty,
        NotFound
    }
}

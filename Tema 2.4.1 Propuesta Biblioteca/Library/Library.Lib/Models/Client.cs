using Common.Lib.Authentication;
using System.Collections.Generic;

namespace Library.Lib.Models
{
    public class Client : User
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

        public string Address { get; set; }
        public string Phone { get; set; }

        public string ComposedInfo
        {
            get
            {
                return $"{Name} {Surname1} {Surname2} {Email}";
            }
        }

        public virtual List<Loan> Loans { get; set; }
    }


    public enum ClientValidationsTypes
    {
        Ok,
        WrongNameFormat,
        IdNotEmpty,
        IdDuplicated,
        IdEmpty,
        NotFound
    }
}

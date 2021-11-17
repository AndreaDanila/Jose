using Common.Lib.Core;
using System;

namespace Library.Lib.Models
{
    public class Loan : Entity
    {
        #region BookCopy

        public Guid BookCopyId { get; set; }
        public BookCopy BookCopy { get; set; }

        #endregion

        #region Client

        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        #endregion

        public DateTime RequestDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
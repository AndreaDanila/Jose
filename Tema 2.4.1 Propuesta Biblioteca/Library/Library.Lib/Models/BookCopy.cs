using Common.Lib.Core;
using System;
using System.Collections.Generic;

namespace Library.Lib.Models
{
    public class BookCopy : Entity
    {
        #region Book

        public Guid BookId { get; set; }
        public Book Book { get; set; }

        #endregion

        public string Barcode { get; set; }

        public virtual List<Loan> Loans { get; set; }
    }
}

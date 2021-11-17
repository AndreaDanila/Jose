using Common.Lib.Core;
using System.Collections.Generic;

namespace Library.Lib.Models
{
    public class Book : Entity
    {
        public string Title { get; set; }

        public string Author { get; set; }
        public string Brieving { get; set; }
        public int FirstPublicationYear { get; set; }

        public virtual List<BookCopy> BookCopies { get; set; }
    }
}

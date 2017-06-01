using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServerBooksLib.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }
        public string Publisher { get; set; }
    }
}

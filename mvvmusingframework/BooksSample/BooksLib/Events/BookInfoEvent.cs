using BooksLib.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLib.Events
{
    public class BookInfoEvent : PubSubEvent<Book>
    {
        public Book Book { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BookMS.Models;

namespace BookMS {
    public static class BookExtentions {
        public static string[] ToStringArray(this Book book) => new string[] {
            book.Id,
            book.Name,
            book.Author,
            book.Press,
            book.Number.ToString()
        };
    }
}

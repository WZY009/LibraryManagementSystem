using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookMS.Models;

namespace BookMS.Mappers {
    class BookMapper : AbstractMapper {
        public Book GetById(string id) => _context.Books.FirstOrDefault(b => b.Id == id);
        public IEnumerable<Book> GetByName(string name) => from b in _context.Books
                                                           where b.Name.Contains(name)
                                                           select b;
        public IEnumerable<Book> GetByPress(string press) => from b in _context.Books
                                                             where b.Press == press
                                                             select b;

    }
}

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
        public IEnumerable<Book> GetAllBooks() => _context.Books.AsEnumerable();
        public Book DeleteById(string id) {
            var book = _context.Books.Find(id);
            if (book != null) {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            return book;
        }
        public Book UpdateBook(Book updateBook) {
            var book = _context.Books.Attach(updateBook);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updateBook;
        }
        public Book AddBook(Book book) {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }
        public Book LendBook(string id) {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            book.Number--;
            _context.SaveChanges();
            return book;
        }
        public Book ReturnBook(string id) {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            book.Number++;
            _context.SaveChanges();
            return book;
        }
    }
}

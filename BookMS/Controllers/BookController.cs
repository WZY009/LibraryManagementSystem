using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookMS.Models;

namespace BookMS.Controllers {
    class BookController : AbstractController {
        public Book GetById(string id) => _context.Books.FirstOrDefault(b => b.Id == id);
        public IOrderedQueryable<Book> GetByName(string name) => from b in _context.Books
                                                                 where b.Name.Contains(name)
                                                                 orderby b.Name
                                                                 select b;
        public IEnumerable<Book> GetAllBooks() => _context.Books.AsEnumerable();
        public int DeleteById(string id) {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            return _context.SaveChanges();
        }
        /// <summary>
        /// 修改图书
        /// </summary>
        /// <param name="updateBook">所需修改的图书，按id匹配</param>
        /// <returns>数据库更改的条数</returns>
        public int UpdateBook(Book updateBook) {
            var book = _context.Books.Attach(updateBook);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChanges();
        }
        /// <summary>
        /// 添加图书
        /// </summary>
        /// <param name="book">所需添加的图书</param>
        /// <returns>数据库变更的条数，若添加的图书id相同则会返回0</returns>
        public int AddBook(Book book) {
            _context.Books.Add(book);
            return _context.SaveChanges();
        }
    }
}

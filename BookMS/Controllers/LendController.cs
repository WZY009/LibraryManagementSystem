using BookMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookMS.Controllers {
    class LendController : AbstractController {
        public int LendBook(string uid, string bid) {
            // 添加借阅记录
            _context.Lends.Add(new Lend() { Uid = uid, Bid = bid });
            // 将书的库存减一
            var book = _context.Books.FirstOrDefault(b => b.Id == bid);
            book.Number--;
            return _context.SaveChanges();
        }
        /// <summary>
        /// 获取某个用户的所有借书信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IEnumerable<UserLend> GetLendsByUid(string uid) {
            return
                _context.Lends
                .Where(lend => lend.Uid == uid)
                .Join(_context.Books, lend => lend.Bid, book => book.Id, (lend, book) =>
                new UserLend {
                    LandNo = lend.No,
                    BookID = lend.Bid,
                    BookName = book.Name,
                    LendTime = lend.LendTime,
                });
        }
        /// <summary>
        /// 删除借阅记录
        /// </summary>
        /// <param name="no">借阅记录编号</param>
        /// <returns>是否删除成功</returns>
        public int ReturnBook(int no) {
            Lend lend = _context.Lends.Find(no);
            // 删除借阅记录
            string bid = lend.Bid;
            _context.Lends.Remove(lend);
            // 将书的库存加一
            var book = _context.Books.FirstOrDefault(b => b.Id == bid);
            book.Number++;
            return _context.SaveChanges();
        }
    }
}

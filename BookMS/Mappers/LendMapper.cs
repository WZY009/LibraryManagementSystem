using BookMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookMS.Mappers {
    class LendMapper : AbstractMapper {
        public void Add(string uid, string bid) {
            _context.Lends.Add(new Lend() { Uid = uid, Bid = bid });
            _context.SaveChanges();
        }
        public IEnumerable<Lend> GetLendsByUid(string uid) =>
            from l in _context.Lends where l.Uid == uid select l;
        public Lend DeleteLend(int no) {
            Lend lend = _context.Lends.Find(no);
            _context.Lends.Remove(lend);
            _context.SaveChanges();
            return lend;
        }
    }
}

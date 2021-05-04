using BookMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookMS.Mappers {
    class AdminMapper : AbstractMapper {
        public Admin Get(string id, string password) => _context.Admins.FirstOrDefault(a => a.Id == id && a.Password == password);
    }
}

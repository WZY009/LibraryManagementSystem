using BookMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMS.Mappers {
    class UserMapper : AbstractMapper
    {
    public User Get(string id, string password) => _context.Users.FirstOrDefault(a => a.Id == id && a.Password == password);
    //如果报错则有可能是mysql没有启动导致
    }
}

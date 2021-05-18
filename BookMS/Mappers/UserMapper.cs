using BookMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMS.Mappers {
    class UserMapper : AbstractMapper {
        public User Get(string id, string password) => _context.Users.FirstOrDefault(a => a.Id == id && a.Password == password);
        //如果报错则有可能是mysql没有启动导致
        public int UploadPhoto(string id, string path) {
            User user = _context.Users.Find(id);
            user.PhotoPath = path;
            return _context.SaveChanges();
        }
        public User AddUser(User user) {
            _context.Add(user);
            //下面这两行是根据bookmapper的写法来写的，这样方便后面注册成功的校验
            _context.SaveChanges();
            return user;
            //原先是这么写的，只有一行,同时返回值为int
            //return _context.SaveChanges();
        }
        public User GetById(string id) => _context.Users.FirstOrDefault(a => a.Id == id);
        public string GetSelectedQuestion(string id) => (from user in _context.Users
                                                         join question in _context.VerifyQuesions
                                                         on user.Question_id equals question.ID
                                                         where user.Id == id
                                                         select question.Question).First();

        public IEnumerable<VerifyQuestion> GetAllQuestions() => _context.VerifyQuesions.AsEnumerable();
    }
}

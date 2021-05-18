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
        public int AddUser(User user) {
            _context.Add(user);
            return _context.SaveChanges();
        }
        public User GetById(string id) => _context.Users.FirstOrDefault(a => a.Id == id);
        public string GetSelectedQuestion(string id) => (from user in _context.Users
                                                         join question in _context.VerifyQuesions
                                                         on user.Question_id equals question.ID
                                                         where user.Id == id
                                                         select question.Question).First();

        public IEnumerable<VerifyQuestion> GetAllQuestions() => _context.VerifyQuesions.AsEnumerable();
        public int UpdatePassword(string id, string newPassword) {
            User user = _context.Users.FirstOrDefault(a => a.Id == id);
            user.Password = newPassword;
            return _context.SaveChanges();
        }
    }
}

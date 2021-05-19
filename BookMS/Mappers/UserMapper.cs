using BookMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMS.Mappers {
    /// <summary>
    /// 用户对数据库的接口
    /// </summary>
    class UserMapper : AbstractMapper {
        public User Get(string id, string password) => _context.Users.FirstOrDefault(a => a.Id == id && a.Password == password);
        //如果报错则有可能是mysql没有启动导致
        public int UploadPhoto(string id, string path) {
            User user = _context.Users.Find(id);
            user.PhotoPath = path;
            return _context.SaveChanges();
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns>是否添加成功</returns>
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

        /// <summary>
        /// 虽说标识符是更改密码，不过其实可能修改用户的所有内容
        /// </summary>
        /// <param name="user">需要修改的用户</param>
        /// <returns>成功更改的条数</returns>
        public int ChangePassword(User user) {
            var forgetter = _context.Users.Attach(user);
            forgetter.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}

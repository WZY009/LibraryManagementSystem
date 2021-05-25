using System;
using System.Collections.Generic;
using System.Text;
using BookMS.Models;

namespace BookMS {
    public static class UserExtentions {
        public static string[] ToStringArray(this User user) => new string[] {
            user.Id,
            user.Name,
            user.Sex.ToString(),
            user.Password,
            user.Major,
            user.Question_id.ToString(),
            user.Question_answer
        };
        public static string[] getUserDetails(string [] userInfo) {
            if (userInfo[2].Equals("True")) {
                userInfo[2] = "♂";
            }
            else
                userInfo[2] = "♀";
            return userInfo;
        }
    }
}

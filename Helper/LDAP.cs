using LanguageExt;
using static LanguageExt.Prelude;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Train20250624.Helper
{
    public class LDAP
    {
        public struct LoginUser
        {
            public string userName;
            public string userPassword;
        }

        public static List<LoginUser> GenLoginUser(string userName, string userPassword) =>
            new List<LoginUser> { new LoginUser { userName = userName, userPassword = userPassword } };

        public static List<LoginUser> VerifyFaculty(LoginUser user)=>
        user.userName == "airmanx" && user.userPassword == "12345678"
                ? new List<LoginUser>()
                : new List<LoginUser> { user };
        

        public static List<LoginUser> VerifyStudent(LoginUser user)=>
        user.userName == "S1234567" && user.userPassword == "12345678"
                         ? new List<LoginUser>()
                        : new List<LoginUser> { user };

        public static List<LoginUser> VerifyAdmin(LoginUser user) =>
            user.userName == "admin" && user.userPassword == "12345678"
                        ? new List<LoginUser>()
                        : new List<LoginUser> { user };

        public static bool VerifyFacultyLDAP(LoginUser user)
        {         
            return user.userName == "airmanx" && user.userPassword == "12345678";
        }

        public static bool VerifyStudentLDAP(LoginUser user)
        {
            return user.userName == "S1234567" && user.userPassword == "12345678";
        }

        public static Func<LoginUser, Either<string, bool>> Verify(Func<LoginUser, bool> VerifyLDAP) => (LoginUser user) =>
        {
            try
            {
                return Right<string, bool>(VerifyLDAP(user));
            }
            catch (Exception ex)
            {
                return Left<string, bool>(ex.Message);
            }
        };

    }
}
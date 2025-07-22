using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Train20250624.Helper;
using LanguageExt;
using static LanguageExt.Prelude;
using LanguageExt.SomeHelp;

namespace Train20250624
{

   

    public partial class WebForm3 : System.Web.UI.Page
    {

       private Option<int> Add(int x) =>
       Cond<int>(i => i > 0).Then(i => Some(i)).Else(None).Invoke(x);

       private Option<int> retry(Option<int> f, int x)
        {

            var result = Enumerable.Repeat(f, x).Fold(f, (acc, func) =>
            {
                return acc.BiBind(v => Some(v), () => {
                    System.Threading.Thread.Sleep(1000);
                    return func; });
            });

            return result;
        }
            

        private Option<string> FindError(string str,Func<string,bool> rule, string errorMessage)=>
            Cond<string>(rule).Then(s => Some(errorMessage)).Else(None).Invoke(str);

        private Option<IEnumerable<string>> FindLoginUserErrors(LDAP.LoginUser user) =>
        List(
            FindError(user.userName, string.IsNullOrWhiteSpace, "User ID cannot be empty."),
            FindError(user.userPassword, string.IsNullOrWhiteSpace, "Password cannot be empty."),
            FindError(user.userName, s => s.Length > 20, "User ID cannot be longer than 20 characters."),
            FindError(user.userPassword, s => s.Length > 20, "Password cannot be longer than 20 characters.")
        )
        .Somes().ToSome().ToOption();

        private Either<string, LDAP.LoginUser> ValidLoginUserInput(LDAP.LoginUser user) =>
            FindLoginUserErrors(user).Match(
                r => Left<string, LDAP.LoginUser>(string.Join(",",r.ToArray())), 
                () => Right<string, LDAP.LoginUser>(user)
            );

        private Either<string, LDAP.LoginUser> ValidLoginUserLDAP(LDAP.LoginUser user) =>
        Cond<bool>(b => b)
        .Then(Right<string, LDAP.LoginUser>(user))
        .Else(Left<string, LDAP.LoginUser>("登入驗證錯誤"))
        .Invoke(
            List(LDAP.Verify(LDAP.VerifyFacultyLDAP), LDAP.Verify(LDAP.VerifyStudentLDAP)).TakeWhile(f => f(user).IsRight).Count() > 0
        );

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            ValidLoginUserInput(LDAP.GenLoginUser(UserIdTextBox.Text, PasswordTextBox.Text).First())
            .Bind(ValidLoginUserLDAP)
            .Match(
                u =>
                {
                    MsgLabel.Text = "登入成功";
                }, 
                s =>
                {
                    MsgLabel.Text = s;
                }
             );
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            retry(Add(2),5).Match(
                Some: result => MsgLabel.Text = $"Result: {result}",
                None: () => MsgLabel.Text = "No valid result found."
            );
        }
    }
}
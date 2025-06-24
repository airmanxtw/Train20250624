using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Train20250624.Helper;

namespace Train20250624
{
    public partial class Login : System.Web.UI.Page
    {
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            var result = LDAP.GenLoginUser(UserName.Text,PassWord.Text)
                        .SelectMany(LDAP.VerifyFaculty)
                        .SelectMany(LDAP.VerifyStudent)
                        .SelectMany(LDAP.VerifyAdmin);


            ResultLabel.Text = !result.Any() ?
                "登入成功" :
                $"登入失敗，請檢查用戶名和密碼。";

        }
    }
}
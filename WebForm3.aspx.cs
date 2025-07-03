using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Train20250624.Helper;

namespace Train20250624
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            List<string> Errors = new List<string>();
            if (string.IsNullOrEmpty(UserIdTextBox.Text))
                Errors.Add("User ID cannot be empty.");

            if (string.IsNullOrEmpty(PasswordTextBox.Text))
                Errors.Add("Password cannot be empty.");

            if(UserIdTextBox.Text.Length > 20)
                Errors.Add("User ID cannot be longer than 20 characters.");

            if (PasswordTextBox.Text.Length > 20)
                Errors.Add("Password cannot be longer than 20 characters.");

            if (Errors.Count == 0)
            {
               LDAP.LoginUser user = new LDAP.LoginUser
               {
                   userName = UserIdTextBox.Text,
                   userPassword = PasswordTextBox.Text
               };
               if(LDAP.VerifyFacultyLDAP(user) || LDAP.VerifyFacultyLDAP(user))                
                    MsgLabel.Text = "Login successful as Faculty or Student.";                
               else                
                    MsgLabel.Text = "Login failed. Please check your User ID and Password.";                
            }
            else
            {
                MsgLabel.Text = string.Join("<br/>", Errors);
            }
        }
    }
}
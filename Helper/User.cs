using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Web;

using LanguageExt;

namespace Train20250624.Helper
{
    public class FirstName : NewType<FirstName,string>
    {
        public FirstName(string value) : base(value) { }
    }


    public class User
    {
        public string GetName(FirstName firstName)
        {
            return firstName.Value;
        }
    }
}
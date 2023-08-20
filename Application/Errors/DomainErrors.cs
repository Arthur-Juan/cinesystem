using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Errors;

public static class DomainErrors
{
    public static class User
    {
        public static string PasswordDontMatch = "Passwords doesnt match";
        public static string EmailAlreadyInUse = "Email already in use";
        public static string InvalidEmailFormat = "Invalid Email format";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace _05TokenApp.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; //token publisher
        public const string AUDIENCE = "http://localhost:64222/"; // token eater
        private const string KEY = "mysupersecret_secretkey!123"; // encryption key
        public const int LIFETIME = 1; // token life time = 1 min

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

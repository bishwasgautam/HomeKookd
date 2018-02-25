using System;
using System.Collections.Generic;
using System.Text;

namespace HomeKookd.Common
{
    public static class Keys
    {
        public static class AppSettings
        {
            
        }

        public class ConnectionStrings
        {
            public static string HomeKookdMain = "HomeKookd.Main";
            public static string HomekookdIdentity = "HomeKookd.Identity";
            public static string HomekookdLogging = "HomeKookd.Logging";
        }

        public class Security
        {
            public static string JwtSecurityToken = "JwtSecurityToken";
        }
    }
}

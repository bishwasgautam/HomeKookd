using System;
using System.Collections.Generic;
using System.Text;

namespace HomeKookd.AuthTests
{
    public static class TestHelper
    {
        public static string GenerateRandomPhoneNumber()
        {
            var R = new Random();

            return (R.Next(0, 100000) * R.Next(0, 100000)).ToString().PadLeft(10, '0');
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Common
{
    public class LogIn : ILogIn
    {
        int ILogIn.LogIn(string username, string password)
        {
            Console.WriteLine(username + " " + password);
            return 1;
        }
    }
}

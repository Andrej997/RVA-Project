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
        Osoba ILogIn.LogIn(LoginUser user)
        {
            Osoba logged;
            using (CommonContex commonContex = new CommonContex())
            {
               logged =  commonContex.Osoba
                    .Where(x => x.Username == user.Username && x.Password == user.Password)
                    .FirstOrDefault();

                Console.WriteLine("Logged : " + logged.Username + " " + logged.Password);
            }
            return logged;
        }
    }
}

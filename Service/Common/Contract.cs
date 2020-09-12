using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Common
{
    public class Contract : IContract
    {
        private DBService service;
        private Proxy proxy;
        private LogInOut LogInOut;
        public Contract()
        {
            service = new DBService();
            proxy = new Proxy(service);
            LogInOut = new LogInOut();
        }

        public Admin LogInAdmin(LoginUser user)
        {
            return LogInOut.LoginAdmin(user, proxy);
        }

        public Vezbac LogInVezbac(LoginUser user)
        {
            return LogInOut.LoginVezbac(user, proxy);
        }

        public void LogOut(Osoba osoba)
        {
            LogInOut.Logout(osoba);
        }
    }
}

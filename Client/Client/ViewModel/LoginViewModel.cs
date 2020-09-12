//using Client.ServiceReference1;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModel
{
    public class LoginViewModel : BindableBase
    {
        private static readonly string errorMessage = "Invalid username or password!";

        public MyICommand Login { get; set; }

        public string Error { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            Error = "";
            Login = new MyICommand(SendLoginData);
        }

        public void SendLoginData()
        {
            LoginUser loginUser = new LoginUser(Username, Password);
            var admin = InternalData.Data.service.LogInAdmin(loginUser);
            if (admin != null)
            {
                InternalData.Data.ulogovanaOsova = admin;
                Error = "";
            }
            else
            {
                var vezbac = InternalData.Data.service.LogInAdmin(loginUser);
                if (vezbac != null)
                {
                    InternalData.Data.ulogovanaOsova = vezbac;
                    Error = "";
                }
                else
                    Error = errorMessage;
            }
        }

    }
}

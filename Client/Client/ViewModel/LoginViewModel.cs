using System.Windows;

namespace Client.ViewModel
{
    public class LoginViewModel : BindableBase
    {
        private static readonly string errorMessage = "Invalid username or password!";

        public MyICommand Login { get; set; }
        public MyICommand Logout { get; set; }

        public string Error { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool HideAll { get; set; }
        public bool Disable { get; set; }

        public Visibility btnLogInVisibility { get; set; }

        public Visibility btnLogOutVisibility { get; set; }

        public LoginViewModel()
        {
            if (!InternalData.Data.IsLoggedIn())
            {
                btnLogInVisibility = Visibility.Collapsed;
                btnLogOutVisibility = Visibility.Visible;
            }
            else 
            {
                btnLogInVisibility = Visibility.Visible;
                btnLogOutVisibility = Visibility.Collapsed;
            }
            Login = new MyICommand(SendLoginData);
            Logout = new MyICommand(SendLogoutData);
        }

        //public void TriggerMainViewModelProp(bool IsItemEnable)
        //{
        //    var method = typeof(MainViewModel).GetMethod("ChangeItemEnableTrue");
        //    var action = (Action<MainViewModel>)Delegate.CreateDelegate(typeof(Action<MainViewModel>), method);
        //    action(null);
        //}

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
                var vezbac = InternalData.Data.service.LogInVezbac(loginUser);
                if (vezbac != null)
                {
                    InternalData.Data.ulogovanaOsova = vezbac;
                    Error = "";
                }
                else
                    Error = errorMessage;
            }
        }

        public void SendLogoutData()
        {
            InternalData.Data.service.LogOut(InternalData.Data.ulogovanaOsova.Username);
            InternalData.Data.ulogovanaOsova = null;
        }
    }
}

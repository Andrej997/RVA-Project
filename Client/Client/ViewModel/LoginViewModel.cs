using System.Windows;

namespace Client.ViewModel
{
    public class LoginViewModel : BindableBase
    {
        private static readonly string errorMessage = "Invalid username or password!";

        public MyICommand Login { get; set; }
        public MyICommand Logout { get; set; }
        public MyICommand ChangeMe { get; set; }

        public string Error { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private string usernameL;

        public string UsernameL
        {
            get { return usernameL; }
            set { 
                usernameL = value;
                OnPropertyChanged("UsernameL");
            }
        }

        private string fullnameL;

        public string FullnameL
        {
            get { return fullnameL; }
            set { 
                fullnameL = value;
                OnPropertyChanged("FullnameL");
            }
        }


        public bool HideAll { get; set; }
        public bool Disable { get; set; }

        public Visibility btnLogInVisibility { get; set; }

        public Visibility btnLogOutVisibility { get; set; }

        public Visibility btnLogggedVisibility { get; set; }

        public LoginViewModel()
        {
            if (!InternalData.Data.IsLoggedIn())
            {
                SetModel();
                btnLogInVisibility = Visibility.Collapsed;
                btnLogggedVisibility = Visibility.Visible;
            }
            else 
            {
                btnLogInVisibility = Visibility.Visible;
                btnLogggedVisibility = Visibility.Collapsed;
            }
            
            Login = new MyICommand(SendLoginData);
            Logout = new MyICommand(SendLogoutData);
            ChangeMe = new MyICommand(SendChange);
        }

        //public void TriggerMainViewModelProp(bool IsItemEnable)
        //{
        //    var method = typeof(MainViewModel).GetMethod("ChangeItemEnableTrue");
        //    var action = (Action<MainViewModel>)Delegate.CreateDelegate(typeof(Action<MainViewModel>), method);
        //    action(null);
        //}

        public void SendChange()
        {
            InternalData.Data.ulogovanaOsova.Username = UsernameL;
            InternalData.Data.ulogovanaOsova.FullName = FullnameL;
            if (InternalData.Data.ulogovanaOsova.Role == 0)
                InternalData.Data.service.ChangeAdmin(InternalData.Data.ulogovanaOsova as Admin);
            else
                InternalData.Data.service.ChangeVezbac(InternalData.Data.ulogovanaOsova as Vezbac);

        }

        public void SendLoginData()
        {
            LoginUser loginUser = new LoginUser(Username, Password);
            var admin = InternalData.Data.service.LogInAdmin(loginUser);
            if (admin != null)
            {
                InternalData.Data.ulogovanaOsova = admin;
                SetModel();
                Error = $"Hello {admin.FullName}";
                MessageBox.Show(Error);
            }
            else
            {
                var vezbac = InternalData.Data.service.LogInVezbac(loginUser);
                if (vezbac != null)
                {
                    InternalData.Data.ulogovanaOsova = vezbac;
                    SetModel();
                    Error = $"Hello {vezbac.FullName}";
                    MessageBox.Show(Error);
                }
                else
                {
                    Error = errorMessage;
                    MessageBox.Show(Error);
                }
            }
        }

        private void SetModel()
        {
            if (!InternalData.Data.IsLoggedIn())
            {
                UsernameL = InternalData.Data.ulogovanaOsova.Username;
                FullnameL = InternalData.Data.ulogovanaOsova.FullName;
            }
        }

        public void SendLogoutData()
        {
            InternalData.Data.service.LogOut(InternalData.Data.ulogovanaOsova.Username);
            InternalData.Data.ulogovanaOsova = null;
        }
    }
}

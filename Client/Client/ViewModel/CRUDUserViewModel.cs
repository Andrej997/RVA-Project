using System.Windows;

namespace Client.ViewModel
{
    public class CRUDUserViewModel : BindableBase
    {
        public MyICommand Create { get; set; }

        public string Error { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }

        public Visibility Visibility { get; set; }

        public CRUDUserViewModel()
        {
            if (InternalData.Data.IsLoggedIn()) 
            {
                Visibility = Visibility.Collapsed;
                Error = "You are not logged in, so you don't have permision to see content of this page!";
            } 
            else
            {
                if (!InternalData.Data.IsAdmin())
                {
                    Visibility = Visibility.Collapsed;
                    Error = "You don't have a role of an admin!";
                }
                else
                {
                    Visibility = Visibility.Visible;
                    Error = "";
                }
            }
            Create = new MyICommand(CreateClick);
        }

        public void CreateClick()
        {
            //"System.Windows.Controls.ComboBoxItem: Admin"
            var cmb = Role.Split(':')[1].Split(' ')[1];
            if (cmb == "Admin")
                AddAdmin();
            else
                AddVezbac();
        }

        public void AddAdmin()
        {
            Admin admin = new Admin()
            {
                Username = Username,
                Password = Password,
                FullName = FullName,
                Role = 0
            };
            Error = InternalData.Data.service.CreateAdmin(admin);
        }

        public void AddVezbac()
        {
            Vezbac vezbac = new Vezbac()
            {
                Username = Username,
                Password = Password,
                FullName = FullName,
                Role = 1
            };
            Error = InternalData.Data.service.CreateVezbac(vezbac);
        }
    }
}

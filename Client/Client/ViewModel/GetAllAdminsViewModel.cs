using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModel
{
    public class GetAllAdminsViewModel : BindableBase
    {
        public static ObservableCollection<Admin> Admini { get; set; }
        private Admin selektovaniAdmin = new Admin();
        public Admin SelektovaniAdmin
        {
            get { return selektovaniAdmin; }
            set
            {
                selektovaniAdmin = value;
            }
        }

        public static ObservableCollection<Vezbac> Vezbaci { get; set; }
        private Vezbac selektovaniVezbac = new Vezbac();
        public Vezbac SelektovaniVezbac
        {
            get { return selektovaniVezbac; }
            set
            {
                selektovaniVezbac = value;
            }
        }

        public Visibility Visible { get; set; }
        public string Error { get; set; }

        public GetAllAdminsViewModel()
        {
            if (InternalData.Data.IsLoggedIn())
            {
                Visible = Visibility.Collapsed;
                Error = "You are not logged in, so you don't have permision to see content of this page!";
            }
            else
            {
                if (!InternalData.Data.IsAdmin())
                {
                    Visible = Visibility.Collapsed;
                    Error = "You don't have a role of an admin!";
                }
                else
                {
                    Visible = Visibility.Visible;
                    Error = "";
                }
            }
            GetAdmins();
            GetVezbace();
        }

        private void GetAdmins()
        {
            Admini = new ObservableCollection<Admin>();
            foreach (var admin in InternalData.Data.service.GetAllAdmins())
            {
                Admini.Add(admin);
            }
        }

        private void GetVezbace()
        {
            Vezbaci = new ObservableCollection<Vezbac>();
            foreach (var vezbac in InternalData.Data.service.GetAllVezbace())
            {
                Vezbaci.Add(vezbac);
            }
        }
    }
}

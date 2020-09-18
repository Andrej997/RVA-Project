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
        private Admin selektovaniAdmin;
        public Admin SelektovaniAdmin
        {
            get { return selektovaniAdmin; }
            set
            {
                selektovaniAdmin = value;
                DeleteAdmin.RaiseCanExecuteChanged();
                ChangeAdmin.RaiseCanExecuteChanged();
            }
        }

        public static ObservableCollection<Vezbac> Vezbaci { get; set; }
        private Vezbac selektovaniVezbac;
        public Vezbac SelektovaniVezbac
        {
            get { return selektovaniVezbac; }
            set
            {
                selektovaniVezbac = value;
                DeleteVezbac.RaiseCanExecuteChanged();
                ChangeVezbac.RaiseCanExecuteChanged();
            }
        }

        public Visibility Visible { get; set; }
        public string Error { get; set; }

        public MyICommand DeleteAdmin { get; set; }
        public MyICommand DeleteVezbac { get; set; }

        public MyICommand ChangeAdmin { get; set; }
        public MyICommand ChangeVezbac { get; set; }

        public MyICommand ApplyChange { get; set; }

        private string usernameTB;

        public string UsernameTB
        {
            get { return usernameTB; }
            set { usernameTB = value;
                OnPropertyChanged("UsernameTB");
            }
        }
        private string fullnameTB;

        public string FullnameTB
        {
            get { return fullnameTB; }
            set { 
                fullnameTB = value;
                OnPropertyChanged("FullnameTB");
            }
        }

        private string roleTB;

        public string RoleTB
        {
            get { return roleTB; }
            set { roleTB = value;
                OnPropertyChanged("RoleTB");
            }
        }
        private string idTB;

        public string IDTB
        {
            get { return idTB; }
            set { idTB = value;
                OnPropertyChanged("IDTB");
            }
        }

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
            try
            {
                GetAdmins();
                GetVezbace();
            }
            catch
            {

            }
            

            DeleteAdmin = new MyICommand(DeleteA, CanUseA);
            DeleteVezbac = new MyICommand(DeleteV, CanUseV);

            ChangeAdmin = new MyICommand(ChangeA, CanUseA);
            ChangeVezbac = new MyICommand(ChangeV, CanUseV);

            ApplyChange = new MyICommand(Change);
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

        private void DeleteA()
        {
            Error = InternalData.Data.service.DeleteAdmin(SelektovaniAdmin);
            MessageBox.Show(Error);
            Admini.Remove(SelektovaniAdmin);
        }

        public bool CanUseA() => SelektovaniAdmin != null;

        private void DeleteV()
        {
            Error = InternalData.Data.service.DeleteVezbac(SelektovaniVezbac);
            MessageBox.Show(Error);
            Vezbaci.Remove(SelektovaniVezbac);
        }

        public bool CanUseV() => SelektovaniVezbac != null;

        public void ChangeA()
        {
            FullnameTB = SelektovaniAdmin.FullName;
            UsernameTB = SelektovaniAdmin.Username;
            RoleTB = "admin";
            IDTB = SelektovaniAdmin.ID.ToString();
        }

        public void ChangeV()
        {
            FullnameTB = SelektovaniVezbac.FullName;
            UsernameTB = SelektovaniVezbac.Username;
            RoleTB = "vezbac";
            IDTB = SelektovaniVezbac.ID.ToString();
        }

        public void Change()
        {
            if (RoleTB == "admin")
            {
                Admin admin = new Admin()
                {
                    ID = Int32.Parse(IDTB),
                    FullName = FullnameTB,
                    Username = UsernameTB,
                    Role = 0
                };
                Error = InternalData.Data.service.ChangeAdmin(admin);
            }
            else if(RoleTB == "vezbac")
            {
                Vezbac vezbac = new Vezbac()
                {
                    ID = Int32.Parse(IDTB),
                    FullName = FullnameTB,
                    Username = UsernameTB,
                    Role = 1
                };
                Error = InternalData.Data.service.ChangeVezbac(vezbac);
            }
        }
    }
}

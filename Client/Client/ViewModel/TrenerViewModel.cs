using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModel
{
    public class TrenerViewModel : BindableBase
    {
        public static ObservableCollection<Trener> Treneri { get; set; }
        private Trener selektovaniTrener;
        public Trener SelektovaniTrener
        {
            get { return selektovaniTrener; }
            set
            {
                selektovaniTrener = value;
                DeleteTrener.RaiseCanExecuteChanged();
                ChangeTrener.RaiseCanExecuteChanged();
            }
        }

        private string fullnameTB;

        public string FullnameTB
        {
            get { return fullnameTB; }
            set
            {
                fullnameTB = value;
                OnPropertyChanged("FullnameTB");
            }
        }

        public Visibility Visible { get; set; }
        public string Error { get; set; }

        public MyICommand AddTrener { get; set; }
        public MyICommand ChangeTrener { get; set; }
        public MyICommand DeleteTrener { get; set; }

        public TrenerViewModel()
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
                GetTrenere();
            }
            catch
            {

            }


            AddTrener = new MyICommand(CreateT);
            ChangeTrener = new MyICommand(ChangeT, CanUseT);
            DeleteTrener = new MyICommand(DeleteT, CanUseT);

            Treneri = new ObservableCollection<Trener>();
        }

        private void GetTrenere()
        {
            if (Treneri == null)
                Treneri = new ObservableCollection<Trener>();

            var tList = InternalData.Data.service.GetTrenere();
            foreach (var trener in tList)
            {
                Treneri.Add(trener);
            }
        }

        public bool CanUseT() => SelektovaniTrener != null;

        private void CreateT()
        {
            var trener = new Trener
            {
                Role = 2,
                FullName = FullnameTB,
                LastChanged = DateTime.Now
            };
            Error = InternalData.Data.service.CreateTrener(trener);
            MessageBox.Show(Error);
            Treneri.Add(trener);
        }

        private void ChangeT()
        {
            //Error = InternalData.Data.service.DeleteAdmin(SelektovaniTrener);
            MessageBox.Show(Error);
            SelektovaniTrener.FullName = FullnameTB;
        }

        private void DeleteT()
        {
            //Error = InternalData.Data.service.DeleteAdmin(SelektovaniTrener);
            MessageBox.Show(Error);
            Treneri.Remove(SelektovaniTrener);
        }
    }
}

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

        private DateTime lastChangeTB;

        public DateTime LastChangeTB
        {
            get { return lastChangeTB; }
            set
            {
                lastChangeTB = value;
                OnPropertyChanged("LastChangeTB");
            }
        }

        public Visibility Visible { get; set; }
        public string Error { get; set; }

        public MyICommand AddTrener { get; set; }
        public MyICommand ChangeTrener { get; set; }
        public MyICommand AppyChangeTrener { get; set; }
        public MyICommand DeleteTrener { get; set; }
        public MyICommand RefreshTrener { get; set; }

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
            AppyChangeTrener = new MyICommand(ApplyChange);
            DeleteTrener = new MyICommand(DeleteT, CanUseT);
            RefreshTrener = new MyICommand(RefreshT);
        }

        private void GetTrenere()
        {
            Treneri = new ObservableCollection<Trener>();

            foreach (var trener in InternalData.Data.service.GetTrenere())
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
            if (trener.FullName == null || trener.FullName == "")
                Error = "Fullname field can't be empty!";
            else
            {
                Error = InternalData.Data.service.CreateTrener(trener);
                Treneri.Add(trener);
            }
            MessageBox.Show(Error);
        }

        private void ChangeT()
        {
            //Error = InternalData.Data.service.DeleteAdmin(SelektovaniTrener);
            //MessageBox.Show(Error);
            FullnameTB = SelektovaniTrener.FullName;
            LastChangeTB = SelektovaniTrener.LastChanged;
        }

        private void ApplyChange()
        {
            var trener = new Trener
            {
                ID = SelektovaniTrener.ID,
                Role = 2,
                FullName = FullnameTB,
                LastChanged = LastChangeTB
            };
            var result = InternalData.Data.service.ChangeUserT(trener);
            var sss = result.Split('+');
            if (sss[0] == "?")
            {
                System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Da li zelite da pregazite prethodno nacinjene promene?", "Promena", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    trener.LastChanged = Convert.ToDateTime(sss[1]);
                    Error = InternalData.Data.service.ChangeUserT(trener);
                    System.Windows.MessageBox.Show(Error);
                }
                else if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    //nista
                }
            }
            else
            {
                System.Windows.MessageBox.Show(result);
            }
        }

        private void DeleteT()
        {
            Error = InternalData.Data.service.DeleteTrener(SelektovaniTrener.ID);
            MessageBox.Show(Error);
            Treneri.Remove(SelektovaniTrener);
        }

        private void RefreshT()
        {
            //Treneri = new ObservableCollection<Trener>();
            GetTrenere();
        }
    }
}

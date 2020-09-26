using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModel
{
    public class TreningViewModel : BindableBase
    {
        public static ObservableCollection<Trening> Treninzi { get; set; }
        private Trening selektovaniTrening;
        public Trening SelektovaniTrening
        {
            get { return selektovaniTrening; }
            set
            {
                selektovaniTrening = value;
                DeleteTrening.RaiseCanExecuteChanged();
            }
        }

        public static ObservableCollection<Trener> Treneri { get; set; }
        private Trener selektovaniTrener;
        public Trener SelektovaniTrener
        {
            get { return selektovaniTrener; }
            set
            {
                selektovaniTrener = value;
                CreateTrening.RaiseCanExecuteChanged();
            }
        }

        public MyICommand CreateTrening { get; set; }
        public MyICommand DeleteTrening { get; set; }
        public MyICommand UndoTrening { get; set; }
        public MyICommand RedoTrening { get; set; }

        public string Error { get; set; }

        public Visibility Visible { get; set; }


        public TreningViewModel()
        {

            if (!InternalData.Data.IsLoggedIn())
                Visible = Visibility.Visible;
            else
            {
                Error = "You need to sign in to see this page!";
                Visible = Visibility.Collapsed;
            }
            CreateTrening = new MyICommand(Create, CanUseTrener);
            DeleteTrening = new MyICommand(Delete, CanUseT);

            UndoTrening = new MyICommand(Undo);
            RedoTrening = new MyICommand(Redo);

            GetTrenere();
            GetTreninge();
        }

        private void GetTrenere()
        {
            Treneri = new ObservableCollection<Trener>();
            foreach (var trener in InternalData.Data.service.GetTrenere())
            {
                Treneri.Add(trener);
            }
        }

        private void GetTreninge()
        {
            if (InternalData.Data.ulogovanaOsova != null)
            {
                Treninzi = new ObservableCollection<Trening>();
                List<Trening> list = new List<Trening>();
                if (InternalData.Data.ulogovanaOsova.Role == 0)
                    list = InternalData.Data.service.GetTreninge(InternalData.Data.ulogovanaOsova as Admin);
                else if (InternalData.Data.ulogovanaOsova.Role == 1)
                    list = InternalData.Data.service.GetTreningeV(InternalData.Data.ulogovanaOsova as Vezbac);

                foreach (var trening in list)
                {
                    Treninzi.Add(trening);
                }
                if (Treneri.Count == 0)
                {
                    Error = "User does not have treninge!";
                    MessageBox.Show(Error);
                }
            }
        }

        public bool CanUseT() => SelektovaniTrening != null;

        public bool CanUseTrener() => SelektovaniTrener != null;

        private void Create()
        {
            Error = null;
            Trening trening = new Trening();
            trening.Termin = DateTime.Now;
            trening.Trener = SelektovaniTrener;
            
            if (InternalData.Data.ulogovanaOsova.Role == 0)
            {
                Error = InternalData.Data.service.AddTreningAdmin(InternalData.Data.ulogovanaOsova.ID, trening);
            }
            else
                Error = InternalData.Data.service.AddTreningVezbac(InternalData.Data.ulogovanaOsova.ID, trening);

            if (Error != null)
                MessageBox.Show(Error);

            if (Treninzi == null)
                Treninzi = new ObservableCollection<Trening>();
            Treninzi.Add(trening);
        }

        private void Delete()
        {
            if (InternalData.Data.ulogovanaOsova.Role == 0)
                Error = InternalData.Data.service.DeleteTrening(InternalData.Data.ulogovanaOsova as Admin, SelektovaniTrening);
            if (InternalData.Data.ulogovanaOsova.Role == 1)
                Error = InternalData.Data.service.DeleteTreningV(InternalData.Data.ulogovanaOsova as Vezbac, SelektovaniTrening);
            MessageBox.Show(Error);
            Treninzi.Remove(SelektovaniTrening);
        }

        private void Undo()
        {

        }

        private void Redo()
        {

        }
    }
}

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

        public TreningViewModel()
        {
            CreateTrening = new MyICommand(Create, CanUseTrener);
            DeleteTrening = new MyICommand(Delete, CanUseT);

            UndoTrening = new MyICommand(Undo);
            RedoTrening = new MyICommand(Redo);

            GetTrenere();
        }

        private void GetTrenere()
        {
            Treneri = new ObservableCollection<Trener>();
            foreach (var trener in InternalData.Data.service.GetTrenere())
            {
                Treneri.Add(trener);
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
                Error = InternalData.Data.service.AddTreningAdmin(InternalData.Data.ulogovanaOsova.ID, trening);
            //else
            //    Error = InternalData.Data.service.AddTreningVezbac(InternalData.Data.ulogovanaOsova.ID, trening);

            if (Error != null)
                MessageBox.Show(Error);

            if (Treninzi == null)
                Treninzi = new ObservableCollection<Trening>();
            Treninzi.Add(trening);
        }

        private void Delete()
        {
            //Error = InternalData.Data.service.DeleteAdmin(SelektovaniAdmin);
            //MessageBox.Show(Error);
            Treninzi.Remove(SelektovaniTrening);
        }

        private void Undo()
        {
            //Error = InternalData.Data.service.DeleteAdmin(SelektovaniAdmin);
            //MessageBox.Show(Error);
            Treninzi.Remove(SelektovaniTrening);
        }

        private void Redo()
        {
            //Error = InternalData.Data.service.DeleteAdmin(SelektovaniAdmin);
            //MessageBox.Show(Error);
            Treninzi.Remove(SelektovaniTrening);
        }
    }
}

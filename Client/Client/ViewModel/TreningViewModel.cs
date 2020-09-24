using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public MyICommand CreateTrening { get; set; }
        public MyICommand DeleteTrening { get; set; }
        public MyICommand UndoTrening { get; set; }
        public MyICommand RedoTrening { get; set; }

        public TreningViewModel()
        {
            CreateTrening = new MyICommand(Create);
            DeleteTrening = new MyICommand(Delete, CanUseT);

            UndoTrening = new MyICommand(Undo);
            RedoTrening = new MyICommand(Redo);

            GetTrenere();
        }

        private void GetTrenere()
        {
            var treneri = InternalData.Data.service.GetTrenere();
        }

        public bool CanUseT() => SelektovaniTrening != null;

        private void Create()
        {
            Trening trening = new Trening();
            //Error = InternalData.Data.service.DeleteAdmin(SelektovaniAdmin);
            //MessageBox.Show(Error);
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

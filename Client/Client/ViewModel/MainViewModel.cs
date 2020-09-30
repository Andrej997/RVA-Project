using Client.InternalData;
using Common;
using System;
using System.ServiceModel;

namespace Client.ViewModel
{
    public class MainViewModel : BindableBase
    {
        public IContract logIn;
        public MyICommand<string> Navigacija { get; private set; }

        private HomeViewModel homeViewModel;
        private CRUDUserViewModel cRUDUser;
        private GetAllAdminsViewModel GetAllAdminsViewModel;
        private LoginViewModel loginViewModel;
        private TreningViewModel treningViewModel;
        private MyActionViewModel MyActionViewModel;
        private TrenerViewModel TrenerViewModel;

        private BindableBase trenutniViewModel;
        public BindableBase TrenutniViewModel
        {
            get { return trenutniViewModel; }
            set
            {
                SetProperty(ref trenutniViewModel, value);
            }
        }

        public MainViewModel()
        {
            Connect();
            SetProperties();
        }

        private void SetProperties()
        {
            CreateViewModels();

            Navigacija = new MyICommand<string>(Navig);
            TrenutniViewModel = homeViewModel;
        }

        public void CreateViewModels()
        {
            homeViewModel = new HomeViewModel();
            cRUDUser = new CRUDUserViewModel();
            loginViewModel = new LoginViewModel();
            GetAllAdminsViewModel = new GetAllAdminsViewModel();
            treningViewModel = new TreningViewModel();
            MyActionViewModel = new MyActionViewModel();
            TrenerViewModel = new TrenerViewModel();
        }

        public void Navig(string odabir)
        {
            switch (odabir)
            {
                case "Home":
                    TrenutniViewModel = homeViewModel;
                    break;
                case "Trening":
                    TrenutniViewModel = treningViewModel;
                    break;
                case "Create user":
                    TrenutniViewModel = cRUDUser;
                    break;
                case "Get admins":
                    TrenutniViewModel = GetAllAdminsViewModel;
                    break;
                case "Treneri":
                    TrenutniViewModel = TrenerViewModel;
                    break;
                case "My actions":
                    TrenutniViewModel = MyActionViewModel;
                    break;
                case "Login":
                    TrenutniViewModel = loginViewModel;
                    break;
            }
        }

        public void Connect()
        {
            Uri baseAddress = new Uri("net.tcp://localhost:53200/Common");
            NetTcpBinding binding = new NetTcpBinding();
            binding.MaxReceivedMessageSize = 1000000;
            binding.MaxBufferPoolSize = 1000000;
            binding.MaxBufferSize = 1000000;
            binding.OpenTimeout = TimeSpan.FromMinutes(2);
            binding.SendTimeout = TimeSpan.FromMinutes(2);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
            EndpointAddress addr = new EndpointAddress(baseAddress);
            ChannelFactory<IContract> chn = new ChannelFactory<IContract>(binding, addr);
            logIn = chn.CreateChannel();
            Data.service = logIn;
        }
    }
}

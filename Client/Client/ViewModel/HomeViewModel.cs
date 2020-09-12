namespace Client.ViewModel
{
    public class HomeViewModel : BindableBase
    {
        public string Username { get; set; }
        public HomeViewModel()
        {
            if (InternalData.Data.ulogovanaOsova == null)
                Username = "You are not logged in!";
            else
                Username = InternalData.Data.ulogovanaOsova.Username;
        }
    }
}

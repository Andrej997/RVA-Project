using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.InternalData
{
    public class Data
    {
        public static IContract service { get; set; }
        public static Osoba ulogovanaOsova { get; set; }

        public static bool IsLoggedIn() => ulogovanaOsova == null;

        public static bool IsAdmin() => ulogovanaOsova.Role == 0;
    }
}

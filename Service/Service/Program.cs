using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var inicijalizacija = new InicijalizacijaPodataka();
            inicijalizacija.CheckDBData();

            Connect.ConnectWCF();
        }
    }
}

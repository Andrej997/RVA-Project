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
            Console.WriteLine("Wait while service check database and prepares connection");
            var inicijalizacija = new InicijalizacijaPodataka();
            inicijalizacija.CheckDBData();

            Connect.ConnectWCF();
        }
    }
}

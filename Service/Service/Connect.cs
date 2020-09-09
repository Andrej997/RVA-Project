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
    public class Connect
    {
        public static void ConnectWCF()
        {
            Uri baseAddress = new Uri("http://localhost:8000/Common");

            ServiceHost host = new ServiceHost(typeof(LogIn), baseAddress);
            try
            {
                host.AddServiceEndpoint(typeof(ILogIn), new WSHttpBinding(), "Common");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);

                host.Open();

                Console.WriteLine("The service is ready.");

                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                host.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                host.Abort();
            }
        }
    }
}

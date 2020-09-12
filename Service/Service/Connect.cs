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
            Uri baseAddress = new Uri("net.tcp://localhost:53200/Common");

            //WSHttpBinding binding = new WSHttpBinding();
            //binding.Security.Mode = SecurityMode.Transport;
            //binding.Security.Transport.ClientCredentialType =
            //      HttpClientCredentialType.None;

            NetTcpBinding binding = new NetTcpBinding();
            binding.MaxReceivedMessageSize = 1000000;
            binding.MaxBufferPoolSize = 1000000;
            binding.MaxBufferSize = 1000000;
            binding.OpenTimeout = TimeSpan.FromMinutes(2);
            binding.SendTimeout = TimeSpan.FromMinutes(2);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(10);

            ServiceHost host = new ServiceHost(typeof(Contract));
            try
            {
                host.AddServiceEndpoint(typeof(IContract), binding, baseAddress);

                //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                //smb.HttpGetEnabled = true;
                //host.Description.Behaviors.Add(smb);

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

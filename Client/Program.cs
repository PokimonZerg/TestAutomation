using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestAutomation.Client.Service;

namespace testClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/hello");

            using (ServiceHost host = new ServiceHost(typeof(ClientService), baseAddress))
            {
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }

            /*var vbox = new VirtualBoxManager();

            var m = vbox.GetVirtualMachines()[0];

            Console.WriteLine("Status: " + m.State);

            m.StartAsync().Wait();

            m.StopAsync().Wait();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Status: " + m.State);
                Thread.Sleep(1000);
            }*/
        }
    }
}

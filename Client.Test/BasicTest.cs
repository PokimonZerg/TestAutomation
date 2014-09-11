using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAutomation.Client.Test
{
    [TestClass]
    public class BasicTest
    {
        [TestMethod]
        public void StartAndStopVirtualMachine()
        {
            var client = new ClientService.ClientServiceClient();

            var vmManager = client.GetVirtualMachineManager(ClientService.VirtualMachineManagerType.VirtualBox);

            var vmList = client.ListVirtualMachines(vmManager);

            client.StartVirtualMachine(vmList[0]);
        }
    }
}

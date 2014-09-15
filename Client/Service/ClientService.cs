using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Client.Vm;
using TestAutomation.Client.Vm.VirtualBox;

namespace TestAutomation.Client.Service
{
    public class ClientService : IClientService
    {
        protected static ObjectStore<VirtualMachineManager> managerStore = new ObjectStore<VirtualMachineManager>();
        protected static ObjectStore<VirtualMachine> vmStore = new ObjectStore<VirtualMachine>();

        public Guid GetVirtualMachineManager(VirtualMachineManagerType type)
        {
            switch (type)
            {
                case VirtualMachineManagerType.VirtualBox:
                    return managerStore.Add(VirtualBoxManager.GetInstance());
                default:
                    throw new ClientServiceException("This type of Virtual Machine Manager not supported");
            }
        }

        public List<Guid> ListVirtualMachines(Guid managerId)
        {
            var manager = managerStore.Get(managerId);

            List<Guid> result = new List<Guid>();

            foreach (var vm in manager.ListVirtualMachines())
            {
                result.Add(vmStore.Add(vm));
            }

            return result;
        }

        public void StartVirtualMachine(Guid vmId)
        {
            var vm = vmStore.Get(vmId);

            vm.Start();
        }

        public void StopVirtualMachine(Guid vmId)
        {
            var vm = vmStore.Get(vmId);

            vm.Stop();
        }
    }
}

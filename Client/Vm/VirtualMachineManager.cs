using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Client.Vm
{
    public interface VirtualMachineManager
    {
         List<VirtualMachine> ListVirtualMachines();

         VirtualMachine GetVirtualMachine(String name);

         void StartVirtualMachine(VirtualMachine vm);

         void StopVirtualMachine(VirtualMachine vm);

         VirtualMachine.StateEnum GetVirtualMachineStatus(VirtualMachine vm);
    }
}

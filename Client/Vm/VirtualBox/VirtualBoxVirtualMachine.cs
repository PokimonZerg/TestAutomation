using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualBox;

namespace TestAutomation.Client.Vm.VirtualBox
{
    public class VirtualBoxVirtualMachine : VirtualMachine
    {
        internal VirtualBoxVirtualMachine(VirtualMachineManager vmManager, IMachine vboxMachine) : base(vmManager)
        {
            this.vboxMachine = vboxMachine;
        }

        internal IMachine vboxMachine;
        internal ISession vboxSession;
    }
}

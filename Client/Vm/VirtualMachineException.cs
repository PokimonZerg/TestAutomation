using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Client.Vm
{
    public class VirtualMachineException :  Exception
    {
        public VirtualMachineException(String text) : base(text)
        {

        }
    }
}

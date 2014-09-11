using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Client.Service
{
    [ServiceContract]
    public interface IClientService
    {
        [OperationContract]
        Guid GetVirtualMachineManager(VirtualMachineManagerType type);

        [OperationContract]
        List<Guid> ListVirtualMachines(Guid managerId);

        [OperationContract]
        void StartVirtualMachine(Guid vmId);
    }

    [DataContract]
    public enum VirtualMachineManagerType
    {
        [EnumMember]
        VirtualBox
    }
}

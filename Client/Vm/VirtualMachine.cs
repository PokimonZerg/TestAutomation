using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Client.Vm
{
    public abstract class VirtualMachine
    {
        internal VirtualMachine(VirtualMachineManager vmManager)
        {
            this.vmManager = vmManager;
        }

        public void Start()
        {
            vmManager.StartVirtualMachine(this);
        }

        public void Stop()
        {
            var state = this.State;

            if (state != StateEnum.Running)
                throw new VirtualMachineException("To execute Stop operation machine must be in 'Running' state. Current state is: '" + state + "'");

            vmManager.StopVirtualMachine(this);
        }

        protected VirtualMachineManager vmManager
        {
            get;
            set;
        }

        public String Name
        {
            get;
            protected set;
        }

        public StateEnum State
        {
            get
            {
                return vmManager.GetVirtualMachineStatus(this);
            }
        }

        public override bool Equals(object obj)
        {
            VirtualMachine vm = obj as VirtualMachine;

            return vm.Name.Equals(this.Name) && vm.vmManager.Equals(this.vmManager);
        }

        public override int GetHashCode()
        {
            return (Name.GetHashCode() + vmManager.GetHashCode()) / 2;
        }

        public enum StateEnum
        {
            // Vm in starting phase
            Starting,
            // Vm in stopping phase
            Stoping,
            // Vm currently off
            Off,
            // Vm Running
            Running,
            // Vm restore snapshot
            Restoring,
            // Error happens during vm execution
            Error,
            // Unsupported statuses like 'Paused'
            Unknown
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualBox;

namespace TestAutomation.Client.Vm.VirtualBox
{
    public class VirtualBoxManager : VirtualMachineManager
    {
        public static VirtualMachineManager GetInstance()
        {
            if (self == null)
                self = new VirtualBoxManager();

            return self;
        }

        protected static VirtualBoxManager self = null;

        public VirtualBoxManager()
        {
            vbox = new VirtualBoxClient();
            
            // Initialize VirtualBox
            try
            {
                vbox.VirtualBox.FindMachine("Red virtual machine");
            }
            catch
            {
                // do nothing
            }
        }

        protected VirtualBoxClient vbox;

        public VirtualMachine.StateEnum GetVirtualMachineStatus(VirtualMachine vm)
        {
            VirtualBoxVirtualMachine vboxVm = vm as VirtualBoxVirtualMachine;

            MachineState status = vboxVm.vboxMachine.State;
            
            switch(status)
            {
                case MachineState.MachineState_PoweredOff:
                    return VirtualMachine.StateEnum.Off;

                case MachineState.MachineState_Running:
                    return VirtualMachine.StateEnum.Running;

                case MachineState.MachineState_Starting:
                    return VirtualMachine.StateEnum.Starting;

                case MachineState.MachineState_Stopping:
                    return VirtualMachine.StateEnum.Stoping;

                case MachineState.MachineState_Restoring:
                case MachineState.MachineState_RestoringSnapshot:
                    return VirtualMachine.StateEnum.Restoring;

                case MachineState.MachineState_Stuck:
                case MachineState.MachineState_Aborted:
                    return VirtualMachine.StateEnum.Error;

                default:
                    return VirtualMachine.StateEnum.Unknown;
            }
        }

        public void StartVirtualMachine(VirtualMachine vm)
        {
            VirtualBoxVirtualMachine vboxVm = vm as VirtualBoxVirtualMachine;

            Session session = new Session();

            IProgress progress = vboxVm.vboxMachine.LaunchVMProcess(session, "gui", null);

            progress.WaitForCompletion(10000);

            if (progress.Completed == 0)
            {
                progress.Cancel();
                throw new VirtualMachineException("Launching vm failed");
            }

            vboxVm.vboxSession = session;
        }

        public void StopVirtualMachine(VirtualMachine vm)
        {
            VirtualBoxVirtualMachine vboxVm = vm as VirtualBoxVirtualMachine;

            IProgress progress = vboxVm.vboxSession.Console.PowerDown();

            progress.WaitForCompletion(10000);

            if (progress.Completed == 0)
            {
                progress.Cancel();
                throw new VirtualMachineException("Stopping vm failed");
            }

            vboxVm.vboxSession = null;
        }

        /// <summary>
        /// Get list of all existing virtual machines
        /// </summary>
        /// <returns>List of VirtualMachine objects</returns>
        public List<VirtualMachine> ListVirtualMachines()
        {
            var machines = vbox.VirtualBox.Machines;
            var result = new List<VirtualMachine>();

            foreach (var machine in machines)
            {
                result.Add(new VirtualBoxVirtualMachine(this, machine as IMachine));
            }

            return result;
        }

        /// <summary>
        /// Get virtual machine by name
        /// </summary>
        /// <param name="name">Machine name</param>
        /// <returns>VirtualMachine object or null</returns>
        public VirtualMachine GetVirtualMachine(String name)
        {
            try
            {
                var machine = vbox.VirtualBox.FindMachine(name);

                return new VirtualBoxVirtualMachine(this, machine);
            }
            catch
            {
                // Log this error

                return null;
            }
        }
    }
}

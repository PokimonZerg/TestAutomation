﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Client.Application
{
    public class ClientConfiguration : ConfigurationSection
    {
        public static ClientConfiguration Instance
        {
            get 
            {
                return (ClientConfiguration)System.Configuration.ConfigurationManager.GetSection("clientConfiguration");
            } 
        }

        [ConfigurationProperty("VirtualMachineOperationTimeout")]
        public GenericElement<int> VirtualMachineOperationTimeout
        {
            get
            {
                return (GenericElement<int>)this["VirtualMachineOperationTimeout"];
            }
            set
            {
                this["VirtualMachineOperationTimeout"] = value;
            }
        }
    }

    public class GenericElement<ValueType> : ConfigurationElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public ValueType Value
        {
            get
            {
                return (ValueType)this["value"];
            }

            set
            {
                this["value"] = value;
            }
        }
    }
}

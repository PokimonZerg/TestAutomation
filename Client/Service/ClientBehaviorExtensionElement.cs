using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Client.Service
{
    public class ClientBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(ClientServiceBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new ClientServiceBehavior();
        }
    }
}

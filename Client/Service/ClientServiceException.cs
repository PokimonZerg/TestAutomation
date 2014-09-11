using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Client.Service
{
    class ClientServiceException : Exception
    {
        public ClientServiceException(String text) : base(text)
        {

        }
    }
}

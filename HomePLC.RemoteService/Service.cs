using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HomePLC.RemoteService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service : IService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Message GetDataUsingDataContract(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            if (message.BoolValue)
            {
                message.StringValue += "Suffix";
            }
            return message;
        }
    }
}

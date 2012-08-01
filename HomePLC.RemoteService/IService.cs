using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HomePLC.RemoteService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Message GetDataUsingDataContract(Message message);

        // TODO: Add your service operations here
    }

}

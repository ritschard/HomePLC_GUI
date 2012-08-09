using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;
using System.ServiceModel.Web;

namespace HomePLC.RemoteService
{
    [ServiceContract]
    public interface IService
    {
        // OUTPUTS //

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetAll",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        IList<string> GetAllData();

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetDigitalOuputPinValue/{pin}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        Message GetDigitalOuputPinValue(string pin);
 
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/SetDigitalOuputPinValue/{pin}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        void SetDigitalOuputPinValue(Message message, int pin);
                
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetAnalogOuputPinValue/{pin}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        Message GetAnalogOuputPinValue(string pin);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/SetAnalogOuputPinValue/{pin}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        void SetAnalogOuputPinValue(Message message, int pin);

        // INPUTS //

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetDigitalInputPinValue/{pin}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        Message GetDigitalInputPinValue(string pin);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetAnalogInputPinValue/{pin}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        Message GetAnalogInputPinValue(string pin);
        
        // DEVICE SETTINGS //

    }
   
}

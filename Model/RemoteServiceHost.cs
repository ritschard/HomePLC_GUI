using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using HomePLC.RemoteService;

namespace HomePLC.Model
{
    public class RemoteServiceHost
    {
        private bool serviceStarted = false;
        private WebServiceHost remoteServiceHost = null;
        private Uri serviceBaseAddress = null;
        private string serviceHostname = "localhost";
        private int servicePort = 2202;
        
        public void Start()
        {
            serviceBaseAddress = new Uri("http://" + serviceHostname + ":" + servicePort.ToString() + "/HomePLCRemoteService");

            if (!serviceStarted)
            {                
                remoteServiceHost = new WebServiceHost(typeof(HomePLC.Model.Service1), serviceBaseAddress);

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;

                remoteServiceHost.Description.Behaviors.Add(smb);
                remoteServiceHost.Open();

                serviceStarted = true;
            }
        }

        public void Stop()
        {
            if (serviceStarted)
            {
                remoteServiceHost.Close();
                remoteServiceHost = null;
                serviceStarted = false;
            }
        }
    
        public bool IsStarted 
        { 
            get
            {
                return serviceStarted;
            } 
        }

        public string Hostname
        {
            get
            {
                return serviceHostname;
            }
            set
            {
                serviceHostname = value;
            }
        }

        public int Port
        {
            get
            {
                return servicePort;
            }
            set 
            {
                servicePort = value;
            }
        }

        public Uri HostUri
        {
            get
            {
                return serviceBaseAddress;
            }
        }

        public WebServiceHost Host
        {
            get
            {
                return remoteServiceHost;
            }
        }

    }
}
